
using System.Text;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using WatchList.API.Middleware;
using WatchList.Core.Models;
using WatchList.Core.Repositories;
using WatchList.Core.Services;
using WatchList.Core.Services.Interfaces;
using WatchList.Core.Swagger;
using WatchList.Identity.Access;
using WatchList.Identity.Access.Interfaces;
using WatchList.Identity.Data;
using WatchList.Identity.Entities;
using WatchList.Identity.Enums;
using WatchList.Identity.Repositories;
using WatchList.Identity.Repositories.Interfaces;
using WatchList.Identity.Services;
using WatchList.Identity.Services.Interfaces;
using WatchList.Editor.Access;
using WatchList.Editor.Access.Interfaces;
using WatchList.Editor.Data;
using WatchList.Editor.Repositories;
using WatchList.Editor.Repositories.Interfaces;
using WatchList.Core.Entities.Interfaces;
using Microsoft.EntityFrameworkCore.Storage;

const string corsOriginsKey = "CORS 4 WEBSITE";
var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;
var configuration = builder.Configuration;

ConfigureServices();
ConfigureApp();

void ConfigureServices()
{
    /*
        Transient objects are always different; a new instance is provided to every controller and every service.
        Scoped objects are the same within a request, but different across different requests.
        Singleton objects are the same for every object and every request.
     */
    services.AddHostedService<TokenInvalidatorService>();
    services.AddTransient<ITokenService, TokenService>();
    services.AddTransient<IEmailService, EmailService>();

    services.AddScoped(typeof(IAsyncRepository<IEntity>), typeof(EfRepository<IEntity,EditorContext>));
    services.AddScoped(typeof(IAsyncRepository<IEntity>), typeof(EfRepository<IEntity, IdentityContext>));
    services.AddScoped<IUserRepository, UserRepository>();
    services.AddScoped<IUserPromptRepository, UserPromptRepository>();
    services.AddScoped<IUserTokenRepository, UserTokenRepository>();

    services.AddScoped<ICollectionRepository, CollectionRepository>();
    services.AddScoped<IGenreRepository, GenreRepository>();
    services.AddScoped<ICreditRepository, CreditRepository>();
    services.AddScoped<IKeywordRepository, KeywordRepository>();
    services.AddScoped<ILanguageRepository, LanguageRepository>();
    services.AddScoped<IProductionCompanyRepository, ProductionCompanyRepository>();
    services.AddScoped<IProductionCountryRepository, ProductionCountryRepository>();
    services.AddScoped<IMovieRepository, MovieRepository>();

    services.AddScoped<IUsers, Users>();
    services.AddScoped<ICollections, Collections>();
    services.AddScoped<IGenres, Genres>();
    services.AddScoped<ICredits, Credits>();
    services.AddScoped<IKeywords, Keywords>();
    services.AddScoped<ILanguages, Languages>();
    services.AddScoped<IProductionCompanies, ProductionCompanies>();
    services.AddScoped<IProductionCountries, ProductionCountries>();
    services.AddScoped<IMovies, Movies>();

    services.AddCors(options =>
    {
        options.AddPolicy(corsOriginsKey,
            policy =>
            {
                policy.WithOrigins("http://localhost:4224")
                    .WithHeaders("*")
                    .WithMethods("*");
            });
    });

    services.AddDbContext<EditorContext>(options =>
        options.UseSqlServer(configuration.GetConnectionString("Database")));
    services.AddDbContext<IdentityContext>(options =>
        options.UseSqlServer(configuration.GetConnectionString("Database")));

    services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

    services.Configure<SmtpSettings>(configuration.GetSection("SmtpSettings"));
    services.Configure<AppSettings>(configuration.GetSection("AppSettings"));
    var appSettings = configuration.GetSection("AppSettings").Get<AppSettings>();
    
    if (appSettings == null)
    {
        throw new Exception("UNABLE TO RETRIEVE APP SETTINGS!");
    }

    services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = appSettings.JwtIssuer,
            ValidAudience = appSettings.JwtAudience,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(appSettings.JwtSecret))
        };
    });


    services.AddControllers()
        .AddJsonOptions(options =>
        {
            options.JsonSerializerOptions.Converters.Add(
                new JsonStringEnumConverter());
        });

    services.AddEndpointsApiExplorer();
    services.AddSwaggerGen(options =>
    {
        options.SwaggerDoc("v1", new OpenApiInfo { Title = "Watch List", Version = "v1" });

        options.EnableAnnotations();
        options.SchemaFilter<SwaggerSchemaExampleFilter>();

        options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
        {
            Description = @"JWT Authorization header using the Bearer scheme. </br>
                      Enter 'Bearer' [space] and then your token in the text input below.
                      </br>Example: 'Bearer 12345abcdef'",
            Name = "Authorization",
            In = ParameterLocation.Header,
            Type = SecuritySchemeType.ApiKey,
            Scheme = "Bearer"
        });

        options.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    },
                    Scheme = "oauth2",
                    Name = "Bearer",
                    In = ParameterLocation.Header
                },
                new List<string>()
            }
        });
    });
}

void ConfigureApp()
{
    var app = builder.Build();

    using (var scope =
           ((IApplicationBuilder) app).ApplicationServices.CreateScope())
    {
        using (var context = scope.ServiceProvider.GetService<EditorContext>())
        {
            context?.Database.EnsureDeleted();
            context?.Database.EnsureCreated();

            context?.SaveChanges();
        }
        using (var context = scope.ServiceProvider.GetService<IdentityContext>())
        {
            var databaseCreator = context?.GetService<IRelationalDatabaseCreator>();
            databaseCreator?.CreateTables();

            context?.Database.EnsureCreated();


            context?.Users.Add(new DbUser
            {
                Id = new Guid("4081aaed-9ac8-4a3b-9fda-08da53098d50"),
                EmailAddress = "admin@watch-list.com",
                Name = "Admin",
                PasswordAttempts = 0,
                IsAdmin = true,
                Password = "6LaWQkPDI1473yabhnmI7+Wmm4PZF/XVoQ2AGKo07NlVv7Zy4tMcqeVbg86z4VCtbpLGBscyjuZo53kHivnck/DhbfTux1CozF+mjFlHxeibrD1NWabyToqGEaKfPSRzPgW95u6fC99pXOVkvE9bauI676yYkWlh6GxbzHDjJ/KjqOjV+TvmWp2W/zHwz7BasDQ/QbzSWX2eGmaZR6x3U70Xycbs33TNE8xqsx2gbCx8pt4z931nsjXAh5FgO4/ZYWwEeq+xCMMGWX18w8TDGA9Brpk3g44B3R8mdHiTbKNuyuvpTu2bnYyxu2zLbmBEIIXwk564jyGnlzU0bmidig==",
                PasswordSalt = "Ut0cFgpT1f7VZn75PlLIeut05KBKRsVq3RUACSgnkZxq2HTTgZc36a9q5UzaKjMYWmCM7Yzjtc6s5lZz+7IRmHfG1I2wJuItW7U70p4rxBfF/1sopJXrf2gAnY98DXPxDyZEpg3pKq+JJ/NCO00BPHEEBC0y8ITPLP/jBXsGyKk=",
                Status = DbUserStatusTypeEnum.Active,
            });

            context?.Users.Add(new DbUser
            {
                Id = new Guid("5f839195-8126-4a93-9a0f-0ba40866cdf8"),
                EmailAddress = "user@watch-list.com",
                Name = "User",
                PasswordAttempts = 0,
                IsAdmin = false,
                Password = "6LaWQkPDI1473yabhnmI7+Wmm4PZF/XVoQ2AGKo07NlVv7Zy4tMcqeVbg86z4VCtbpLGBscyjuZo53kHivnck/DhbfTux1CozF+mjFlHxeibrD1NWabyToqGEaKfPSRzPgW95u6fC99pXOVkvE9bauI676yYkWlh6GxbzHDjJ/KjqOjV+TvmWp2W/zHwz7BasDQ/QbzSWX2eGmaZR6x3U70Xycbs33TNE8xqsx2gbCx8pt4z931nsjXAh5FgO4/ZYWwEeq+xCMMGWX18w8TDGA9Brpk3g44B3R8mdHiTbKNuyuvpTu2bnYyxu2zLbmBEIIXwk564jyGnlzU0bmidig==",
                PasswordSalt = "Ut0cFgpT1f7VZn75PlLIeut05KBKRsVq3RUACSgnkZxq2HTTgZc36a9q5UzaKjMYWmCM7Yzjtc6s5lZz+7IRmHfG1I2wJuItW7U70p4rxBfF/1sopJXrf2gAnY98DXPxDyZEpg3pKq+JJ/NCO00BPHEEBC0y8ITPLP/jBXsGyKk=",
                Status = DbUserStatusTypeEnum.Active,
            });

            context?.SaveChanges();
        }
    }



    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseCors(corsOriginsKey);

    app.UseHttpsRedirection();
    app.UseAuthorization();

    app.UseMiddleware<JwtMiddleware>();

    app.MapControllers();
    app.Run();
}

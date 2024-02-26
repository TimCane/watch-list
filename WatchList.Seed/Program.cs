// See https://aka.ms/new-console-template for more information

using System.Diagnostics;
using System.Globalization;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic.FileIO;
using Newtonsoft.Json;
using Swashbuckle.AspNetCore.SwaggerGen;
using WatchList.Editor.Access;
using WatchList.Editor.Data;
using WatchList.Editor.Entities;
using WatchList.Editor.Enums;
using WatchList.Editor.Models;
using WatchList.Seed.Models;


var csvMoviesTask = new Task<List<CsvMovie>>(() =>
{
    var sw = new Stopwatch();
    sw.Start();
    var csvMoviesRaw = GetMovies();
    sw.Stop();
    Console.WriteLine($"Movies ({csvMoviesRaw.Count}): {sw.ElapsedMilliseconds / 1000} seconds");

    return csvMoviesRaw;
});

var csvCreditsTask = new Task<List<CsvCredit>>(() =>
{
    var sw = new Stopwatch();
    sw.Start();
    var csvCreditsRaw = GetCredits();
    sw.Stop();
    Console.WriteLine($"Credits ({csvCreditsRaw.Count}): {sw.ElapsedMilliseconds / 1000} seconds");

    return csvCreditsRaw;
});

var csvKeywordsTask = new Task<List<CsvKeyword>>(() =>
{
    var sw = new Stopwatch();
    sw.Start();
    var csvKeywordsRaw = GetKeywords();
    sw.Stop();
    Console.WriteLine($"Keywords ({csvKeywordsRaw.Count}): {sw.ElapsedMilliseconds / 1000} seconds");

    return csvKeywordsRaw;
});

csvMoviesTask.Start();
csvCreditsTask.Start();
csvKeywordsTask.Start();

await Task.WhenAll(csvMoviesTask, csvCreditsTask, csvKeywordsTask);

ParseIntoDb(csvMoviesTask.Result, csvCreditsTask.Result, csvKeywordsTask.Result);

void ParseIntoDb(List<CsvMovie> csvMovies, List<CsvCredit> csvCredits, List<CsvKeyword> csvKeywords)
{
    var collections = new Dictionary<int, DbCollection>();
    var credits = new Dictionary<int, DbCredit>();
    var genres = new Dictionary<int, DbGenre>();
    var keywords = new Dictionary<int, DbKeyword>();
    var languages = new Dictionary<string, DbLanguage>();
    var movies = new Dictionary<int, DbMovie>();
    var productionCompanies = new Dictionary<int, DbProductionCompany>();
    var productionCountries = new Dictionary<string, DbProductionCountry>();

    using var db = new EditorContext(new DbContextOptions<EditorContext>() {});

    db?.Database.EnsureDeleted();
    db?.Database.EnsureCreated();
    
    db?.SaveChanges();

    foreach (var row in csvMovies)
    {
        if (movies.ContainsKey(row.id))
        {
            continue;
        }

        var movie = new DbMovie()
        {
            Overview = row.overview,
            ReleaseDate = row.release_date,
            Runtime = Convert.ToInt32(row.runtime),
            Adult = row.adult,
            Budget = row.budget,
            Homepage = row.homepage,
            OriginalTitle = row.original_title,
            Revenue = row.revenue,
            TagLine = row.tagline,
            Title = row.title,
            Credits = new List<DbMovieCredit>(),
            Genres = new List<DbMovieGenre>(),
            Keywords = new List<DbMovieKeyword>(),
            Languages = new List<DbMovieLanguage>(),
            ProductionCompanies = new List<DbMovieProductionCompany>(),
            ProductionCountries = new List<DbMovieProductionCountry>()
        };

        db.DbMovies.Add(movie);
        movies.Add(row.id, movie);

        if (row.genres != null)
        {
            foreach (var genre in row.genres)
            {
                DbGenre dbGenre;
                if (genres.ContainsKey(genre.id))
                {
                    dbGenre = genres[genre.id];
                }
                else
                {
                    dbGenre = new DbGenre()
                    {
                        Name = genre.name,
                    };

                    db.DbGenres.Add(dbGenre);
                    genres.Add(genre.id, dbGenre);
                }

                db.MovieGenres.Add(new DbMovieGenre()
                {
                    GenreId = dbGenre.Id,
                    MovieId = movie.Id,
                });
            }
        }
        if (row.belongs_to_collection != null)
        {
            DbCollection dbCollection;
            if (collections.ContainsKey(row.belongs_to_collection.id))
            {
                dbCollection = collections[row.belongs_to_collection.id];
            }
            else
            {
                dbCollection = new DbCollection()
                {
                    Name = row.belongs_to_collection.name,
                };

                db.DbCollections.Add(dbCollection);
                collections.Add(row.belongs_to_collection.id, dbCollection);
            }

            movie.Collection = dbCollection;
        }

        if (row.spoken_languages != null)
        {
            foreach (var language in row.spoken_languages)
            {
                DbLanguage dbLanguage;
                if (languages.ContainsKey(language.iso_639_1))
                {
                    dbLanguage = languages[language.iso_639_1];
                }
                else
                {
                    dbLanguage = new DbLanguage()
                    {
                        Iso = language.iso_639_1,
                        Name = language.name,
                    };

                    db.DbLanguages.Add(dbLanguage);
                    languages.Add(language.iso_639_1, dbLanguage);
                }

                db.MovieLanguages.Add(new DbMovieLanguage()
                {
                    LanguageId = dbLanguage.Id,
                    MovieId = movie.Id,
                });
            }
        }
        
        var originalLanguage = languages.Values.FirstOrDefault(l => l.Iso == row.original_language);
        if (originalLanguage != null)
        {
            movie.Language = originalLanguage;
        }

        if (row.production_companies != null)
        {
            foreach (var production_company in row.production_companies)
            {
                DbProductionCompany dbProductionCompany;
                if (productionCompanies.ContainsKey(production_company.id))
                {
                    dbProductionCompany = productionCompanies[production_company.id];
                }
                else
                {
                    dbProductionCompany = new DbProductionCompany()
                    {
                        Name = production_company.name,
                    };
                    db.DbProductionCompanies.Add(dbProductionCompany);
                    productionCompanies.Add(production_company.id, dbProductionCompany);
                }

                db.MovieProductionCompanies.Add(new DbMovieProductionCompany()
                {
                    ProductionCompanyId = dbProductionCompany.Id,
                    MovieId = movie.Id,
                });
            }
        }

        if (row.production_countries != null)
        {
            foreach (var production_country in row.production_countries)
            {
                DbProductionCountry dbProductionCountry;
                if (productionCountries.ContainsKey(production_country.iso_3166_1))
                {
                    dbProductionCountry = productionCountries[production_country.iso_3166_1];
                }
                else
                {
                    dbProductionCountry = new DbProductionCountry()
                    {
                        Name = production_country.name,
                        Iso = production_country.iso_3166_1
                    };

                    db.DbProductionCountries.Add(dbProductionCountry);
                    productionCountries.Add(production_country.iso_3166_1, dbProductionCountry);
                }

                db.MovieProductionCountries.Add(new DbMovieProductionCountry()
                {
                    ProductionCountryId = dbProductionCountry.Id,
                    MovieId = movie.Id,
                });
            }
        }
    }

    foreach (var row in csvKeywords)
    {
        if (!movies.ContainsKey(row.id))
        {
            continue;
        }

        var movie = movies[row.id];

        foreach (var keyword in row.keywords)
        {
            DbKeyword dbKeyword;
            if (keywords.ContainsKey(keyword.id))
            {
                dbKeyword = keywords[keyword.id];
            }
            else
            {
                dbKeyword = new DbKeyword()
                {
                    Name = keyword.name,
                };

                db.DbKeywords.Add(dbKeyword);
                keywords.Add(keyword.id, dbKeyword);
            }

            db.MovieKeywords.Add(new DbMovieKeyword()
            {
                KeywordId = dbKeyword.Id,
                MovieId = movie.Id,
            });
        }
    }
    var added = new Dictionary<(Guid movieId, int creditId), DbCredit>();
    var skipped = new Dictionary<(Guid movieId, int creditId), DbCredit>();

    foreach (var row in csvCredits)
    {
        if (!movies.ContainsKey(row.id))
        {
            continue;
        }

        var movie = movies[row.id];



        foreach (var crew in row.crew)
        {
            DbCredit dbCredit;
            if (credits.ContainsKey(crew.id))
            {
                dbCredit = credits[crew.id];
            }
            else
            {
                dbCredit = new DbCredit()
                {
                    Name = crew.name,
                    Character = crew.character,
                    Gender = DbCreditGenderEnumHelper.ToEnum(crew.gender),
                    Order = crew.order,
                    Type = DbCreditTypeEnum.Crew
                };
                db.DbCredits.Add(dbCredit);
                credits.Add(crew.id, dbCredit);
            }

            if (!added.ContainsKey((movie.Id, crew.id)))
            {
                added.Add((movie.Id, crew.id), dbCredit);

                db.MovieCredits.Add(new DbMovieCredit()
                {
                    CreditId = dbCredit.Id,
                    MovieId = movie.Id,
                });
            }
            else
            {
                skipped.TryAdd((movie.Id, crew.id), dbCredit);
            }
        }

        foreach (var cast in row.cast)
        {
            DbCredit dbCredit;
            if (credits.ContainsKey(cast.id))
            {
                dbCredit = credits[cast.id];
            }
            else
            {
                dbCredit = new DbCredit()
                {
                    Name = cast.name,
                    Character = cast.character,
                    Gender = DbCreditGenderEnumHelper.ToEnum(cast.gender),
                    Order = cast.order,
                    Type = DbCreditTypeEnum.Cast
                };

                db.DbCredits.Add(dbCredit);
                credits.Add(cast.id, dbCredit);
            }

            if (!added.ContainsKey((movie.Id, cast.id)))
            {
                added.Add((movie.Id, cast.id), dbCredit);

                db.MovieCredits.Add(new DbMovieCredit()
                {
                    CreditId = dbCredit.Id,
                    MovieId = movie.Id,
                });
            }
            else
            {
                skipped.TryAdd((movie.Id, cast.id), dbCredit);
            }
        }

        var b = 10;
    }
    
    db.SaveChanges();
    


    var a = 10;

}


List<CsvCredit> GetCredits()
{
    var credits = new List<CsvCredit>();

    using (TextFieldParser parser = new TextFieldParser(@"C:\Github\TimCane\watch-list\WatchList.Seed\Data\credits.csv"))
    {
        parser.TextFieldType = FieldType.Delimited;
        parser.SetDelimiters(",");
        parser.HasFieldsEnclosedInQuotes = true;
        var row = 0;
        while (!parser.EndOfData)
        {
            //Process row
            string[] fields = parser.ReadFields();

            row++;
            if (row == 1)
            {
                continue;
            }


            try
            {
                var credit = new CsvCredit()
                {
                };

                var col = 0;
                foreach (string field in fields)
                {
                    col++;

                    if (string.IsNullOrEmpty(field))
                    {
                        continue;
                    }

                    //cast
                    if (col == 1)
                    {
                        credit.cast = JsonConvert.DeserializeObject<List<CreditItem>>(field);
                    }

                    //crew
                    if (col == 2)
                    {
                        credit.crew = JsonConvert.DeserializeObject<List<CreditItem>>(field);
                    }

                    //id
                    if (col == 3)
                    {
                        credit.id = Convert.ToInt32(field);
                    }
                }

                credits.Add(credit);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }
    }

    return credits;
}

List<CsvKeyword> GetKeywords()
{
    var keywords = new List<CsvKeyword>();

    using (TextFieldParser parser = new TextFieldParser(@"C:\Github\TimCane\watch-list\WatchList.Seed\Data\keywords.csv"))
    {
        parser.TextFieldType = FieldType.Delimited;
        parser.SetDelimiters(",");
        parser.HasFieldsEnclosedInQuotes = true;
        var row = 0;
        while (!parser.EndOfData)
        {
            //Process row
            string[] fields = parser.ReadFields();

            row++;
            if (row == 1)
            {
                continue;
            }


            try
            {
                var keyword = new CsvKeyword()
                {
                };

                var col = 0;
                foreach (string field in fields)
                {
                    col++;

                    if (string.IsNullOrEmpty(field))
                    {
                        continue;
                    }

                    //id
                    if (col == 1)
                    {
                        keyword.id = Convert.ToInt32(field);
                    }

                    //keywords
                    if (col == 2)
                    {
                        keyword.keywords = JsonConvert.DeserializeObject<List<KeywordItem>>(field);
                    }
                }

                keywords.Add(keyword);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }
    }

    return keywords;
}

List<CsvMovie> GetMovies()
{
    var movies = new List<CsvMovie>();

    using (TextFieldParser parser = new TextFieldParser(@"C:\Github\TimCane\watch-list\WatchList.Seed\Data\movies_metadata.csv"))
    {
        parser.TextFieldType = FieldType.Delimited;
        parser.SetDelimiters(",");
        parser.HasFieldsEnclosedInQuotes = true;
        var row = 0;
        while (!parser.EndOfData)
        {
            //Process row
            string[] fields = parser.ReadFields();

            row++;
            if (row == 1)
            {
                continue;
            }


            try
            {
                var movie = new CsvMovie()
                {
                };

                var col = 0;
                foreach (string field in fields)
                {
                    col++;

                    if (string.IsNullOrEmpty(field))
                    {
                        continue;
                    }

                    // adult
                    if (col == 1)
                    {
                        movie.adult = Convert.ToBoolean(field);
                    }
                    // belongs_to_collection
                    if (col == 2)
                    {
                        movie.belongs_to_collection = JsonConvert.DeserializeObject<CollectionItem>(field);
                    }
                    // budget
                    if (col == 3)
                    {
                        movie.budget = Convert.ToInt32(field);
                    }
                    // genres
                    if (col == 4)
                    {
                        movie.genres = JsonConvert.DeserializeObject<List<GenreItem>>(field);
                    }
                    // homepage
                    if (col == 5)
                    {
                        movie.homepage = field;
                    }
                    // id
                    if (col == 6)
                    {
                        movie.id = Convert.ToInt32(field);
                    }
                    // imdb_id
                    if (col == 7)
                    {
                        movie.imdb_id = field;
                    }
                    // original_language
                    if (col == 8)
                    {
                        movie.original_language = field;
                    }
                    // original_title
                    if (col == 9)
                    {
                        movie.original_title = field;
                    }
                    // overview
                    if (col == 10)
                    {
                        movie.overview = field;
                    }
                    // popularity
                    if (col == 11)
                    {
                        movie.popularity = field;
                    }
                    // poster_path
                    if (col == 12)
                    {
                        movie.poster_path = field;
                    }
                    // production_companies
                    if (col == 13)
                    {
                        movie.production_companies = JsonConvert.DeserializeObject<List<ProductionCompanyItem>>(field);
                    }
                    // production_countries
                    if (col == 14)
                    {
                        movie.production_countries = JsonConvert.DeserializeObject<List<ProductionCountryItem>>(field);
                    }
                    // release_date
                    if (col == 15)
                    {
                        movie.release_date = DateTime.ParseExact(field, "yyyy-MM-dd", new DateTimeFormatInfo());
                    }
                    // revenue
                    if (col == 16)
                    {
                        movie.revenue = Convert.ToInt64(field);
                    }
                    // runtime
                    if (col == 17)
                    {
                        movie.runtime = Convert.ToDecimal(field);
                    }
                    // spoken_languages
                    if (col == 18)
                    {
                        movie.spoken_languages = JsonConvert.DeserializeObject<List<LanguageItem>>(field);
                    }
                    // status
                    if (col == 19)
                    {
                        movie.status = field;
                    }
                    // tagline
                    if (col == 20)
                    {
                        movie.tagline = field;
                    }
                    // title
                    if (col == 21)
                    {
                        movie.title = field;
                    }
                    // video
                    if (col == 22)
                    {
                        movie.video = field;
                    }
                    // vote_average
                    if (col == 23)
                    {
                        movie.vote_average = field;
                    }

                    // vote_count
                    if (col == 24)
                    {
                        movie.vote_count = field;
                    }

                }

                movies.Add(movie);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }
    }

    return movies;
}
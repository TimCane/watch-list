using System.Reflection;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace WatchList.Core.Swagger
{
    public class SwaggerSchemaExampleFilter : ISchemaFilter
    {
        public void Apply(OpenApiSchema schema, SchemaFilterContext context)
        {
            if (context.MemberInfo == null) return;

            var schemaAttribute = context.MemberInfo.GetCustomAttributes<ExampleAttribute>()
                .FirstOrDefault();
            if (schemaAttribute != null)
                ApplySchemaAttribute(schema, schemaAttribute);
        }

        private static void ApplySchemaAttribute(OpenApiSchema schema, ExampleAttribute schemaAttribute)
        {
            schema.Example = new OpenApiString(schemaAttribute.Example);
        }
    }
}

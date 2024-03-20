using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Argus.Platform.Infrastructure.Config
{
    public class AddHeaderParameter  : IOperationFilter
    {
      

        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            if (context.ApiDescription.RelativePath.Contains("api/User/Login") || context.ApiDescription.RelativePath.Contains("api/User/Register"))
            {
                if (operation.Parameters == null)
                    operation.Parameters = new List<OpenApiParameter>();

                operation.Parameters.Add(new OpenApiParameter
                {
                    Name = "tenant",
                    In = ParameterLocation.Header,
                    Description = "Please Add Tenency Name",
                    Required = true,
                    Schema = new OpenApiSchema { Type = "string" }
                });
            }
        }
    }
}

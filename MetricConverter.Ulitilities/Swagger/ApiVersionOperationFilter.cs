using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Text;

namespace MetricConverter.Ulitilities.Swagger
{
    public class ApiVersionOperationFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            var actionApiVersionModel = context.ApiDescription.ActionDescriptor?.GetApiVersion();
            if (actionApiVersionModel == null)
            {
                return;
            }
        }
    }
}

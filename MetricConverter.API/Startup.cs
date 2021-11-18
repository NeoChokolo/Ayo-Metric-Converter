using MetricConverter.Core.Repositories;
using MetricConverter.Core.Services;
using MetricConverter.Infrastructure.Configuration;
using MetricConverter.Infrastructure.Data.SQL;
using MetricConverter.Model;
using MetricConverter.Ulitilities.Swagger;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Converters;
using System;
using System.Linq;

namespace MetricConverter.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddHealthChecks();
            services.AddHttpContextAccessor();
            //services.AddAuthentication("Bearer")
            //        .AddIdentityServerAuthentication("Bearer", options =>
            //        {
            //            options.ApiName = "metricconverter.api";
            //            options.Authority = "https://localhost:5001";
            //        });

            services.AddRouting(options => options.LowercaseUrls = true);
            services.AddCors(options => options.AddPolicy("CorsPolicy", builder =>
            {
                builder.AllowAnyHeader()
                .AllowAnyMethod()
                .AllowAnyOrigin();
            }));
            services.AddControllersWithViews().AddNewtonsoftJson(
              options => options.SerializerSettings.Converters.Add(new StringEnumConverter()));
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Metric To Imperial Converter API",
                    Description = "This API manages Metric To Imperial Converter",
                    TermsOfService = new Uri("https://neochokolo.co.za/terms"),
                    Contact = new OpenApiContact
                    {
                        Name = "Neo",
                        Email = string.Empty,
                        Url = new Uri("https://neochokolo.co.za"),
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Use under LICX",
                        Url = new Uri("https://neochokolo.co.za/license"),
                    }
                });

                var swaggerFile = CommentsFileHelper.GenerateSwaggerFile();

                c.DocInclusionPredicate((docName, apiDesc) =>
                {
                    var actionApiVersionModel = apiDesc.ActionDescriptor?.GetApiVersion();
                    if (actionApiVersionModel == null)
                        return true;
                    if (actionApiVersionModel.DeclaredApiVersions.Any())
                        return actionApiVersionModel.DeclaredApiVersions.Any(v => $"v{v.ToString()}" == docName);
                    return actionApiVersionModel.ImplementedApiVersions.Any(v => $"v{v.ToString()}" == docName);
                });

                c.OperationFilter<ApiVersionOperationFilter>();
                c.IncludeXmlComments(swaggerFile);
            });
            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));
            var settings = Configuration.GetSection("AppSettings").Get<AppSettings>();
            services.AddDbContext<MetricConverterContext>(options => options.UseSqlServer(settings.connectionString));

            MapServices(services);
            MapRepositories(services);
        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseCors("CorsPolicy");
            app.UseHealthChecks("/health");
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapControllerRoute("default", "{controller=home}/{action=Index}/{id?}");
            });
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint(Configuration["AppSettings:VirtualDirectory"] + "/swagger/v1/swagger.json", "Metric To Imperial Converter API");
            });
        }

        /// <summary>
        /// DI Repositories
        /// </summary>
        /// <param name="services"></param>
        public void MapServices(IServiceCollection services)
        {
            services.AddTransient<IMetricConverterService, MetricConverterService>();
            services.AddTransient<IMetricTypeService, MetricTypeService>();
            services.AddTransient<IMetricUnitService, MetricUnitService>();
            services.AddTransient<IMetricFormulaService, MetricFormulaService>();

        }

        /// <summary>
        /// DI Repositories
        /// </summary>
        /// <param name="services"></param>
        public void MapRepositories(IServiceCollection services)
        {
            services.AddTransient<IMetricFormulaRepository, MetricFormulaRepository>();
            services.AddTransient<IMetricUnitRepository, MetricUnitRepository>();
            services.AddTransient<IMetricTypeRepository, MetricTypeRepository>();
        }
    }
}

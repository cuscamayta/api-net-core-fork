using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Thermon.Computrace.Web.Core.Repositories.Command.Base;
using Thermon.Computrace.Web.Core.Repositories.Query;
using Thermon.Computrace.Web.Core.Repositories.Query.Base;
using Thermon.Computrace.Web.Infrastructure.Data;
using Thermon.Computrace.Web.Infrastructure.Repository.Command;
using Thermon.Computrace.Web.Infrastructure.Repository.Command.Base;
using Thermon.Computrace.Web.Infrastructure.Repository.Query;
using Thermon.Computrace.Web.Infrastructure.Repository.Query.Base;
using System.Reflection;
using System.Globalization;
using System.Collections.Generic;
using Microsoft.AspNetCore.Localization;
using Thermon.Computrace.Web.Application.Handlers.CommandHandler.Projects;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Thermon.Computrace.Web.Application.Handlers.CommandHandler.Profiles;
using DinkToPdf.Contracts;
using DinkToPdf;
using Thermon.Computrace.Web.Api.Services;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace Thermon.Computrace.Web.Api
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
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidAudience = Configuration["Jwt:Audience"],
                    ValidIssuer = Configuration["Jwt:Issuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
                };
            });
            services.AddAuthorization();

            //services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            //    .AddJwtBearer(options => Configuration.Bind("AzureAd", options));

            services.AddCors();
            services.AddControllers();

            // Configure for Sqlite
            services.AddDbContext<ComputraceContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Thermon.Computrace.Web.Api", Version = "v1" });
            });

            // Register dependencies
            services.AddAutoMapper(typeof(Startup));
            services.AddMediatR(typeof(CreateProjectHandler).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(CreateCommentHandler).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(CreateProfileHandler).GetTypeInfo().Assembly);
            services.AddScoped(typeof(IQueryRepository<>), typeof(QueryRepository<>));

            services.AddTransient<IProjectQueryRepository, ProjectQueryRepository>();
            services.AddTransient<ICircuitQueryRepository, CircuitQueryRepository>();
            services.AddTransient<IProfileQueryRepository, ProfileQueryRepository>();
            services.AddTransient<IConnectionInfoQueryRepository, ConnectionInfoQueryRepository>();
            services.AddTransient<ICommentQueryRepository, CommentQueryRepository>();
            services.AddTransient<IProjectPropertiesQueryRepository, ProjectPropertiesQueryRepository>();

            services.AddScoped(typeof(ICommandRepository<>), typeof(CommandRepository<>));
            services.AddTransient<Core.Repositories.Command.IProjectCommandRepository, ProjectCommandRepository>();
            services.AddTransient<Core.Repositories.Command.ICommentCommandRepository, CommentCommandRepository>();
            services.AddTransient<Core.Repositories.Command.IProfileCommandRepository, ProfileCommandRepository>();
            services.AddTransient<Core.Repositories.Command.IConnectionInfoCommandRepository, ConnectionInfoCommandRepository>();

            services.AddSingleton(typeof(IConverter), new SynchronizedConverter(new PdfTools()));

            services.AddTransient<IDocumentService, DocumentService>();

            services.AddLocalization(opt => { opt.ResourcesPath = "Resources"; });

            services.Configure<RequestLocalizationOptions>(options =>
            {
                List<CultureInfo> supportedCultures = new List<CultureInfo>
                {
                    new CultureInfo("en-US"),
                    new CultureInfo("de-DE"),
                    new CultureInfo("fr-FR"),
                    new CultureInfo("en-GB")
                };
                options.DefaultRequestCulture = new RequestCulture("en-GB");
                options.SupportedCultures = supportedCultures;
                options.SupportedUICultures = supportedCultures;
            });

            services.Configure<RequestLocalizationOptions>(options =>
            {
                options.DefaultRequestCulture = new RequestCulture("en-US");
            });

            services.AddCors(options =>
            {
                options.AddPolicy("Open", builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment() || env.IsProduction() || env.IsStaging())
            {

                app.UseDeveloperExceptionPage();
                app.UseSwagger();

                app.UseSwaggerUI(c => {
                    c.DefaultModelsExpandDepth(-1);
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Thermon.Computrace.Web.Api v1");
                });
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors("Open");

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }
    }
}

using Autofac;
using Autofac.Extensions.DependencyInjection;
using ElmahCore.Mvc;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.OpenApi.Models;

namespace PowerPack.API
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
            services.AddCors();
            services.AddMvc();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(name: "v1", new OpenApiInfo { Title = "Power Pack API", Version = "1.0" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(opt=>opt.WithOrigins("http://localhost:65256"));

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            var pathBase = Configuration["PATH_BASE"];

            if (!string.IsNullOrEmpty(pathBase))
            {
                loggerFactory.CreateLogger<Startup>().LogDebug("Using PATH BASE '{pathBase}'", pathBase);
                app.UsePathBase(pathBase);
            }

            app.UseSwagger()
             .UseSwaggerUI(c =>
             {
                 c.SwaggerEndpoint($"{ (!string.IsNullOrEmpty(pathBase) ? pathBase : string.Empty) }/swagger/v1/swagger.json", "Power Pack Online Service API'S V1");
             });

            app.UseEndpoints(endpoints =>
                {
                    endpoints.MapControllers();
                });
        }

        //    public Startup(IConfiguration configuration)
        //    {
        //        Configuration = configuration;
        //    }

        //    public IConfiguration Configuration { get; }

        //    // This method gets called by the runtime. Use this method to add services to the container.
        //    public IServiceProvider ConfigureServices(IServiceCollection services)
        //    {

        //        services.AddControllers();


        //        services.AddCustomMVC(Configuration)
        //                .AddCustomDbContext(Configuration)
        //                .AddCustomOptions(Configuration)
        //                .AddElmah()
        //                .AddCustomHealthCheck(Configuration)
        //                .AddSwagger(Configuration);

        //        // Now register our services with Autofac container
        //        var container = new ContainerBuilder();
        //        container.Populate(services);
        //        return new AutofacServiceProvider(container.Build());
        //    }

        //    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        //    public void Configure(IApplicationBuilder app,  ILoggerFactory loggerFactory, IWebHostEnvironment env, IMapper mapper)
        //    {
        //        mapper.ConfigurationProvider.AssertConfigurationIsValid();
        //        if (env.IsDevelopment())
        //        {
        //            app.UseDeveloperExceptionPage();
        //        }
        //        else
        //        {
        //            app.UseHsts();
        //        }


        //        app.UseHealthChecks("/hc", new HealthCheckOptions()
        //        {
        //            Predicate = _ => true,
        //            ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
        //        });

        //        app.UseHealthChecks("/liveness", new HealthCheckOptions
        //        {
        //            Predicate = r => r.Name.Contains("self")
        //        });


        //        app.UseHttpsRedirection();
        //        app.UseRouting();

        //        app.UseStaticFiles();
        //        app.UseAuthentication();

        //        app.UseEndpoints(endpoints =>
        //        {
        //            endpoints.MapControllers();
        //        });

        //        var pathBase = Configuration["PATH_BASE"];

        //        if (!string.IsNullOrEmpty(pathBase))
        //        {
        //            loggerFactory.CreateLogger<Startup>().LogDebug("Using PATH BASE '{pathBase}'", pathBase);
        //            app.UsePathBase(pathBase);
        //        }

        //        app.UseCors("CorsPolicy");
        //        app.UseMvcWithDefaultRoute();
        //        app.UseElmah();

        //        app.UseSwagger()
        //         .UseSwaggerUI(c =>
        //         {
        //             c.SwaggerEndpoint($"{ (!string.IsNullOrEmpty(pathBase) ? pathBase : string.Empty) }/swagger/v1/swagger.json", "Power Pack Online Service API'S V1");
        //         });

        //        app.UseMvc();


        //    }
        //}

        //public static class CustomExtensionMethods
        //{
        //    public static IServiceCollection AddCustomMVC(this IServiceCollection services, IConfiguration configuration)
        //    {
        //        //services.AddMvc(options =>
        //        //{
        //        //    options.Filters.Add(typeof(HttpGlobalExceptionFilter));
        //        //})
        //        //   .SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
        //        //   .AddControllersAsServices();

        //        services.AddCors(options =>
        //        {
        //            options.AddPolicy("CorsPolicy",
        //                builder => builder
        //                .SetIsOriginAllowed((host) => true)
        //                .AllowAnyMethod()
        //                .AllowAnyHeader()
        //                .AllowCredentials());
        //        });

        //        services.Configure<IISOptions>(options =>
        //        {
        //            options.AutomaticAuthentication = false;
        //            options.ForwardClientCertificate = false;
        //        });

        //        return services;
        //    }

        //    public static IServiceCollection AddCustomDbContext(this IServiceCollection services, IConfiguration configuration)
        //    {
        //        //Repository DI configuration
        //        //services.AddTransient<IGradeRepository, GradeRepository>();
        //        //services.AddTransient<ITimeTableRepository, TimeTableRepository>();
        //        //services.AddTransient<IAttendanceRepository, AttendanceRepository>();
        //        //services.AddTransient<IClassListRepository, ClassListRepository>();
        //        //services.AddTransient<IBehaviourRepository, BehaviourRepository>();
        //        //services.AddTransient<IAssessmentRepository, AssessmentRepository>();
        //        //services.AddTransient<ISENRepository, SENRepository>();
        //        //services.AddTransient<ICurriculumRoleRepository, CurriculumRoleRepository>();
        //        //services.AddTransient<IReportsRepository, ReportsRepository>();
        //        //services.AddTransient<IProgressTrackerRepository, ProgressTrackerRepository>();
        //        //services.AddTransient<ISubjectSettingRepository, SubjectSettingRepository>();
        //        //services.AddTransient<ILogInUserRepository, LogInUserRepository>();
        //        //services.AddTransient<IUserRepository, UserRepository>();
        //        //services.AddTransient<IUserPermissionRepository, UserPermissionRepository>();
        //        //services.AddTransient<ISchoolSetupsRepository, SchoolSetupsRepository>();
        //        //services.AddTransient<IProgressTrackerSettingRepository, ProgressTrackerSettingRepository>();
        //        //services.AddTransient<IAssessmentSettingRepository, AssessmentSettingRepository>();
        //        //services.AddTransient<IAttendanceSettingRepository, AttendanceSettingRepository>();
        //        //services.AddTransient<ICommonSettingRepository, CommonSettingRepository>();
        //        ////Services DI Configuration
        //        //services.AddTransient<IGradeService, GradeService>();
        //        //services.AddTransient<ITimeTableService, TimeTableService>();
        //        //services.AddTransient<IAttendanceService, AttendanceService>();
        //        //services.AddTransient<IClassListService, ClassListService>();
        //        //services.AddTransient<IBehaviourService, BehaviourService>();
        //        //services.AddTransient<IAssessmentService, AssessmentService>();
        //        //services.AddTransient<ISENService, SENService>();
        //        //services.AddTransient<ICurriculumRoleService, CurriculumRoleService>();
        //        //services.AddTransient<IReportsService, ReportsService>();
        //        //services.AddTransient<IProgressTrackerService, ProgressTrackerService>();
        //        //services.AddTransient<ISubjectSettingService, SubjectSettingService>();
        //        //services.AddTransient<ILogInUserService, LogInUserService>();
        //        //services.AddTransient<IUserService, UserService>();
        //        //services.AddTransient<IUserPermissionService, UserPermissionService>();
        //        //services.AddTransient<ISchoolSetupsServices, SchoolSetupsServices>();
        //        //services.AddTransient<IProgressTrackerSettingService, ProgressTrackerSettingService>();
        //        //services.AddTransient<IAssessmentSettingService, AssessmentSettingService>();
        //        //services.AddTransient<ICommonSettingService, CommonSettingService>();
        //        //services.AddTransient<IBehaviourSetupService, BehaviourSetupService>();
        //        //services.AddTransient<IBehaviourSetupRepository, BehaviourSetupRepository>();

        //        // User Roles         
        //        //services.AddTransient<IUserRoleRepository, UserRoleRepository>();
        //        //services.AddTransient<IUserRoleService, UserRoleService>();

        //        ////Terminology Editor
        //        //services.AddTransient<ITerminologyEditorRepository, TerminologyEditorRepository>();
        //        //services.AddTransient<ITerminologyEditorService, TerminologyEditorService>();

        //        //// Module Structure
        //        //services.AddTransient<IModuleStructureRepository, ModuleStructureRepository>();
        //        //services.AddTransient<IModuleStructureService, ModuleStructureService>();


        //        //services.AddTransient<IEmailSettingsRepository, EmailSettingsRepository>();
        //        //services.AddTransient<IEmailSettingsService, EmailSettingsService>();

        //        //// School
        //        //services.AddTransient<ISchoolRepository, SchoolRepository>();
        //        //services.AddTransient<ISchoolService, SchoolService>();
        //        ////attendance setting
        //        //services.AddTransient<IAttendanceSettingService, AttendanceSettingService>();

        //        ////Certificate Builder
        //        //services.AddTransient<ICertificateBuilderService, CertificateBuilderService>();
        //        //services.AddTransient<ICertificateBuilderRepository, CertificateBuilderRepository>();

        //        ////DASHBOARD SERVICE AND REPORSITORY
        //        //services.AddTransient<IDashBoardRepository, DashBoardRepository>();
        //        //services.AddTransient<IDashBoardService, DashBoardService>();
        //        //services.AddTransient<IDivisionService, DivisionService>();
        //        //services.AddTransient<IDivisionRepositorycs, DivisionRepository>();

        //        ////User login logs
        //        //services.AddTransient<IUserLoginLogService, UserLoginLogService>();
        //        //services.AddTransient<IUserLoginLogRepository, UserLoginLogRepository>();

        //        ////Application error log
        //        //services.AddTransient<IErrorLoggerService, ErrorLoggerService>();
        //        //services.AddTransient<IErrorLoggerRepository, ErrorLoggerRepository>();


        //        return services;
        //    }

        //    public static IServiceCollection AddSwagger(this IServiceCollection services, IConfiguration configuration)
        //    {
        //        services.AddSwaggerGen(options =>
        //        {
        //            options.DescribeAllEnumsAsStrings();
        //            options.SwaggerDoc("v1", new Swashbuckle.AspNetCore.Swagger.Info
        //            {
        //                Title = "PowerPack Services 2.0 - PowerPack HTTP API",
        //                Version = "v1",
        //                Description = "The PowerPack services HTTP API.",
        //                TermsOfService = "Terms Of Service"
        //            });

        //            options.AddSecurityDefinition("oauth2", new OAuth2Scheme
        //            {
        //                Type = "oauth2",
        //                Flow = "implicit",
        //                AuthorizationUrl = $"{configuration.GetValue<string>("IdentityUrlExternal")}/connect/authorize",
        //                TokenUrl = $"{configuration.GetValue<string>("IdentityUrlExternal")}/connect/token",
        //                Scopes = new Dictionary<string, string>()
        //                {
        //                    { "PowerPack", "PowerPack Service API" }
        //                }
        //            });

        //            options.OperationFilter<AuthorizeCheckOperationFilter>();
        //            options.EnableAnnotations();
        //            var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
        //            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
        //            //      options.IncludeXmlComments(xmlPath);
        //        });

        //        return services;

        //    }

        //    public static IServiceCollection AddCustomOptions(this IServiceCollection services, IConfiguration configuration)
        //    {
        //        //services.Configure<CatalogSettings>(configuration);
        //        services.Configure<ApiBehaviorOptions>(options =>
        //        {
        //            options.InvalidModelStateResponseFactory = context =>
        //            {
        //                var problemDetails = new ValidationProblemDetails(context.ModelState)
        //                {
        //                    Instance = context.HttpContext.Request.Path,
        //                    Status = StatusCodes.Status400BadRequest,
        //                    Detail = "Please refer to the errors property for additional details."
        //                };

        //                return new BadRequestObjectResult(problemDetails)
        //                {
        //                    ContentTypes = { "application/problem+json", "application/problem+xml" }
        //                };
        //            };
        //        });

        //        return services;
        //    }

        //    public static IServiceCollection AddCustomHealthCheck(this IServiceCollection services, IConfiguration configuration)
        //    {
        //        var hcBuilder = services.AddHealthChecks();

        //        hcBuilder
        //            .AddCheck("self", () => HealthCheckResult.Healthy())
        //            .AddSqlServer(
        //                configuration["PowerPackConStr"],

        //                name: "StudentDTO-check",
        //                tags: new string[] { "PowerPackSqlServerStatus" });

        //        return services;
        //    }



        //    public static IServiceCollection AddAuthentication(this IServiceCollection services, IConfiguration configuration)
        //    {
        //        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        //        .AddJwtBearer(options =>
        //        {
        //            options.TokenValidationParameters = new TokenValidationParameters
        //            {
        //                ValidateIssuer = true,
        //                ValidateAudience = true,
        //                ValidateLifetime = true,
        //                ValidateIssuerSigningKey = true,
        //                ValidIssuer = configuration["Jwt:Issuer"],
        //                ValidAudience = configuration["Jwt:Issuer"],
        //                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]))
        //            };
        //        });

        //        return services;
        //    }
        //}
    }
}

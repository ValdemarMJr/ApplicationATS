using ATS.CoreAPI.Business;
using ATS.CoreAPI.Business.Implementations;
using ATS.CoreAPI.Bussiness;
using ATS.CoreAPI.Bussiness.Implementations;
using ATS.CoreAPI.Configurations;
using ATS.CoreAPI.Model.Context;
using ATS.CoreAPI.Repository;
using ATS.CoreAPI.Repository.Implementation;
using ATS.CoreAPI.Services;
using ATS.CoreAPI.Services.Implementation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Net.Http.Headers;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATS.CoreAPI
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
            DbProviderFactories.RegisterFactory("System.Data.SqlClient", System.Data.SqlClient.SqlClientFactory.Instance);
            var tokenConfigurations = new TokenConfiguration();
            new ConfigureFromConfigurationOptions<TokenConfiguration>(Configuration.GetSection("TokenConfiguration")).Configure(tokenConfigurations);
            services.AddSingleton(tokenConfigurations);
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = tokenConfigurations.Issuer,
                    ValidAudience = tokenConfigurations.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenConfigurations.Secret))
                };
            });
            services.AddAuthorization(auth =>
            {
                auth.AddPolicy("Bearer", new AuthorizationPolicyBuilder()
                    .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
                    .RequireAuthenticatedUser()
                    .Build());
            });
            var connection = Configuration.GetConnectionString("ATSDatabase");
            services.AddDbContext<SQLContext>(options => options.UseSqlServer(connection));

            services.AddScoped<IAcademicsEducationBusiness, AcademicEducationBusiness>();
            services.AddScoped<IAddressBusiness, AddressBusiness>();
            services.AddScoped<ICandidateAcademicsEducationBusiness, CandidateAcademicsEducationBusiness>();
            services.AddScoped<ICandidateBusiness, CandidateBusiness>();
            services.AddScoped<ICandidateContactBusiness, CandidateContactBusiness>();
            services.AddScoped<ICandidateExperiencesBusiness, CandidateExperiencesBusiness>();
            services.AddScoped<ICandidateImprovmentCourseBusiness, CandidateImprovmentCourseBusiness>();
            services.AddScoped<ICandidatePersonalReferenceBusiness, CandidatePersonalReferenceBusiness>();
            services.AddScoped<ICandidateRoleBusiness, CandidateRoleBusiness>();
            services.AddScoped<ICityBusiness, CityBusiness>();
            services.AddScoped<ICivilStateBusiness, CivilStateBusiness>();
            services.AddScoped<IContactBusiness, ContactBusiness>();
            services.AddScoped<IContactTypeBusiness, ContactTypeBusiness>();
            services.AddScoped<ICourseSituationBusiness, CourseSituationBusiness>();
            services.AddScoped<IGenderBusiness, GenderBusiness>();
            services.AddScoped<IImprovementCourseBusiness, ImprovementCourseBusiness>();
            services.AddScoped<IJobOpportunityBusiness, JobOpportunityBusiness>();
            services.AddScoped<ILoginBusiness, LoginBussinesImplementation>();
            services.AddScoped<INeighborhoodBusiness, NeighborhoodBusiness>();
            services.AddScoped<IPersonalReferenceBusiness, PersonalReferenceBusiness>();
            services.AddScoped<IPersonalReferenceTypesBusiness, PersonalReferenceTypesBusiness>();
            services.AddScoped<IRoleBusiness, RoleBusiness>();
            services.AddScoped<IStateBusiness, StateBusiness>();
            services.AddScoped<IUserBusiness, UserBussines>();

            services.AddTransient<ITokenService, TokenService>();

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IAcademicEducationRepository, AcademicEducationRespository>();
            services.AddScoped<IAddressRepository, AddressRepository>();
            services.AddScoped<ICandidateAcademicEducationRepository, CandidateAcademicEducationRepository>();
            services.AddScoped<ICandidateContactRepository, CandidateContactRepository>();
            services.AddScoped<ICandidateExperienceRepository, CandidateExperienceRepository>();
            services.AddScoped<ICandidateImprovementCourseRepository, CandidateImprovmentCourseRepository>();
            services.AddScoped<ICandidatePersonalReferenceRepository, CandidatePersonalReferenceRepository>();
            services.AddScoped<ICandidateRepository, CandidateRepository>();
            services.AddScoped<ICandidateRoleRepository, CandidateRoleRepository>();
            services.AddScoped<ICityRepository, CityRepository>();
            services.AddScoped<ICivilStateRepository, CivilStateRepository >();
            services.AddScoped<IContactRepository, ContactRepository>();
            services.AddScoped<IContactTypeRepository, ContactTypeRepository>();
            services.AddScoped<ICourseSituationRepository, CourseSituationRepository>();
            services.AddScoped<IGenderRepository, GenderRepository>();
            services.AddScoped<IImprovementCourseRepository, ImprovementCourseRepository>();
            services.AddScoped<IJobOpportunityRepository, JobOpportunityRepository>();
            services.AddScoped<INeighborhoodRepository, NeighborhoodRepository>();
            services.AddScoped<IPersonalReferenceRepository, PersonalReferenceRepository>();
            services.AddScoped<IPersonalReferenceTypeRepository, PersonalReferenceTypeRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IStateRepository, StateRepository>();
            services.AddScoped<IUserRepository, UserRepository>();

            services.AddCors(option =>
            {
                option.AddDefaultPolicy(builder =>
                {
                    builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
                });
            });
            services.AddControllers(option =>
            {
                option.RespectBrowserAcceptHeader = true;
                option.FormatterMappings.SetMediaTypeMappingForFormat("xml", MediaTypeHeaderValue.Parse("application/xml"));
                option.FormatterMappings.SetMediaTypeMappingForFormat("json", MediaTypeHeaderValue.Parse("application/json"));
            })
          .AddXmlSerializerFormatters();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ATS.CoreAPI", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ATS.CoreAPI v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

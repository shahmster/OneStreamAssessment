using FluentValidation.AspNetCore;
using Leads.Api.Core;
using Leads.Api.Core.Domain.Services;
using Leads.Api.Dtos;
using Leads.Api.Infrastructure.Filters;
using Leads.Api.Infrastructure.MiddleWare;
using Leads.Api.Integration.WebServiceMethod;
using Leads.Api.Integration.WebServiceMethod.Abstractions;
using Leads.Api.Persistence;
using LeadsWebService;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Leads.Api
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
            
            services.AddDbContext<LeadsDbContext>(
                 options => options.UseSqlServer("name=ConnectionStrings:DefaultConnection"));
            services.AddScoped<ILeadsService, LeadService>();
            services.AddScoped<IWebServiceMethod<DialDetails, string>, WebServiceMethod>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(sop=>new ServiceSoapClient(ServiceSoapClient.EndpointConfiguration.ServiceSoap12));

            services.AddControllersWithViews(options => options.Filters.Add(new ApiValidationFilter()))
                .AddFluentValidation(options =>
                {
                    options.RegisterValidatorsFromAssemblyContaining<Startup>()
                    .RunDefaultMvcValidationAfterFluentValidationExecutes = false;

                });

            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseMiddleware<ErrorWrappingMiddleware>();
            if (env.IsDevelopment())
            {
                
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

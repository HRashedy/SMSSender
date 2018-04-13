using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SMSAPI.Data.Context;
using SMSAPI.App.OptionModels;
using SMSAPI.Data.Repositories.SMS;
using SMSAPI.App.Services.SMSsServices;


namespace SMSAPI.Tree
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
            //Server configuration
           services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));


            services.Configure<TwilioConfig>(Configuration.GetSection("TwilioInfo"));
            
            services.AddScoped<DbContext, AppDbContext>();
            services.AddTransient<ISMSsServise, SMSsRepository>();
            services.AddTransient<ISMSsService, SMSsService>();
            //services.AddScoped<ISMSsService, SMSsService>();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}

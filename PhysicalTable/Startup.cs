using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Repository.Context;
using Service.AddNewTable;
using Service.AddValueToDB;
using Service.ShowValueOfTable;
using Validation.AddNewTable;
using Validation.AddValueToDB;

namespace PhysicalTable
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
            services.AddControllersWithViews();
            services.AddDbContext<AppDBContext>(option =>
            option.UseSqlServer(Configuration.GetConnectionString("DBContextConnection")));
            services.AddTransient<IAddtable, AddTable>();
            services.AddTransient<IRepository,Repository.Context.Repository>();
            services.AddTransient<ICheckTableInput, ValidationTable>();
            services.AddTransient<IAddValue, AddValue>();
            services.AddTransient<ICheckValue, CheckValue>();
            services.AddTransient<IShowValue, ShowValue>();




        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env ,AppDBContext context)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            context.Database.EnsureCreated();
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}

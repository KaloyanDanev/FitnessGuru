using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FitnessGuru.Data;
using FitnessGuru.Data.Common;
using FitnessGuru.Models;
using FitnessGuru.Services.DataServices;
using FitnessGuru.Services.Mapping;
using FitnessGuru.Services.Models.Home;
using FitnessGuru.Web.Model.Article;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;    
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using AutoMapper;
using FitnessGuru.Models.Articles;

namespace FitnessGuru.Web
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
            AutoMapperConfig.RegisterMappings(
                typeof(IndexViewModel).Assembly,
                typeof(CreateArticleInputModel).Assembly);

            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddDbContext<FitnessGuruWebContext>(options =>
                options.UseSqlServer(
                    this.Configuration.GetConnectionString("DefaultConnection")));

            services.AddDefaultIdentity<FitnessGuruWebUser>()
                .AddEntityFrameworkStores<FitnessGuruWebContext>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddAutoMapper();


            services.AddScoped(typeof(IRepository<>), typeof(DbRepository<>));
            services.AddScoped<IArticlesService, ArticlesService>();
            services.AddScoped<ICategoriesService, CategoriesService>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, FitnessGuruWebContext context)
        {
            if (!context.Articles.Any())
            {
                for (int i = 0; i < 12; i++)
                {
                    var article = new Article
                    {
                        CategoryId = 1,
                        Content = $"It's an article"
                    };
                    context.Articles.Add(article);
                }

                context.SaveChanges();
            }

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "areas",
                    template: "{area:exists}/{controller=Categories}/{action=Index}/{id?}");

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}

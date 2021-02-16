using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MUT_DataAccess.DataContext;
using MUT_Service.Implementation;
using MUT_Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MUT_SPORT_API
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
            services.AddResponseCompression();
            services.AddDbContext<MUTDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DBConnection"),
                    x => x.MigrationsAssembly("MUT_DataAccess")));

            services.AddScoped<ISportService, SportService>();
            services.AddScoped<IStudentService, StudentService>();
            services.AddScoped<IGameResultService, GameResultsServices>();
            services.AddScoped<IStudentSportService, StudentSportService>();
            services.AddScoped<IEventService, EventService>();
            services.AddScoped<ITrainingSchedule,TrainingService>();
            services.AddScoped<ITeamAchievement, TeamAchievementService>();
            services.AddScoped<IPlayerAchievement,PlayerAchievementService>();
            services.AddScoped<IStudentSportService, StudentSportService>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
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

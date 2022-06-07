using GameWebApi.Database;
using GameWebApi.Models;
using GameWebApi.Repositories;
using GameWebApi.Repositories.Interfaces;
using GameWebApi.Services;
using GameWebApi.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameWebApi
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            // Создание строки подключения
            string connection = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<GameContext>(options =>
                options.UseSqlServer(connection));

            services.AddMvc();

            // Добаление зависимостей
            services.AddTransient<IBaseGameRepository<Game, Category>, GameRepository>();
            services.AddTransient<IBaseGameRepository<Category, Game>, BaseRepository<Category, Game>>();
            services.AddTransient<IGameService, GameService>();

            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

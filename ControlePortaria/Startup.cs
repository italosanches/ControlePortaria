﻿using ControlePortaria.Context;
using ControlePortaria.Repository;
using ControlePortaria.Repository.Interfaces;

//using ControlePortaria.Repository;
//using ControlePortaria.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ControlePortaria;
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
        services.AddDbContext<AppDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"))); //configurando servico de conexao
        services.AddTransient<IPessoaRepository,PessoaRepository>();
        services.AddTransient<ICarroRepository,CarroRepository>();
        services.AddTransient<IPortariaRepository, PortariaRepository>();

        services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

        services.AddControllersWithViews();

        services.AddMemoryCache();//habilitando caache - sessao
        services.AddSession();//habilitando caache - sessao
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
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
        app.UseSession();

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
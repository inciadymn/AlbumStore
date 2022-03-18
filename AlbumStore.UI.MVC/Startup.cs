using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using AlbumStore.BLL.Concrete.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlbumStore.UI.MVC
{
    public class Startup
    {       
        public void ConfigureServices(IServiceCollection services)
        {           
            services.AddControllersWithViews();
            services.AddScopeBLL(); //a�a��dakileri her nesne i�in yazmamak i�in ve dal� using lere referans vermemek i�in AddScoped metotlar�n� BLL ve DAL katman� i�inde yazd�k. Her nesneyi bu sekilde kendi katman�nda newlemi� olduk. Bu BLL deki metottur ve ilk olarak BLL'e yani servise(EFContextBLL class�) gidilmi� olacak, ordan da DAL katman�na(EFContextDAL class�) gidilecek.

            //a�a��daki 3 metot nesne i newler ve bize d�nd�r�r  //�rnek a��klama: Her IAlbumBLL g�r�ld���nde gidip AlbumService newlicek
            //services.AddScoped<IAlbumBLL, AlbumService>(); //istek boyunca ayn� nesneyi verir �u an bunu kullanaca��z //HomeControllerde bunu newlemesini yapt�k
            //services.AddSingleton<IAlbumBLL, AlbumService>();  //bu nesneyi bir kere newlerim ama sana hep ayn� nesneyi d�nerim
            //services.AddTransient<IAlbumBLL, AlbumService>(); //her istekde farkl� nesne veririrm diyor    
            services.AddSession(); //Session i�in bunu startup a yazmak zorundas�n
        }
            
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSession();
            app.UseRouting();
            app.UseStaticFiles();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}

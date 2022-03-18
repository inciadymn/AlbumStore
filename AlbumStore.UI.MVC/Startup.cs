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
            services.AddScopeBLL(); //aþaðýdakileri her nesne için yazmamak için ve dalý using lere referans vermemek için AddScoped metotlarýný BLL ve DAL katmaný içinde yazdýk. Her nesneyi bu sekilde kendi katmanýnda newlemiþ olduk. Bu BLL deki metottur ve ilk olarak BLL'e yani servise(EFContextBLL classý) gidilmiþ olacak, ordan da DAL katmanýna(EFContextDAL classý) gidilecek.

            //aþaðýdaki 3 metot nesne i newler ve bize döndürür  //Örnek açýklama: Her IAlbumBLL görüldüðünde gidip AlbumService newlicek
            //services.AddScoped<IAlbumBLL, AlbumService>(); //istek boyunca ayný nesneyi verir þu an bunu kullanacaðýz //HomeControllerde bunu newlemesini yaptýk
            //services.AddSingleton<IAlbumBLL, AlbumService>();  //bu nesneyi bir kere newlerim ama sana hep ayný nesneyi dönerim
            //services.AddTransient<IAlbumBLL, AlbumService>(); //her istekde farklý nesne veririrm diyor    
            services.AddSession(); //Session için bunu startup a yazmak zorundasýn
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

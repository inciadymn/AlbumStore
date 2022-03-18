using Microsoft.Extensions.DependencyInjection;
using AlbumStore.BLL.Abstract;
using AlbumStore.BLL.Concrete;
using AlbumStore.DAL.Concrete.DependencyInjection;

namespace AlbumStore.BLL.Concrete.DependencyInjection
{
    public static class EFContextBLL
    {
        //extension Metot : burdaki class da, metot da statik olmak zorunda. Burayı (this IServiceCollection services) için yazdık ve services ı istediğimiz yerde kullanıyoruz. Startup da direk services.AddScopedBLL() yaptık ve buraya geldi işlem sırası burdan da DAL katmanına gidecek
        public static void AddScopeBLL(this IServiceCollection services)
        {
            //istediğim classları burda newlemiş oldum  //startup a yazsaydık dal ı referens vermiş olacaktık ve bunu istemiyoruz. o yüzden kendi katmanı içinde bunu yaptık

            services.AddScopeDAL(); //bununla Dal a gidiyor ordan repostory leri newliyoruz
            services.AddScoped<IAlbumBLL, AlbumService>();
            services.AddScoped<IArtistBLL, ArtistService>();
            services.AddScoped<IUserBLL, UserService>();
            services.AddScoped<IGenreBLL, GenreService>();
            services.AddScoped<IOrderBLL, OrderService>();
        }
    }
}

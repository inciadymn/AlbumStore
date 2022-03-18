using Microsoft.Extensions.DependencyInjection;
using AlbumStore.DAL.Abstract;
using AlbumStore.DAL.Concrete.Context;
using AlbumStore.DAL.Concrete.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlbumStore.DAL.Concrete.DependencyInjection
{
    public static class EFContextDAL
    {
        //istediğim classları burda newlemiş oldum  //startup a yazsaydık dal ı referens vermiş olacaktık ve bunu istemiyoruz. o yüzden kendi katmanı içinde bunu yaptık

        public static void AddScopeDAL(this IServiceCollection services)
        {
            services.AddDbContext<AlbumStoreDbContext>();
            services.AddScoped<IAlbumDAL, AlbumRepository>(); //ctor da her IAlbumDAL'ı gördüğünde git AlbumRepository classını newle
            services.AddScoped<IArtistDAL, ArtistRepository>();
            services.AddScoped<IGenreDAL, GenreRepository>();
            services.AddScoped<IOrderDAL, OrderRepository>();
            services.AddScoped<IUserDAL, UserRepository>();
        }
    }
}

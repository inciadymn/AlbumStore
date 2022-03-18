using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace AlbumStore.Core.DataAccess.EntityFramework
{
    public static class QuerableExtension //statik yaparak istediğim yerde çağırdım
    {
        //efRepostoryBase i besliyor burası

        public static IQueryable<T> MyInclude<T>(this IQueryable<T> query, params Expression<Func<T, object>>[] includes)
            where T : class
        {
            if (includes != null)  //yani bir navi. prop um varsa  //includes parametresi benim için bir navi. prop udur
            {
                query = includes.Aggregate(query, (a, b) => a.Include(b)); //mesela burda a=genre olur, b=artist(navi. prop) olur yani includes dizinin elemanlarıdır, ve bu işlem bana albumu her getirdiğinde artist ve genre navi. prop sinide dolu getirir anlamlı getirir. Burdaki query=context.Albums dür
            }
            return query;
        }
    }


    //includes = {a=>a.Artist, a=>a.Genre}  bu oluyor
    //seed(query) = context.Albums  bu oluyor

    //Aggregate metodu sırayla aşağıdaki işlemleri yapıyor
    //query= context.Albums.Include(a=>a.Artist)
    //context.Albums.Include(a=>a.Artist).Include(a=>a.Genre);  ///eğer bir navi. prop u da olsaydı onuda eklerdi sonraki işlemde

}

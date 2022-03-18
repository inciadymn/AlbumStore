using Microsoft.EntityFrameworkCore;
using AlbumStore.Core.DataAccess;
using AlbumStore.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;


namespace AlbumStore.Core.DataAccess.EntityFramework
{
    //EF'de bu işler şöyle yapılıyor(yani EntityFramework de işler böyle yapılıyor)

    public class EFRepositoryBase<TEntity, TContext> : IRepository<TEntity>
        where TEntity : BaseEntity
        where TContext : DbContext
    {
        TContext context;
        public EFRepositoryBase(TContext context)
        {
            this.context = context;
        }

        public TEntity Add(TEntity entity)
        {
            //context.Albums.Add(album);
            //context.SaveChanges(); bu 2sinin generik hali aşağıdakidir
            context.Entry(entity).State = EntityState.Added; //burda gönderilecek entity nesnesinin State i add oluyor
            if (context.SaveChanges() > 0)
            {
                return entity; //bu if içersine girmişse database e added olmuştur entity ve bende return bu entity i dönüyorum
            }
            return null;
        }
        public TEntity Update(TEntity entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            if (context.SaveChanges() > 0)
            {
                return entity;
            }
            return null;
        }
        public int Remove(TEntity entity)
        {
            context.Entry(entity).State = EntityState.Deleted;
            return context.SaveChanges();
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter, params Expression<Func<TEntity, object>>[] includes)
        {
            //context.Albums.Where(a=>a.IsActive).Include(a=>a.Artist).SingleOrDefault();
            return context.Set<TEntity>().Where(filter).MyInclude(includes).SingleOrDefault();
        }

        public ICollection<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null, params Expression<Func<TEntity, object>>[] includes)
        {
            if (filter == null)
            {
                return context.Set<TEntity>().MyInclude(includes).ToList();//burada "context.Set<TEntity>()" = "context.Album" e eşittir. //"MyInclude(includes)"= "a=>a.Artist" (artist album içindeki navi. prop u dur) Include ile bir class içindeki navi. prop. u dolu gelmiş oluyor
            }
            else //eğer ekstra bir Where şartı geldiyse onun için aşağıdakini uygula
            {
                return context.Set<TEntity>().Where(filter).MyInclude(includes).ToList();
            }
        }
    }
}

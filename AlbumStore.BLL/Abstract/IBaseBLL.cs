
using AlbumStore.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlbumStore.BLL.Abstract
{
    public interface IBaseBLL<TEntity>
        where TEntity : BaseEntity
    {
        //burdaki metotlar her BLL interface i için olacak olan metotlar baseBLL burası. Eğer BLL e özel metot olacak ise onu Kendi IAlbumBLL yada diğer ait olan nesne içinde yazarsın. Örnek olarak IAlbumBLL e yazılan GetSingleAlbums(); albümü

        //TEntity Insert(TEntity entity);
        //TEntity Update(TEntity entity);
        //int Delete(TEntity entity);
        //int DeleteByID(int entityID);
        //TEntity Get(int entityID);
        //ICollection<TEntity> GetAll();

    }
}

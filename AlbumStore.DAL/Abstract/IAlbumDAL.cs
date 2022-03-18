using AlbumStore.Core.DataAccess;
using AlbumStore.Model.Entities;

namespace AlbumStore.DAL.Abstract
{
    public interface IAlbumDAL : IRepository<Album>
    {
    }
}

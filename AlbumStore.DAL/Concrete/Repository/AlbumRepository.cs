using AlbumStore.Core.DataAccess.EntityFramework;
using AlbumStore.DAL.Abstract;
using AlbumStore.DAL.Concrete.Context;
using AlbumStore.Model.Entities;

namespace AlbumStore.DAL.Concrete.Repository
{
    class AlbumRepository : EFRepositoryBase<Album, AlbumStoreDbContext>, IAlbumDAL
    {
        public AlbumRepository(AlbumStoreDbContext context) : base(context)
        {
        }       
    }
}

using AlbumStore.Core.DataAccess.EntityFramework;
using AlbumStore.DAL.Abstract;
using AlbumStore.DAL.Concrete.Context;
using AlbumStore.Model.Entities;

namespace AlbumStore.DAL.Concrete.Repository
{
    class GenreRepository : EFRepositoryBase<Genre, AlbumStoreDbContext>, IGenreDAL
    {
        public GenreRepository(AlbumStoreDbContext context) : base(context)
        {
        }
    }
}

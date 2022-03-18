using AlbumStore.Core.DataAccess.EntityFramework;
using AlbumStore.DAL.Abstract;
using AlbumStore.DAL.Concrete.Context;
using AlbumStore.Model.Entities;

namespace AlbumStore.DAL.Concrete.Repository
{
    class OrderRepository : EFRepositoryBase<Order, AlbumStoreDbContext>, IOrderDAL
    {
        public OrderRepository(AlbumStoreDbContext context) : base(context)
        {
        }
    }
}

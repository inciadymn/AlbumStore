using AlbumStore.Core.DataAccess.EntityFramework;
using AlbumStore.DAL.Abstract;
using AlbumStore.DAL.Concrete.Context;
using AlbumStore.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlbumStore.DAL.Concrete.Repository
{
    class UserRepository : EFRepositoryBase<User, AlbumStoreDbContext>, IUserDAL
    {
        public UserRepository(AlbumStoreDbContext context) : base(context)
        {
        }
    }
}

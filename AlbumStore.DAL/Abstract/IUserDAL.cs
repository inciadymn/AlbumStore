using AlbumStore.Core.DataAccess;
using AlbumStore.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlbumStore.DAL.Abstract
{
    public interface IUserDAL:IRepository<User>
    {
    }
}

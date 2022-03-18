using AlbumStore.BLL.Concrete.ResultServiceBLL;
using AlbumStore.Model.Entities;
using AlbumStore.ViewModel.UserViewModels;
using System;

namespace AlbumStore.BLL.Abstract
{
    public interface IUserBLL : IBaseBLL<User>
    {
        ResultService<UserCreateVM> Insert(UserCreateVM user);
        ResultService<bool> ActivedUser(Guid guid);
        ResultService<bool> CheckUserForLogin(string email, string password);
    }
}

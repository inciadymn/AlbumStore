using AlbumStore.BLL.Concrete.ResultServiceBLL;
using AlbumStore.Model.Entities;
using AlbumStore.ViewModel.AlbumViewModels;
using AlbumStore.ViewModel.CartViewModels;
using System.Collections.Generic;

namespace AlbumStore.BLL.Abstract
{
    public interface IAlbumBLL : IBaseBLL<Album>
    {
        ResultService<List<SingleAlbumVM>> GetSingleAlbums(); //AlbumServisteki metodu burda imzasını aldık  //albumServicede içini doldurcaz
        ResultService<AlbumDetailVM> GetAlbumById(int id);
        ResultService<CartItem> GetCartById(int id);
    }
}

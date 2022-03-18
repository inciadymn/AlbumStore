using AlbumStore.BLL.Abstract;
using AlbumStore.BLL.Concrete.ResultServiceBLL;
using AlbumStore.DAL.Abstract;
using AlbumStore.Model.Entities;
using AlbumStore.ViewModel.AlbumViewModels;
using AlbumStore.ViewModel.CartViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlbumStore.BLL.Concrete
{
    public class AlbumService : IAlbumBLL
    {
        IAlbumDAL albumDAL;
        public AlbumService(IAlbumDAL albumDAL)
        {
            this.albumDAL = albumDAL; //burada DAL ı yazıyorsan bunu gidip sturtup da yazmazsın çünkü dal ve uı birbirine referans olmamalı 
            //bunu burda newlemiş oluyorsun be db ile ilişki kurarken kullanmam gereken metotları bu sayede kullanıyorum
        }

        public ResultService<AlbumDetailVM> GetAlbumById(int id)
        {
            ResultService<AlbumDetailVM> result = new ResultService<AlbumDetailVM>();
            Album album = albumDAL.Get(a => a.ID == id && a.Continued && a.IsActive, a => a.Artist, a => a.Genre);
            if (album == null)
            {
                result.AddError("Null Hatası", "id ile uyumlu Album yok");
                return result;
            }
            result.Data = new AlbumDetailVM()
            {
                ID = album.ID,
                Title = album.Title,
                GenreName = album.Genre.Name,
                ArtistFullName = album.Artist.FullName,
                Discount = album.Discount,
                AlbumArtUrl = album.AlbumArtUrl,
                Price = album.Price
            };
            return result;
        }

        public ResultService<CartItem> GetCartById(int id)
        {
            ResultService<CartItem> result = new ResultService<CartItem>();
            Album album = albumDAL.Get(a => a.ID == id && a.Continued && a.IsActive);
            if (album == null)
            {
                result.AddError("Null Hatası", "id ile uyumlu Album yok");
                return result;
            }
            result.Data = new CartItem()
            {
                ID = album.ID,
                Title = album.Title,
                Discount = album.Discount,
                Price = album.Price
            };
            return result;
        }

        public ResultService<List<SingleAlbumVM>> GetSingleAlbums()
        {
            ResultService<List<SingleAlbumVM>> resultService = new ResultService<List<SingleAlbumVM>>();
            try
            {
                List<SingleAlbumVM> singleAlbums = albumDAL.GetAll(a => a.IsActive && a.Continued, a => a.Artist, a => a.Genre)
                        .OrderByDescending(a => a.CreatedDate).Take(12)
                        .Select(album => new SingleAlbumVM
                        {
                            ID = album.ID,
                            FullName = album.Artist.FullName,
                            AlbumArtUrl = album.AlbumArtUrl,
                            Price = album.Price,
                            Title = album.Title
                        }).ToList();
                resultService.Data = singleAlbums; //bir hata oluşmadıgı için ve bir albüm listesi bana döndüğü için bunu gidip data sına ekliyorum.
            }
            catch (Exception ex)
            {
                resultService.AddError("exception", ex.Message);
            }

            return resultService;
        }
    }
}

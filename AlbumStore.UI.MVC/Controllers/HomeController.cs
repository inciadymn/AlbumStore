using Microsoft.AspNetCore.Mvc;
using AlbumStore.BLL.Abstract;
using AlbumStore.BLL.Concrete.ResultServiceBLL;
using AlbumStore.ViewModel.AlbumViewModels;
using AlbumStore.ViewModel.Constraints;
using System.Collections.Generic;

namespace AlbumStore.UI.MVC.Controllers
{
    public class HomeController : Controller
    {
        //IAlbumBLL albumService=new AlbumService();  //artık bunu yapmıyoruz aşağıdakileri yaprıyoruz core da 

        //Bu aşağıda yapılan Dependency Injection'dır
        //SOLID => D =>Dependency Inversion 
        //Dependency Injection Pattern 
        //Ctor da eğer newleme yapılacaksak aşağıdaki yöntemi uyguluyoruz artık

        IAlbumBLL albumService;  //soyutu kullanıyoruz burda //bu nesneyi bana core üretecek ve bunu nasıl üreteceğini startup.cs dosyasında services.AddScoped<IAlbumBLL, AlbumService>(); yazıyorsun ve nasıl üreteceğini söylemiş oluyorsun. Burda demiş oluyorsun ki ctorda her IAlbum ü gördüğünde benim için AlbumServices ı newle demiş oluyoruz. Bu şekilde AlbumServices ı kullanmış oluyorum. Daha sonra ilgili katmanda bu nesnelerin hepsini newlicez bi kerede startup da yapmıcaz

        public HomeController(IAlbumBLL albumService) //burdaki nesnenin ne olacağı ve nasıl newleneceğini startup da yazdık
        {
            this.albumService = albumService;
        }

        //IAlbumBLL albumservice = new AlbumService();
        public IActionResult Index()
        {
            ResultService<List<SingleAlbumVM>> albumResult = albumService.GetSingleAlbums();
            if (!albumResult.HasError)
            {
                return View(albumResult.Data);
            }
            else
            {
                ViewBag.Message = albumResult.Errors[0].ErrorMessage;
                return View();
            }
        }

        public IActionResult AlbumDetail(int id)
        {
            ResultService<AlbumDetailVM> result = albumService.GetAlbumById(id);
            if (result.HasError) 
            {
                ViewBag.Message = AlbumMessage.idHatasi;
                return View();
            }         
            return View(result.Data);
        }
        public IActionResult AlbumStore()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }
    }
}

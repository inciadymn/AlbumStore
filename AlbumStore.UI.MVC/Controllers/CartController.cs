using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlbumStore.UI.MVC.Helpers;
using AlbumStore.BLL.Abstract;
using AlbumStore.BLL.Concrete;
using AlbumStore.BLL.Concrete.ResultServiceBLL;
using AlbumStore.ViewModel.CartViewModels;
using AlbumStore.ViewModel.Constraints;

namespace AlbumStore.UI.MVC.Controllers
{
    public class CartController : Controller
    {
        IAlbumBLL albumService;
        public CartController(IAlbumBLL albumService)
        {
            this.albumService = albumService;
        }

        public IActionResult Index() //Sepet Sayfası 
        {
            Cart cart = HttpContext.Session.Get<Cart>("cart");
            if (cart == null)
            {
                ViewBag.Message = CartMessage.CartBosHatasi;
                return View();
            }
            return View(cart);
        }

        public IActionResult AddToCart(int id)
        {
            Cart cart = HttpContext.Session.Get<Cart>("cart");
            if (cart == null)
            {
                cart = new Cart();
            }

            ResultService<CartItem> result = albumService.GetCartById(id);
            if (!result.HasError)
            {
                CartItem item = result.Data;
                item.Quantity = 1;
                cart.Add(item);
                HttpContext.Session.Set<Cart>("cart", cart);
            }
            return PartialView("_cartButton", cart.TotalQuantity);
        }

        public IActionResult UpdateToCart(int id, short quantity)
        {
            Cart cart = HttpContext.Session.Get<Cart>("cart");
            cart.Update(id, quantity);
            HttpContext.Session.Set<Cart>("cart", cart);
            return PartialView("_cartTable", cart);
        }
        public IActionResult DeleteToCart(int id)
        {
            Cart cart = HttpContext.Session.Get<Cart>("cart");
            cart.Delete(id);
            HttpContext.Session.Set<Cart>("cart", cart);
            return PartialView("_cartTable", cart);
        }

    }
}

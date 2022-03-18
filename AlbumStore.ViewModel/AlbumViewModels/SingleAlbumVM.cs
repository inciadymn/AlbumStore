using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlbumStore.ViewModel.AlbumViewModels
{
    //bu benim dataTransferim
    //modelden gelenler olacaklar isimleri aynı olmalıdır(prop isimleri modelle aynı olmalı). Model katmanındaki Enteties ler ile aynı olmalı
    //burayı UI tarafına göndereceğim
    //eğer db den veri alıp listeleyeceksen dataanataions yaparsın , ama kullanıcıdan veri alıp kaydediceksen datananations a gerek yok

    public class SingleAlbumVM
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public string FullName { get; set; }
        public string AlbumArtUrl { get; set; }
    }
}

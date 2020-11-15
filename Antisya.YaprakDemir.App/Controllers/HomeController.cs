using Antisya.YaprakDemir.ComplexType;
using Antisya.YaprakDemir.Dto;
using Antisya.YaprakDemir.Entity.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Antisya.YaprakDemir.App.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            YdSatisAppContext _context = new YdSatisAppContext();
            //Veritabanından Musteriler tablosundan verileri alıp MusteriTableDto Aktardım Liste döndurdum
            List<MusteriTableDto> Model = _context.MusteriTable.Select(r => new MusteriTableDto { MusteriAdi = r.MusteriAdi }).ToList();
            //Veritabanından urunler tablosundan verileri alıp UrunTableDto Aktardım Liste döndurdum
            List<UrunTableDto> Urunler = _context.UrunTable.Select(r => new UrunTableDto { UrunAdi = r.UrunAdi }).ToList();
            //Viewde  musteriler ve urunleri kullanmak için bir viewModel (MusteriUrunViewModel class) oluşturdum içindeki propertylere modelleri verdim
            MusteriUrunViewModel musteriUrunViewModel = new MusteriUrunViewModel
            {
                MusteriListesi = Model,
                UrunListesi = Urunler
            };
            return View(musteriUrunViewModel);
        }


    }
}

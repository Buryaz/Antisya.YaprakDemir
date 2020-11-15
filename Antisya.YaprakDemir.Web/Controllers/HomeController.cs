using Antisya.YaprakDemir.ComplexType;
using Antisya.YaprakDemir.Dto;
using Antisya.YaprakDemir.Entity.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Antisya.YaprakDemir.Web.Controllers
{
    public class HomeController : Controller
    {
        YdSatisAppContext _context = new YdSatisAppContext();

        public IActionResult Index()
        {
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




        [HttpPost]
        public JsonResult MusteriEkle(MusteriTableDto musteri)
        {
            try
            {

                MusteriTable musteriTable = new MusteriTable
                {
                    MusteriAdi = musteri.MusteriAdi,
                    IletisimNumarasi = null,
                    MusteriAdresi = null,
                    VergiDairesi = musteri.VergiDairesi,
                    VergiNo = musteri.VergiNo
                };
                _context.MusteriTable.Add(musteriTable);
                _context.SaveChanges();
                return Json(new Result { Success = true });

            }
            catch (System.Exception)
            {
                return Json(new Result { Success = false });
            }
        }


    }
    public class Result
    {
        public bool Success { get; set; }
    }
}

using Microsoft.AspNetCore.Mvc;
using profdeneme_mustafaDev_migrationsCrud.Models;
using System.Diagnostics;

namespace profdeneme_mustafaDev_migrationsCrud.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly mydbcontext _context;

        public HomeController(ILogger<HomeController> logger, mydbcontext context)
        {
            _logger = logger;
            _context = context;
        }

        //kitap silme işleminde görünüm kısmı olarakta kullanılıyor
        //kitaplar listeleniyor
        public IActionResult Index()
        {
            return View();
        }

        //sayfa methodu - kitap ekle
        public IActionResult kitapekle()
        {

            return View();
        }

        //kitap eklemeyi post ettiğimiz yer
        [HttpPost]
        public IActionResult kitapeklework(kitap kitap)
        {
            try
            {
                _context.kitap!.Add(kitap);
                _context.SaveChanges();
            }
            catch (Exception exx)
            {
                ViewBag.kitapeklehata = "kitap eklenirken hata oluştu.";
                // throw;
            }

            return RedirectToAction("Index");
        }

        //eklenen kitabı silme
        public IActionResult sil(int id)
        {
            var remove = _context.kitap!.FirstOrDefault(x => x.id == id);
            _context.kitap!.Remove(remove!);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        //duzenle sayfası gorunum için
        public IActionResult duzenle(int id)
        {
            return View(_context.kitap!.Find(id));
        }

        [HttpPost]
        //duzenleme sayfası - çalışma alanı
        public IActionResult duzenlework(kitap kitap)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.kitap.Update(kitap);
                    _context.SaveChanges();
                }
                catch (Exception)
                {
                    ViewBag.duzenlehata = "düzenleme yaparken hata ile karşılaşıldı";
                    //throw;
                }
            }
            return RedirectToAction("Index");
        }

        //kitap detaylarını görmek için gerekli kodlar
        public IActionResult detay(int id)
        {
            var kitapdetay = _context.kitap.FirstOrDefault(x => x.id == id);
            return View(kitapdetay);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
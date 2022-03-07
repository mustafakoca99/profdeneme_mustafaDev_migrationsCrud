using Microsoft.AspNetCore.Mvc;
using profdeneme_mustafaDev_migrationsCrud.Models;

namespace profdeneme_mustafaDev_migrationsCrud.Controllers
{
    public class YazarController : Controller
    {
        //context eklemesi
        protected readonly mydbcontext _context;
        public YazarController(mydbcontext context)
        {
            _context = context;
        }
        //yazarlar listelenir
        public IActionResult Index()
        {
            return View();
        }
        //yazar ekleme görünüm alanı
        public IActionResult yazarekle()
        {
            return View();
        }
        //yazar ekle work- çalışma alanı
        [HttpPost]
        public IActionResult yazareklework(yazar yazar)
        {
            try
            {
                _context.yazar.Add(yazar);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                ViewBag.yazareklehata = "yazar eklemesi yaparken hata oluştu";
               // throw;
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult duzenle(int id)
        {
            return View(_context.yazar.Find(id));
        }
        [HttpPost]
        public IActionResult duzenlework(yazar yazar)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.yazar!.Update(yazar);
                    _context.SaveChanges();
                }
                catch (Exception)
                {
                    ViewBag.duzenlehata = "düzenleme yapılırken bir hata oluştu";
                    //throw;
                }
            }
            return RedirectToAction("Index");
        }

        public IActionResult detay(int id)
        {var detayazar=_context.yazar!.FirstOrDefault(x => x.id == id);
            
            return View(detayazar);
        }
        public IActionResult sil(int id)
        {
            var removeyazar = _context.yazar!.FirstOrDefault(r=>r.id ==id);
            _context.yazar!.Remove(removeyazar!);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}

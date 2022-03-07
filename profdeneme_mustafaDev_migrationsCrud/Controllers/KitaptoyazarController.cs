using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using profdeneme_mustafaDev_migrationsCrud.Models;
using System.Data.Entity;

namespace profdeneme_mustafaDev_migrationsCrud.Controllers
{
    public class KitaptoyazarController : Controller
    {
        protected readonly mydbcontext _context;
        public KitaptoyazarController(mydbcontext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var mydbcontext= _context.kitaptoyazar.Include(y=>y.kitaplar).Include(y=>y.yazarlar);
            return View(mydbcontext.ToList());
        }
        
        public async Task<IActionResult> Details(int id)
        {
            var yazartokitap= _context.kitaptoyazar.Include(x=>x.kitaplar).Include(_ =>_.yazarlar).FirstOrDefault(m=>m.id==id);
            
            return View(yazartokitap);
        }

        public async Task<IActionResult> create()
        {
            ViewData["kitapf_id"] = new SelectList(_context.kitap, "id", "kitapadi");
            ViewData["yazarf_id"] = new SelectList(_context.yazar, "id", "yazaradi");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> creatework([Bind("id,kitapf_id,yazarf_id")] kitaptoyazar kitaptoyazar)
        {
            _context.Add(kitaptoyazar);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
            ViewData["kitapf_id"] = new SelectList(_context.kitap, "id", "kitapadi", kitaptoyazar.kitapf_id);
            ViewData["yazarf_id"] = new SelectList(_context.yazar, "id", "yazaradi", kitaptoyazar.yazarf_id);
            return View(kitaptoyazar);
        }
    }
}

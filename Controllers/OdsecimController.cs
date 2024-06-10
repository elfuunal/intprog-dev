using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using intprogödev.Models.Data;
using intprogödev.Models;
using System.Threading.Tasks;

namespace Okul.Mvc.Controllers
{
    public class OdSecimController : Controller
    {
        private readonly OgrenciDbContext _context;

        public OdSecimController(OgrenciDbContext context)
        {
            _context = context;
        }


        // GET: /OgrDersSec/Index
        public IActionResult Index()
        {
            var ogrenciler = _context.Ogrenciler.ToList();
            var dersler = _context.Dersler.ToList();

            ViewBag.Ogrenciler = ogrenciler;
            ViewBag.Dersler = dersler;

            return View();
        }

        // POST: /OgrDersSec/Index
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(int? ogrenciId, int? dersId)
        {
            if (ogrenciId == null || dersId == null)
            {
                // Eksik parametreler durumunda hata mesajı gösterme
                ModelState.AddModelError(string.Empty, "Öğrenci ve ders seçimi gereklidir.");
                return View();
            }

            var ogrenci = await _context.Ogrenciler.FirstOrDefaultAsync(o => o.Id == ogrenciId);
            var ders = await _context.Dersler.FirstOrDefaultAsync(d => d.Id == dersId);

            if (ogrenci == null || ders == null)
            {
                // Seçilen öğrenci veya ders bulunamazsa hata mesajı gösterme
                ModelState.AddModelError(string.Empty, "Seçilen öğrenci veya ders bulunamadı.");
                return View();
            }

            var existingEntry = await _context.OgrenciDersler.FirstOrDefaultAsync(od => od.OgrenciId == ogrenciId && od.DersId == dersId);
            if (existingEntry != null)
            {
                // Aynı öğrenci ve ders zaten eklenmişse hata mesajı gösterme
                ModelState.AddModelError(string.Empty, "Bu öğrenci zaten bu dersi seçmiş.");
                return View();
            }

            var yeniKayit = new OgrenciDers { Ogrenciler = ogrenci, Ders = ders };
            _context.Add(yeniKayit);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index), "Home"); // Index sayfasına değil, anasayfaya yönlendirme
        }
    }
}

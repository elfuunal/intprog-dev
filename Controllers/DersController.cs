using intprogödev.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using intprogödev.Models.Data;

namespace intprogödev.Controllers
{
    public class DersController : Controller
    {
        public IActionResult Index()
        {
            using (var ctx = new OgrenciDbContext())
            {
                var lst = ctx.Dersler.ToList();
                return View(lst);
            }
        }

        public IActionResult AddDers()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddDers(Ders ders)
        {
            if (ders != null)
            {
                using (var ctx = new OgrenciDbContext())
                {
                    ctx.Dersler.Add(ders);
                    ctx.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }

        public IActionResult EditDers(int Dersid)
        {
            using (var ctx = new OgrenciDbContext())
            {
                var ders = ctx.Dersler.Find(Dersid);
                return View(ders);
            }
        }

        [HttpPost]
        public IActionResult EditDers(Ders ders)
        {
            if (ders != null)
            {
                using (var ctx = new OgrenciDbContext())
                {
                    ctx.Entry(ders).State = EntityState.Modified;
                    ctx.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }

        public IActionResult DeleteDers(int id)
        {
            try
            {
                using (var ctx = new OgrenciDbContext())
                {
                    var ders = ctx.Dersler.Find(id);
                    if (ders == null)
                    {
                        // Ders bulunamadıysa, ana sayfaya yönlendir
                        return RedirectToAction("Index");
                    }

                    ctx.Dersler.Remove(ders);
                    ctx.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                // Hata durumunda ana sayfaya yönlendir
                return RedirectToAction("Index");
            }

            // Başarıyla silindiğinde ana sayfaya yönlendir
            return RedirectToAction("Index");
        }
        public IActionResult AddDersForStudent(int studentId, OgrenciDbContext context)
        {
            ViewBag.OgrenciId = studentId;
            return View();
        }

        [HttpPost]
        public IActionResult AddDersForStudent(Ders ders, int studentId, OgrenciDbContext context)
        {
            if (ModelState.IsValid)
            {
                context.Dersler.Add(ders);
                context.SaveChanges();
                return RedirectToAction("Index", new { id = studentId });
            }
            return View(ders);
        }
    }

}


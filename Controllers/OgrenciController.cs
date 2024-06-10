using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using intprogödev.Models;
using intprogödev.Models.Data;

namespace intprogödev.Controllers
{
    public class OgrenciController : Controller
    {
        public IActionResult Index()
        {
            using (var ctx = new OgrenciDbContext())
            {
                var lst = ctx.Ogrenciler.ToList();
                return View(lst);
            }
        }
        public IActionResult AddOgrenci()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddOgrenci(Ogrenci ogr)
        {
            if (ogr != null)
            {
                using (var ctx = new OgrenciDbContext())
                {
                    ctx.Ogrenciler.Add(ogr);
                    ctx.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }
        public IActionResult EditOgrenci(int id)

        {
            using (var ctx = new OgrenciDbContext())
            {
                var ogr = ctx.Ogrenciler.Find(id);
                return View(ogr);
            }
        }
        [HttpPost]
        public IActionResult EditOgrenci(Ogrenci ogr)
        {
            if (ogr != null)
            {
                using (var ctx = new OgrenciDbContext())
                {
                    ctx.Entry(ogr).State = EntityState.Modified;
                    ctx.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }

      
      
        public IActionResult DeleteStudent(int id)
        {
            try
            {
                using (var ctx = new OgrenciDbContext())
                {
                    var student = ctx.Ogrenciler.Find(id);
                    if (student == null)
                    {
                       
                        return RedirectToAction("Index");
                    }

                    ctx.Ogrenciler.Remove(student);
                    ctx.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models.Entity;
namespace MvcKutuphane.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori
        DBKUTUPHANEEntities db = new DBKUTUPHANEEntities();
        public ActionResult Index()
        {
            var degerler=db.TBLKategori.ToList();
            return View(degerler);

        }
        [HttpGet]
        public ActionResult KategoriEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult KategoriEkle(TBLKategori p)
        {
            db.TBLKategori.Add(p);
            db.SaveChanges();
            return View();
        }
        public ActionResult KategoriSil(int id)
        {
            var kategori = db.TBLKategori.Find(id);
            db.TBLKategori.Remove(kategori);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult KategoriGetir(int id)
        {
            var ktg=db.TBLKategori.Find(id);
            return View("KategoriGetir",ktg);
        }
        public ActionResult KategoriGuncelle(TBLKategori p)
        {
            var ktg = db.TBLKategori.Find(p.ID);
            ktg.ADI = p.ADI;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
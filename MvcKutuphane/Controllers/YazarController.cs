using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models.Entity;
namespace MvcKutuphane.Controllers
{
    public class YazarController : Controller
    {
        // GET: Yazar
        DBKUTUPHANEEntities db = new DBKUTUPHANEEntities();
        public ActionResult Index()
        {
            var degerler = db.TBLyazar.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YazarEkle()
        {
            return View();
        }


        public ActionResult YazarEkle(TBLyazar p)
        {
            db.TBLyazar.Add(p);
            db.SaveChanges();
            return View();
        }
        public ActionResult YazarSil(int id)
        {
            var yazar = db.TBLyazar.Find(id);
            db.TBLyazar.Remove(yazar);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult YazarGetir(int id)
        {
            var yzr = db.TBLyazar.Find(id);
            return View("YazarGetir", yzr);
        }
        public ActionResult YazarGuncelle(TBLyazar p)
        {
            var yzr = db.TBLyazar.Find(p.ID);
            yzr.AD = p.AD;
            yzr.SOYAD = p.SOYAD;
            yzr.DETAY = p.DETAY;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
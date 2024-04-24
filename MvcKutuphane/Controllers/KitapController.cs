using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models.Entity;
namespace MvcKutuphane.Controllers
{
    public class KitapController : Controller
    {
        // GET: Kitap
        DBKUTUPHANEEntities db = new DBKUTUPHANEEntities();
        public ActionResult Index(string p)
        {
            var kitaplar = from k in db.TBLKİTAP select k;
            if(string.IsNullOrEmpty(p))
            {
                kitaplar = kitaplar.Where(m => m.AD.Contains(p));
            }
            //var kitaplar = db.TBLKİTAP.ToList();
            return View(kitaplar.ToList());
        }
        [HttpGet]
        public ActionResult KitapEkle()
        {
            List<SelectListItem> deger1=(from i in db.TBLKategori.ToList()
                                         select new SelectListItem
                                         {
                                             Text=i.ADI,
                                             Value=i.ID.ToString(),
                                         }).ToList();
            ViewBag.dgr1 = deger1;
            List<SelectListItem> deger2= (from i in db.TBLyazar.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.AD +' '+  i.SOYAD,
                                               Value = i.ID.ToString(),
                                           }).ToList();
            ViewBag.dgr2 = deger2;

            return View();
        }
        [HttpPost]
        public ActionResult KitapEkle(TBLKİTAP p)
        {
            var ktg = db.TBLKategori.Where(k => k.ID == p.TBLKategori.ID).FirstOrDefault();
            var yzr=db.TBLyazar.Where(y=>y.ID==p.TBLyazar.ID).FirstOrDefault();
            p.TBLKategori= ktg;
            p.TBLyazar= yzr;
            db.TBLKİTAP.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
            
        }
        public ActionResult KitapSil(int id)
        {
            var kitap = db.TBLKİTAP.Find(id);
            db.TBLKİTAP.Remove(kitap);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult KitapGetir(int id)
        {
            var ktp = db.TBLKİTAP.Find(id);
            List<SelectListItem> deger1 = (from i in db.TBLKategori.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.ADI,
                                               Value = i.ID.ToString(),
                                           }).ToList();
            ViewBag.dgr1 = deger1;
            List<SelectListItem> deger2 = (from i in db.TBLyazar.ToList()
                                          select new SelectListItem
                                          {
                                              Text = i.AD + ' ' + i.SOYAD,
                                              Value = i.ID.ToString(),
                                          }).ToList();
            ViewBag.dgr2 = deger2;
            return View("KitapGetir", ktp);
        }
        public ActionResult KitapGüncelle(TBLKİTAP p)
        {
            var kitap = db.TBLKİTAP.Find(p.ID);
            kitap.AD = p.AD;
            kitap.BASIMYIL=p.BASIMYIL;
            kitap.SAYFA = p.SAYFA;
            kitap.YAYINEVİ = p.YAYINEVİ;
            var ktg=db.TBLKategori.Where(k=>k.ID==p.TBLKategori.ID).FirstOrDefault();
            var yzr=db.TBLyazar.Where(y=>y.ID==p.TBLyazar.ID).FirstOrDefault();
            kitap.KATEGORİ = ktg.ID;
            kitap.YAZAR=yzr.ID;
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }

}
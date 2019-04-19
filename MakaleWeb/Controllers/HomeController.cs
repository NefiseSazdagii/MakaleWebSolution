using MakaleWeb.BusinessLayer;
using MakaleWeb.Entities;
using MakaleWeb.Entities.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
namespace MakaleWeb.Controllers
{
    public class HomeController : Controller
    {
     private   MakaleYonet makaleyonet = new MakaleYonet();
      private  KategoriYonet kategoriyonet = new KategoriYonet(); //kategori listesini almak için
      private KullaniciYonet kullaniciyonet = new KullaniciYonet(); 
        // GET: Home
        public ActionResult Index()
        {
            BusinessLayer.Test test = new BusinessLayer.Test(); //otomatik veritabanı oluşturuyor
            test.InsertTest(); //uğdate i test ettiğim için bu kısmı kapattım ,tekrar tekrar eklemesin diye
            //test.UpdateTest();
            ////test.DeleteTest();
           // test.YorumTest();
            return View(makaleyonet.ListQueryable().Where(x => x.Taslakmi == false).OrderByDescending(x => x.DegistirmeTarihi).ToList());
        }
        public ActionResult Kategori(int? id)
        {
           if(id==null) //eger id gönderilmediyse
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
        
            Kategoriler kat=  kategoriyonet.IDKategoriGetir(id.Value);
            if(kat==null)
            {
                return HttpNotFound();
            }

            List<Makaleler> makale = new List<Makaleler>();
            makale = makaleyonet.ListQueryable().Where(x => x.Taslakmi == false && x.KategorilerID == id).OrderByDescending(x => x.OlusturmaTarihi).ToList();
            return View("Index", makale);
            //taslak olmayan ve benim seçtiğim kayıtları al orderby yap ve içersinden oluşturma tarihine göre sıralayarak getir.

        }
        public ActionResult EnBegenilenler()
        {
            return View("Index", makaleyonet.MakaleGetir().OrderByDescending(x => x.BegeniSayisi).ToList());
        }
        public ActionResult Abaout()
        {
            return View();
        }

        public ActionResult Giris()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Giris(LoginModal model)
        {
          return   View(model);
        }
        public ActionResult Cikis()
        {
            return View();
        }
        public ActionResult KayitOl()
        {
            return View();
        }
        [HttpPost]
        public ActionResult KayitOl(KayitModel model)
        {
            return View(model);
        }
    }
}
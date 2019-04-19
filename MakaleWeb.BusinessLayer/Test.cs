using MakaleWeb.Entities;
using MakaleWebDataAccesLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakaleWeb.BusinessLayer
{
   public class Test
    {
        Repository<Kullanicilar> rep_kul = new Repository<Kullanicilar>();
        Repository<Kategoriler> rep_kat = new Repository<Kategoriler>();
        Repository<Makaleler> rep_makale = new Repository<Makaleler>();
        Repository<Yorumlar> rep_yorum = new Repository<Yorumlar>();
        Repository<Begeniler> rep_begeni = new Repository<Begeniler>();


        public Test()//contructer
        {
            DatabaseContext db = new DatabaseContext(); //nesne create ettik
            ////db.Database.CreateIfNotExists();
            db.Kullanicilar.ToList();
            //bu kısmı database oluşturduktan sonra kapattık

          
            List<Kategoriler>  kategoriler= rep_kat.List();
            List<Kategoriler> kategori_filtre = rep_kat.List(x=>x.ID==1);
            List<Makaleler> makaleler = rep_makale.List();
        }

        //yorum bulmak için 
        public void YorumTest()
        {
            Kullanicilar kul = rep_kul.Find(x => x.ID == 1);
            Makaleler makale = rep_makale.Find(x => x.ID == 1);
            makale.Yorumlar = new List<Yorumlar>();
            Yorumlar yorum = new Yorumlar()
            {
                Metin = "deneme yorumu",
                OlusturmaTarihi = DateTime.Now,
                DegistirmeTarihi = DateTime.Now,
                DegistirenKullanici = "nefisesazdagi",
                Makale = makale,
                Kullanici = kul
            };
            rep_yorum.Insert(yorum);
            //rep_yorum.Update(yorum);

        }
       

        
      

      public void InsertTest()
        {
           
            int kayit = rep_kul.Insert(new Kullanicilar()
            {
                Ad = "Nefise",
                Soyad = "xxxxx",
                Email = "Nefise.sazdagii@gmail.com",
                Sifre = "12345",
                Adminmi = true,
                Aktif = true,
                AktifGuid = Guid.NewGuid(),
                KullaniciAd = "nefise",
                OlusturmaTarihi = DateTime.Now,
                DegistirenKullanici = "nefisesazdagi",
                DegistirmeTarihi = DateTime.Now.AddDays(3)     
        });
        }

        public void UpdateTest()
        {
            Kullanicilar user = rep_kul.Find(x => x.ID == 2); //ikinci uye eklmeyi yaptım ıd si 2 olan 
            if(user!=null)
            {
                user.Ad = "gülsüm";
               int kayit= rep_kul.Update(user);
            }
        }
        public void DeleteTest()
        {
            Kullanicilar user = rep_kul.Find(x => x.Ad == "GÜLSÜM");

            if (user != null)
            {
                int kayit = rep_kul.Delete(user);
            }
        }
       
    }
   
}

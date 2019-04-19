using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using MakaleWeb.Entities;

namespace MakaleWebDataAccesLayer
{
    //ctrl space ile daha ne eklemen gerektiğine bakabilirsen
    public class OrnekData : CreateDatabaseIfNotExists<DatabaseContext> // databasecontest create etmesini istiyorum.
    {
        protected override void Seed(DatabaseContext context) //database i oluştururken dataları alması için seed kullanırız..
        {
            Kullanicilar admin = new Kullanicilar()
            {
                Ad = "Nefise",
                Soyad = "Sazdağı",
                Email = "Nefise.sazdagii@gmail.com",
                Sifre = "12345",
                Adminmi = true,
                Aktif = true,
                AktifGuid = Guid.NewGuid(),
                KullaniciAd = "NefiseSazdagi",
                OlusturmaTarihi = DateTime.Now,
                DegistirenKullanici = "nefisesazdagi",
                DegistirmeTarihi = DateTime.Now.AddDays(3),

            };

            Kullanicilar uye = new Kullanicilar()
            {
                Ad = "Nefise",
                Soyad = "Sazdağı",
                Email = "Nefise.sazdagii@gmail.com",
                Sifre = "123456",
                Adminmi = true,
                Aktif = true,
                AktifGuid = Guid.NewGuid(),
                KullaniciAd = "NefiseSazdagi2",
                OlusturmaTarihi = DateTime.Now,
                DegistirenKullanici = "nefisesazdagi",
                DegistirmeTarihi = DateTime.Now.AddDays(3),

            };
         
            context.Kullanicilar.Add(admin); //admini ve uye yi kullanıcılar tablosuna ekle
            context.Kullanicilar.Add(uye);
            context.SaveChanges();


            for (int i = 0; i < 5; i++)
            {
                Kategoriler ktg = new Kategoriler()
                {
                    Baslik = FakeData.PlaceData.GetStreetName(),
                    Aciklama=FakeData.PlaceData.GetAddress(),
                    OlusturmaTarihi=DateTime.Now,
                    DegistirmeTarihi=DateTime.Now,
                    DegistirenKullanici="nefisesazdagi"
                   
                };
                ktg.Makaleler = new List<Makaleler>(); //yukarıakileri kategoriye ekle 

                for (int j = 0; j < 5; j++)
                {
                      ktg.Makaleler.Add(new Makaleler()
                    {
                        Baslik=FakeData.TextData.GetAlphabetical(FakeData.NumberData.GetNumber(5,25)),
                        Metin=FakeData.TextData.GetSentences(FakeData.NumberData.GetNumber(1,3)),
                        Taslakmi=false,
                        BegeniSayisi=FakeData.NumberData.GetNumber(1,9),
                        Kullanici=(j%2==0)? admin : uye,
                        DegistirmeTarihi=FakeData.DateTimeData.GetDatetime(DateTime.Now.AddYears(-1),DateTime.Now),
                        OlusturmaTarihi=FakeData.DateTimeData.GetDatetime(DateTime.Now.AddYears(-1),DateTime.Now),
                        DegistirenKullanici=(j%2==0) ?admin.KullaniciAd : uye.KullaniciAd
                    });
                }
                context.Kategoriler.Add(ktg);

            }
            context.SaveChanges();
        }
    }

}


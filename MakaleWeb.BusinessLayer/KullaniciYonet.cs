using MakaleWeb.Entities;
using MakaleWeb.Entities.ViewModel;
using MakaleWebDataAccesLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakaleWeb.BusinessLayer
{
   public class KullaniciYonet
    {
        public void KullaniciKayit(KayitModel model)
        {
            Repository<Kullanicilar> rep_kul = new Repository<Kullanicilar>();
            Kullanicilar kullanici = rep_kul.Find(x => x.KullaniciAd == model.KullaniciAd || x.Email == model.EMail);
            if(kullanici!=null)
            {
                if(kullanici.KullaniciAd==model.KullaniciAd)
                {
                    throw new Exception("Kullanıcı adı kayıtlı");
                }
            }
            if(kullanici.Email==model.EMail)
            {
                throw new Exception("Kullanıcı mail adresi kayıtlı");
            }
        }
    }
}

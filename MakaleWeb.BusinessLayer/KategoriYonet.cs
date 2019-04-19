using MakaleWeb.Entities;
using MakaleWebDataAccesLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakaleWeb.BusinessLayer
{
 public   class KategoriYonet
    {
        Repository<Kategoriler> rep_kat = new Repository<Kategoriler>(); //listelemek için repository i kullandım

        public List <Kategoriler> KategoriGetir  ()
        {
            return rep_kat.List();
        }
        public Kategoriler IDKategoriGetir(int id)
        {
            return rep_kat.Find(x => x.ID == id);
        }
    }
}

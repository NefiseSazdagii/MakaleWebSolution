using MakaleWeb.Entities;
using MakaleWebDataAccesLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakaleWeb.BusinessLayer
{
   public class MakaleYonet
    {
        private Repository<Makaleler> rep_mak = new Repository<Makaleler>(); //query gönderiyor bize.

       
        public List<Makaleler> MakaleGetir()
        {
            return rep_mak.List();
        }
        public virtual IQueryable<Makaleler> ListQueryable()
        {
            return rep_mak.ListQueryable();
        }
    }
}

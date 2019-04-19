using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakaleWebDataAccesLayer
{
  public  class singleton
    {
        public static DatabaseContext db;
        private static object _obj= new object();
        protected singleton()
        {
            ContextOlustur();
        }
        public static void   ContextOlustur()
        {
            if (db==null)
            {
                lock (_obj) //multithread uygulamalarda context nesnesinin iki kere oluşturulmasının önüne geçmek için kilitleme işi yapar.
                {
                    db = new DatabaseContext();
                }
            }
        }
    }
}

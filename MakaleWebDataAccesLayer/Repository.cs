
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MakaleWebDataAccesLayer
{
    //repository patten
   public class Repository<T>:singleton where T: class
    {
        ///*   DatabaseContext db = new DatabaseContext(); //bura*/daki T; Kullanıcılar yorumlar vs gibi tabloları temsil ediyor
        //private DatabaseContext db;//singleton dan miras aldıgımız için kaparttık 
        private DbSet<T> _objectset;

        public Repository()
        {
           
            _objectset = db.Set<T>();
        }
        private int Save()
        {
          return  db.SaveChanges();
        }

        public int Insert(T obj)
        {
            _objectset.Add(obj);
            return Save();
           
        }

        public int Update(T obj) //where koşuluyla  nesneyi al ve  gönder
        {
            return Save();
        }

        public int Delete(T obj)
        {
            _objectset.Remove(obj);
            return Save();
        }


        public List<T> List()
        {
            return _objectset.ToList();
        }

        public List<T> List(Expression<Func<T,bool>> where)
        {
            //örneğin ıd ye göre getir
            //t deki koşula göre çalışır
         return _objectset.Where(where).ToList();
          
        }

        public T Find(Expression<Func<T, bool>> where)
        {
            return _objectset.FirstOrDefault(where);
        }


        public IQueryable<T>ListQueryable() 
        {
            return _objectset.AsQueryable<T>();
        }
            
    }
}

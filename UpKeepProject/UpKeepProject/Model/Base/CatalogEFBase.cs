using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using UpKeepProject.Data.Base;

namespace UpKeepProject.Model.Base
{
    public abstract class CatalogEFBase<T, TDBContext> : CatalogBase<T>
        where TDBContext : DbContext, new()
        where T : class, IDomainClass
    {
        private TDBContext _dbContext;

        protected CatalogEFBase()
        {
            _dbContext = new  TDBContext();
        }

        public override T Read(int id)
        {
            return All.Find(obj => (obj.GetId() == id));
        }

        protected override List<T> AllFromSource()
        {
            return BuildObjects(_dbContext.Set<T>());
        }


        protected override void Insert(T obj)
        {
            var query = All.Select(o => o.GetId());
            //int id = All.Select(o => o.GetId()).Max() + 1;
            int id = query.Count() == 0 ? 1 : query.Max()+1;
            obj.SetId(id);
            

            _dbContext.Set<T>().Add(obj);
            _dbContext.SaveChanges();
        }

        protected override void Remove(int id)
        {
            T obj = Read(id);
            if (obj != null)
            {
                _dbContext.Set<T>().Remove(obj);
                _dbContext.SaveChanges();
            }
        }

        protected override void Revise(int id, T obj)
        {
            T oldObj = Read(id);
            if (oldObj != null)
            {
                oldObj.CopyValuesFrom(obj);
                _dbContext.SaveChanges();
            }
        }

        public abstract List<T> BuildObjects(DbSet<T> objects);
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpKeepProject.Data.Base;
using UpKeepProject.Model.App;

namespace UpKeepProject.Model.Base
{
    public abstract class CatalogBase<T> : ICatalog<T> 
        where T : IDomainClass
    {
        private bool _hasChanged;
        private List<T> _cachedData;
        public event Action<int> CatalogChanged;

        public CatalogBase()
        {
            _hasChanged = true;
            _cachedData = null;
        }

        public abstract T Read(int id);
        protected abstract List<T> AllFromSource();
        protected abstract void Insert(T obj);
        protected abstract void Remove(int id);
        protected abstract void Revise(int id, T obj);

        public List<T> All
        {
            get
            {
                if (_hasChanged)
                {
                    _cachedData = AllFromSource();
                    _hasChanged = false;
                }

                return _cachedData;
            }
        }


        public void Create(T obj)
        {
            Insert(obj);
            OnCatalogChanged(obj.GetId());
        }


        public void Delete(int id)
        {
            Remove(id);
            OnCatalogChanged(id);
        }

        public void Update(int id, T obj)
        {
            Revise(id, obj);
            OnCatalogChanged(id);
        }


        protected virtual void OnCatalogChanged(int id)
        {
            _hasChanged = true;
            CatalogChanged?.Invoke(id);
        }
    }
}

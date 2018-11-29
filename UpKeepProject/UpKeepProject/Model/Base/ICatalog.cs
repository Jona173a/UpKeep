using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UpKeepProject.Model.Base
{
    public interface ICatalog<T>
    {
        List<T> All { get; }

        void Create(T obj);

        T Read(int id);

        void Delete(int id);

        event Action<int> CatalogChanged;
    }
}

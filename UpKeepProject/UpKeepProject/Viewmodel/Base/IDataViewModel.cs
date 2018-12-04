using System.Runtime.InteropServices.ComTypes;
using UpKeepProject.Data.Base;

namespace UpKeepProject.Viewmodel.Base
{
    public interface IDataViewModel<T> where T : IDomainClass
    {
        T DataObject();

        void SetDataObject(T obj);
    }
}
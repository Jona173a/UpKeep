using System.ComponentModel;
using System.Runtime.CompilerServices;
using UpKeepProject.Data.Base;

namespace UpKeepProject.Viewmodel.Base
{
    public abstract class DataViewModelBase<T> : IDataViewModel<T>, INotifyPropertyChanged where T : IDomainClass
    {
        private T _obj { get; set; }

        protected DataViewModelBase(T obj)
        {
            _obj = obj;
        }

        protected DataViewModelBase()
        {
            _obj = default(T);
        }

        public T DataObject()
        {
            return _obj;
        }

        public void SetDataObject(T obj)
        {
            _obj = obj;
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
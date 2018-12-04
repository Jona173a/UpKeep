using UpKeepProject.Data.Base;

namespace UpKeepProject.Viewmodel.Base
{
    public abstract class DataViewModelAppBase<T> : DataViewModelBase<T> where T : IDomainClass
    {
        protected DataViewModelAppBase() { }
        protected DataViewModelAppBase(T obj) : base(obj) { }

        public override string ToString()
        {
            return ItemDescription;
        }

        protected abstract string ItemDescription { get; }
    }
}
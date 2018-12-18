using UpKeepProject.Data.Base;
using System;

namespace UpKeepProject.Viewmodel.Base
{
    public abstract class DataViewModelAppBase<T> : DataViewModelBase<T>, IComparable<DataViewModelAppBase<T>>
        where T : class, IDomainClass
    {
        // protected DataViewModelAppBase() {}
        // protected DataViewModelAppBase(T obj) : base(obj) {}

        public virtual int CompareTo(DataViewModelAppBase<T> other)
        {
            return String.Compare(ItemDescription, other.ItemDescription, StringComparison.Ordinal);
        }


        public override string ToString()
        {
            return ItemDescription;
        }

        protected abstract string ItemDescription { get; }
    }
}
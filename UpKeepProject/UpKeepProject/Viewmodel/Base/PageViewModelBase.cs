using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using UpKeepProject.Data.Base;
using UpKeepProject.Model.Base;
using UpKeepProject.Model.Catalog;

namespace UpKeepProject.Viewmodel.Base
{
    public abstract class PageViewModelBase<T, TDataViewModel> : IPageViewModel<TDataViewModel>, INotifyPropertyChanged
        where TDataViewModel : class, IDataViewModel<T>, new()
        where T : IDomainClass, new()
    {
        #region Instance fields
        protected ICatalog<T> _catalog;
        protected PageViewModelState _state;
        protected event Action<PageViewModelState> _viewStateChanged;

        private TDataViewModel _itemSelected;
        private TDataViewModel _itemDetails;
        #endregion


        protected PageViewModelBase()
        {
            _catalog = GetCatalog();
            _catalog.CatalogChanged += OnCatalogHasChanged;
        }
    
        public ObservableCollection<TDataViewModel> ItemCollection
        {
            get
            {
                List<TDataViewModel> collection = _catalog.All.Select(CreateDataViewModel).ToList();
                return new ObservableCollection<TDataViewModel>(collection.OrderBy(model => model.DataObject().GetId()));
            }
        }

        

        public TDataViewModel ItemSelected
        {
            get { return _itemSelected; }
            set
            {
                if (_state == PageViewModelState.ReadDelete)
                {
                    _itemSelected = value;
                    _itemDetails = _itemSelected;
                }

                if (_state == PageViewModelState.Create)
                {
                    _itemSelected = null;
                    _itemDetails = CreateDataViewModel(new T());
                }

                if (_state == PageViewModelState.Update)
                {
                    _itemSelected = value;
                    _itemDetails = _itemSelected != null ? CreateDataViewModel((T)_itemSelected.DataObject().Copy()) : null;
                }

                OnPropertyChanged();
                OnPropertyChanged(nameof(ItemDetails));

                NotifyCommands();
            }
        }

        public TDataViewModel ItemDetails
        {
            get { return _itemDetails; }
        }

        public bool EnabledStateCollection
        {
            get { return _state != PageViewModelState.Create; }
        }

        public bool EnabledStateDetails
        {
            get { return _state != PageViewModelState.ReadDelete; }
        }

        public bool EnabledStateReferenceChange
        {
            get { return _state == PageViewModelState.Update; }
        }

        public void SetState(PageViewModelState newState)
        {
            _state = newState;
            ItemSelected = null;

            OnPropertyChanged(nameof(EnabledStateDetails));
            OnPropertyChanged(nameof(EnabledStateCollection));
            OnPropertyChanged(nameof(EnabledStateReferenceChange));

            OnViewStateChanged(newState);
        }

        private TDataViewModel CreateDataViewModel(T obj)
        {
            TDataViewModel dvmObj = new TDataViewModel();
            dvmObj.SetDataObject(obj);
            return dvmObj;
        }

        private void OnCatalogHasChanged(int obj)
        {
            OnPropertyChanged(nameof(ItemCollection));
        }

        protected virtual void OnViewStateChanged(PageViewModelState obj)
        {
            _viewStateChanged?.Invoke(obj);
        }

        protected abstract ICatalog<T> GetCatalog();

        protected abstract void NotifyCommands();
        

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    
    }
}
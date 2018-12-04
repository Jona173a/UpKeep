using UpKeepProject.Command.Base;
using UpKeepProject.Data.Base;
using UpKeepProject.Model.Base;
using UpKeepProject.Viewmodel.Base;

namespace UpKeepProject.Command
{


    public abstract class CRUDCommandBase<T, TDataViewModel> : CommandBase
        where TDataViewModel : IDataViewModel<T>
        where T : IDomainClass
    {
        protected ICatalog<T> _catalog;
        protected IPageViewModel<TDataViewModel> _pageViewModel;

        protected CRUDCommandBase(ICatalog<T> catalog, IPageViewModel<TDataViewModel> pageViewModel)
        {
            _catalog = catalog;
            _pageViewModel = pageViewModel;
        }

        protected override bool CanExecute()
        {
            return (_pageViewModel.ItemDetails != null) && (_pageViewModel.ItemDetails.DataObject() != null);
        }
    }

}
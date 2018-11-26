namespace UpKeepProject.Command.Base
{
    public class CRUDCommandBase<T, TDataViewModel> : CommandBase
    {
        protected ICatalog<T> _catalog;
        protected IPageViewModel<TDataViewModel> _pageViewModel;

        protected CRUDCommandBase(ICatalog<T> catalog, IPageViewModel<TDataViewModel> pageViewModel)
        {
            _catalog = catalog;
            _pageViewModel = pageViewModel;
        }
    }
}
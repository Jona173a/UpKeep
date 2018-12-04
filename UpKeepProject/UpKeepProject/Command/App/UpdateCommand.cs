using UpKeepProject.Data.Base;
using UpKeepProject.Model.Base;
using UpKeepProject.Viewmodel.Base;

namespace UpKeepProject.Command
{
    public class UpdateCommand<T, TDataViewModel> : CRUDCommandBase<T, TDataViewModel>
        where TDataViewModel : IDataViewModel<T>
        where T : IDomainClass
    {
        public UpdateCommand(ICatalog<T> catalog, IPageViewModel<TDataViewModel> pageViewModel)
            : base(catalog, pageViewModel)
        {
        }

        protected override void Execute()
        {
            T obj = _pageViewModel.ItemDetails.DataObject();
            _catalog.Delete(obj.GetId());
            _catalog.Create(obj);
        }
    }
}
namespace UpKeepProject.Command.App
{
    public class DeleteCommand<T, TDataViewModel> : CRUDCommandBase<T, TDataViewModel>
        where TDataViewModel : IDataViewModel<T>
        where T : IDomainClass_
    {
        public DeleteCommand(ICatalog<T> catalog, IPageViewModel<TDataViewModel> pageViewModel)
            : base(catalog, pageViewModel)
        {
        }

        /// <summary>
        /// Delete kan kun udføres, når der er valgt et element i PVM
        /// </summary>
        protected override bool CanExecute()
        {
            return (_pageViewModel.ItemSelected != null) && (_pageViewModel.ItemSelected.DataObject() != null);
        }

        /// <summary>
        /// Delete udføres ved at slette det i PVM valgte element fra Catalog-objektet.
        /// </summary>
        protected override void Execute()
        {
            _catalog.Delete(_pageViewModel.ItemSelected.DataObject().GetId());
        }
    }
}
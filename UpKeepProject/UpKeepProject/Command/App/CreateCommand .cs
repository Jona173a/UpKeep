namespace UpKeepProject.Command.App
{
    public class CreateCommand<T, TDataViewModel> : CRUDCommandBase<T, TDataViewModel>
        where TDataViewModel : IDataViewModel<T>
        where T : IDomainClass
    {
        public CreateCommand(ICatalog<T> catalog, IPageViewModel<TDataViewModel> pageViewModel)
            : base(catalog, pageViewModel)
        {
        }

        /// <summary>
        /// NB: Denne metode er IKKE færdig
        /// </summary>
        protected override bool CanExecute()
        {
            return (_pageViewModel.ItemSelected != null) && (_pageViewModel.ItemSelected.DataObject() != null);
        }

        /// <summary>
        /// NB: Denne metode er IKKE færdig
        /// </summary>
        protected override void Execute()
        {
            _catalog.Create(_pageViewModel.ItemSelected.DataObject());
        }
    }
}
﻿using UpKeepProject.Data.Base;
using UpKeepProject.Model.Base;
using UpKeepProject.Viewmodel.Base;

namespace UpKeepProject.Command
{
    public class DeleteCommand<T, TDataViewModel> : CRUDCommandBase<T, TDataViewModel>
        where TDataViewModel : IDataViewModel<T>
        where T : IDomainClass
    {
        public DeleteCommand(ICatalog<T> catalog, IPageViewModel<TDataViewModel> pageViewModel)
            : base(catalog, pageViewModel)
        {
        }

        protected override void Execute()
        {
            _catalog.Delete(_pageViewModel.ItemDetails.DataObject().GetId());
        }
    }
}
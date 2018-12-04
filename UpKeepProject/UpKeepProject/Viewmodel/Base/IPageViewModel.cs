using System.Collections.ObjectModel;
using Windows.UI.Xaml.Controls;

namespace UpKeepProject.Viewmodel.Base
{
    public interface IPageViewModel<TDataViewModel>
    {
        ObservableCollection<TDataViewModel> ItemCollection { get; }

        TDataViewModel ItemSelected { get; set; }

        TDataViewModel ItemDetails { get; }

        void SetState(PageViewModelState newState);

    }
}
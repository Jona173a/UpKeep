using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Windows.UI.Xaml.Controls;
using UpKeepProject.Viewmodel.Base;

namespace UpKeepProject.Viewmodel.Page
{
    public class KundePageViewModel : PageViewModelAppBase<Kunde, KundeDataViewModel>
    {
        private string _fliterText;

        public KundePageViewModel()
        {
            _fliterText = "";
        }

        public override ObservableCollection<KundeDataViewModel> ItemCollection
        {
            get
            {
                return new ObservableCollection<KundeDataViewModel>(
                    base.ItemCollection.Where(item => item.Name.ToLower().StartsWith(_fliterText.ToLower())));
            }
        }

        public string FliterText
        {
            get { return _fliterText;}
            set
            {
                _fliterText = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(ItemCollection));
            }
        }


        public List<KundeDataViewModel> SorList
        {
            get { return ItemCollection.OrderBy(j => j.Id).ToList(); }
        }
    }
}
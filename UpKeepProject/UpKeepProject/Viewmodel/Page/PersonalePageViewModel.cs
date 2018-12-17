using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using UpKeepProject.Viewmodel.Base;

namespace UpKeepProject.Viewmodel.Page
{
    public class PersonalePageViewModel : PageViewModelAppBase<Personale, PersonaleDataViewModel>
    {
        private string _fliterText;

        public PersonalePageViewModel()
        {
            _fliterText = "";
        }

        public override ObservableCollection<PersonaleDataViewModel> ItemCollection
        {
            get
            {
                return new ObservableCollection<PersonaleDataViewModel>(
                    base.ItemCollection.Where(item => item.Name.ToLower().StartsWith(_fliterText.ToLower())));
            }
        }

        public string FliterText
        {
            get { return _fliterText; }
            set
            {
                _fliterText = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(ItemCollection));
            }
        }
    }
}
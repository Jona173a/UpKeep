using System.Collections;
using System.Collections.Generic;
using System.Linq;
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

        public IEnumerable<KundeDataViewModel> FliterItemCollection
        {
            get { return ItemCollection.Where(item => item.Name.ToLower().StartsWith(_fliterText.ToLower())); }
        }

        public string FliterText
        {
            get { return _fliterText;}
            set
            {
                _fliterText = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(FliterItemCollection));
            }
        }

    }
}
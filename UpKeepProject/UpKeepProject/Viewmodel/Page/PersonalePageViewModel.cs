using System.Collections.Generic;
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

        public IEnumerable<PersonaleDataViewModel> FliterItemCollection
        {
            get { return ItemCollection.Where(item => item.Name.ToLower().StartsWith(_fliterText.ToLower())); }
        }

        public string FliterText
        {
            get { return _fliterText; }
            set
            {
                _fliterText = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(FliterItemCollection));
            }
        }
    }
}
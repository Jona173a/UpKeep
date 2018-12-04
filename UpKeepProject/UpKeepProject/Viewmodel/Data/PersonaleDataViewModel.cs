using UpKeepProject.Viewmodel.Base;

namespace UpKeepProject.Viewmodel
{
    public class PersonaleDataViewModel : DataViewModelAppBase<Personale>
    {
        public PersonaleDataViewModel() { }

        public PersonaleDataViewModel(Personale dataObject) : base(dataObject)
        {
        }

        public string Name
        {
            get { return DataObject().Name; }
            set
            {
                DataObject().Name = value;
                OnPropertyChanged();
            }
        }

        public string Adresse
        {
            get { return DataObject().Adresse; }
            set
            {
                DataObject().Adresse = value;
                OnPropertyChanged();
            }
        }

        public string Nummer
        {
            get { return DataObject().Adresse; }
            set
            {
                DataObject().Adresse = value;
                OnPropertyChanged();
            }
        }



        protected override string ItemDescription
        {
            get { return $"{Name} {Adresse} {Nummer}"; }
        }

    }
}
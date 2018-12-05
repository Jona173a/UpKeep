using UpKeepProject.Viewmodel.Base;

namespace UpKeepProject.Viewmodel
{
    public class KundeDataViewModel : DataViewModelAppBase<Kunde>
    {
        public KundeDataViewModel() { }

        public KundeDataViewModel(Kunde dataObject) : base(dataObject)
        {
        }

        public int Id
        {
            get { return DataObject().Id; }
            set
            {
                DataObject().Id = value;
                OnPropertyChanged();
            }
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
            get { return $"{Id} {Name} {Adresse} {Nummer}"; }
        }

    }
}
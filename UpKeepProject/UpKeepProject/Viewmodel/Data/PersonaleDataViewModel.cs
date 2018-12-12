using UpKeepProject.Viewmodel.Base;

namespace UpKeepProject.Viewmodel
{
    public class PersonaleDataViewModel : DataViewModelAppBase<Personale>
    {
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

        public int Nummer
        {
            get { return DataObject().Nummer; }
            set
            {
                DataObject().Nummer= value;
                OnPropertyChanged();
            }
        }



        protected override string ItemDescription
        {
            get { return $"{Id} {Name} {Adresse} {Nummer}"; }
        }

        public  string ItemDescription2
        {
            get { return $"{Id} {Name} {Adresse} {Nummer}"; }
        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpKeepProject.Model.Base;
using UpKeepProject.Model.Catalog;

namespace UpKeepProject.Model.App
{
    public class DomainModel
    {
        private static DomainModel _instance;

        public static DomainModel Instance { get { return _instance ?? (_instance = new DomainModel()); } }


        // Giver Catalog en connection til klasse
        private ICatalog<Personale> Personaler { get; }
        private ICatalog<Kunde> Kunder { get; }

        private DomainModel()
        {
            Personaler = new PersonaleCatalog();
            Kunder = new KundeCatalog();
        }

        public static ICatalog<T> GeCatalog<T>()
        {
            if (typeof(T)== typeof(Personale))
            {
                return (ICatalog<T>) Instance.Personaler;
            }
        
            if (typeof(T) == typeof(Kunde))
            {
                return (ICatalog<T>)Instance.Kunder;
            }

            throw  new  ArgumentException($"Ingen Catalog fundt af den type {typeof(T)}");
        }
    }
}

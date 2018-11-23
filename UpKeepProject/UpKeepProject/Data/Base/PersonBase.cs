using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UpKeepProject.Data.Domain
{
    public class PersonBase
    {
        public int _id;
        public string _navn;
        public string _adresse;
        public int _nummer;


        public Personbase(int id, string navn, string adressse, int nummer)
        {
            _id = id;
            _navn = navn;
            _adresse = adressse;
            _nummer = nummer;

        }


        public int Id { get; set; }
        public int Navn { get; set; }
        public int Adresse { get; set; }
        public int Nummer { get; set; }


    }
}

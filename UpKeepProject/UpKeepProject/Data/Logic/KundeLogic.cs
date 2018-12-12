using UpKeepProject.Data.Base;

namespace UpKeepProject
{
    public partial class Kunde : DomainClassBase<Kunde>
    {
        public override int GetId()
        {
            return Id;
        }

        public override void SetId(int id)
        {
            Id = id;
        }

        public override void CopyValuesFromObj(Kunde obj)
        {
            Name = obj.Name;
            Adresse = obj.Adresse;
            Nummer = obj.Nummer;
        }

        
    }
}
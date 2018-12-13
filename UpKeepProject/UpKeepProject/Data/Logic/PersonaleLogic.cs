using UpKeepProject.Data.Base;

namespace UpKeepProject

{
    public partial class Personale : DomainClassBase<Personale>
    {
        public override int GetId()
        {
            return Id;
        }

        public override void SetId(int id)
        {
            Id = id;
        }

        public override void CopyValuesFromObj(Personale obj)
        {
            Name = obj.Name;
            Adresse = obj.Adresse;
            Nummer = obj.Nummer;
        }
    }
}
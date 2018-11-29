using UpKeepProject.Data.Base;

namespace UpKeepProject.Data.Logic
{
    public partial class Kunde : DomainClassBase
    {
        public override int GetId()
        {
            return Id;
        }

        public override void SetId(int id)
        {
            Id = id;
        }
    }
}
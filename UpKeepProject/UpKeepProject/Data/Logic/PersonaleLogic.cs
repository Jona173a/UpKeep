using UpKeepProject.Data.Base;

namespace UpKeepProject

{
    public partial class Personale : DomainClassBase
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
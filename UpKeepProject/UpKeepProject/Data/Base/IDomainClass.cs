namespace UpKeepProject.Data.Base
{
    public interface IDomainClass
    {
        int GetId();

        void SetId(int id);

        IDomainClass Copy();

    }
}
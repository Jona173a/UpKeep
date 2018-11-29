using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace UpKeepProject.Data.Base
{
    public abstract class DomainClassBase : IDomainClass
    {
        public abstract int GetId();
        public abstract void SetId(int id);

        public IDomainClass Copy()
        {
            return (MemberwiseClone()as IDomainClass);
        }
    }
}

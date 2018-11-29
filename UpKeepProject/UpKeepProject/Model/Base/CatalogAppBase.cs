using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpKeepProject.Data.Base;

namespace UpKeepProject.Model.Base
{
    public abstract class CatalogAppBase<T> : CatalogEFBase<T, UpkeepContext>
        where T : class, IDomainClass
    {
    }
}

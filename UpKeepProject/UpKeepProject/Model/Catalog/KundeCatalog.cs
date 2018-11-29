using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using UpKeepProject.Model.Base;

namespace UpKeepProject.Model.Catalog
{
    public class KundeCatalog : CatalogAppBase<Kunde>
    {
        public override List<Kunde> BuildObjects(DbSet<Kunde> objects)
        {
            return objects.ToList();
        }
    }
}
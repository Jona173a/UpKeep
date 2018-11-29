using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UpKeepProject.Model.Base;

namespace UpKeepProject.Model.Catalog
{
    public class PersonaleCatalog : CatalogAppBase<Personale>
    {
        public override List<Personale> BuildObjects(DbSet<Personale> objects)
        {
            return objects.ToList();
        }
    }
}

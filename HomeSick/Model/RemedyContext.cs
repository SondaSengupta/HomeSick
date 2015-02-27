using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HomeSick.Model;
using System.Data.Entity;

namespace HomeSick.Model
{
    public class RemedyContext: DbContext
    {
        public DbSet<RemedyItem> Remedies { get; set; }
    }
}

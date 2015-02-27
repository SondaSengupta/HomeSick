using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HomeSick.Model;

namespace HomeSick.Repository
{
    public interface IRemedyRepository
    {
        int GetCount();
        void Add(RemedyItem F);
        void Delete(RemedyItem F);
        void Clear();
        void Dispose();
    }
}

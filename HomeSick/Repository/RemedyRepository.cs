using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using HomeSick.Model;
using System.Windows;

namespace HomeSick.Repository
{
    public class RemedyRepository: IRemedyRepository
    {
        private RemedyContext _dbContext;  //declares db field
        private IQueryable<Model.RemedyItem> query;

        public RemedyRepository()
        {
            _dbContext = new RemedyContext(); //generates new instance of RemedyContext
            _dbContext.Remedies.Load();  //Loads the DbSet Remedies, which connects the database to dbLogic
        }
        public RemedyContext Context()
        {
            return _dbContext;
        }

        public int GetCount()
        {
            return _dbContext.Remedies.Count<RemedyItem>();
        }

        public void Add(RemedyItem F)
        {
            _dbContext.Remedies.Add(F);
            _dbContext.SaveChanges();
        }

        public void Delete(RemedyItem F)
        {
            if (F == null)
            {
                MessageBox.Show("Deleted item not found.");
            }
            else
            {
                _dbContext.Remedies.Remove(F);
                _dbContext.SaveChanges();
            } 
        }

        public void Clear()
        {
            var allItemsQuery = from Event in _dbContext.Remedies select Event;
            var a = allItemsQuery.ToList<RemedyItem>();
            _dbContext.Remedies.RemoveRange(a);
            _dbContext.SaveChanges();
        }

        public IEnumerable<Model.RemedyItem> GetByTreatmentFor(object treatmentfor)
        {
            query = from Remedies in _dbContext.Remedies
                        where  Remedies.RemedyTreatmentFor == treatmentfor
                        select Remedies;
            return query.ToList();
        }

        public List<string> GetTreatments()
        {
            var treatmentQuery = from Remedies in _dbContext.Remedies
                        select Remedies.RemedyTreatmentFor;
            return treatmentQuery.Distinct().ToList();
        }

        public RemedyItem GetById(int id)
        {
            var querybyID = from Remedies in _dbContext.Remedies
                            where Remedies.RemedyItemId == id
                            select Remedies;
            return querybyID.First();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Star_VoteAPI.Models.DataManager
{
    public class ShowManager : IDataRepository<ShowModel>
    {
        private DBContext  _dbContext { get; set; }
        public ShowManager(DBContext context)
        {
            _dbContext = context;
        }
        public void Add(ShowModel entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(ShowModel entity)
        {
            throw new NotImplementedException();
        }

        public ShowModel Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ShowModel> GetAll()
        {
            return _dbContext.Show.ToList();
        }

        public void Update(ShowModel entity)
        {
            throw new NotImplementedException();
        }
    }
}

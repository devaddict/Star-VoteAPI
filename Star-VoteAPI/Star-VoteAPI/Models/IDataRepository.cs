using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Star_VoteAPI.Models
{
    
        public interface IDataRepository<TEntity>
        {
        IEnumerable<TEntity> GetAll();
        TEntity Get(int id);
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);

        }

}

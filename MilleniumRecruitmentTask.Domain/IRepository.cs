using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilleniumRecruitmentTask.Domain
{
    public interface IRepository<TEntity>
    {
        Task<TEntity> Get(int id);
        Task<IEnumerable<TEntity>> GetAll();
        Task<int> Create(TEntity entity);
        Task Update(int id, TEntity entity);
        Task Remove(int id);
    }
}

using MilleniumRecruitmentTask.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MilleniumRecruitmentTask.Domain.Repositories
{
    public class Repository<T> : IRepository<T>
    {
        public async Task<int> Create(T entity)
        {
            return 1;
        }

        public  Task Remove(int id)
        {
            throw new NotImplementedException();
        }

        public Task Update(int id, T entity)
        {
            throw new NotImplementedException();
        }

        Task<T> IRepository<T>.Get(int id)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<T>> IRepository<T>.GetAll()
        {
            throw new NotImplementedException();
        }
    }
}

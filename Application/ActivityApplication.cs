using Domain.Entities;
using Domain.Interfaces.Application;
using Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public class ActivityApplication : IActivityApplication
    {

        private IRepository<ActivityEntity> _repository;

        public ActivityApplication(IRepository<ActivityEntity> repository)
        {
            _repository = repository;
        }

        public async Task<bool> Delete(int id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<ActivityEntity> Get(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<ActivityEntity>> GetAll()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<ActivityEntity> Post(ActivityEntity activity)
        {
            return await _repository.CreateAsync(activity);
        }

        public async Task<ActivityEntity> Put(ActivityEntity activity)
        {
            return await _repository.UpdateAsync(activity);
        }


    }
}

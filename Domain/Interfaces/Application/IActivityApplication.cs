using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Application
{
    public interface IActivityApplication
    {
        Task<ActivityEntity> Get(int id);
        Task<IEnumerable<ActivityEntity>> GetAll();
        Task<ActivityEntity> Post(ActivityEntity activity);
        Task<ActivityEntity> Put(ActivityEntity activity);
        Task<bool> Delete(int id);

    }
}

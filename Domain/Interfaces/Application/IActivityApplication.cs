using Domain.Dtos.Activity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Application
{
    public interface IActivityApplication
    {
        Task<ActivityDto> Get(int id);
        Task<IEnumerable<ActivityDto>> GetAll();
        Task<ActivityDtoCreateResult> Post(ActivityDtoCreate activity);
        Task<ActivityDtoUpdateResult> Put(ActivityDtoUpdate activity);
        Task<bool> Delete(int id);

    }
}

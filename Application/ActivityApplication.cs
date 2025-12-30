using AutoMapper;
using Domain.Dtos.Activity;
using Domain.Entities;
using Domain.Interfaces;
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

        private IRepository<Activity> _repository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;

        public ActivityApplication(IRepository<Activity> repository, IMapper mapper, IUnitOfWork uow)
        {
            _repository = repository;
            _mapper = mapper;
            _uow = uow;
        }

        public async Task<bool> Delete(int id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<ActivityDto> Get(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            return _mapper.Map<ActivityDto>(entity);

        }

        public async Task<IEnumerable<ActivityDto>> GetAll()
        {
            var listEntity = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<ActivityDto>>(listEntity);
        }

        public async Task<ActivityDtoCreateResult> Post(ActivityDtoCreate activity)
        {
            var entity = _mapper.Map<Activity>(activity);
            var result = await _repository.CreateAsync(entity);
            return _mapper.Map<ActivityDtoCreateResult>(result);
        }

        public async Task<ActivityDtoUpdateResult> Put(ActivityDtoUpdate activity)
        {
            var entity = _mapper.Map<Activity>(activity);
            var result = await _repository.UpdateAsync(entity);
            return _mapper.Map<ActivityDtoUpdateResult>(result);
        }

        public async Task<ActivityDtoCreateResult> Create(ActivityDtoCreate activity)
        {
            try
            {
                var entity = _mapper.Map<Activity>(activity);
                var result = await _uow.ActivityRepository.AddAsync(entity);

                await _uow.CommitAsync();
                await _uow.CommitTransactionAsync();

                return _mapper.Map<ActivityDtoCreateResult>(result);

            }
            catch
            {

                await _uow.RollbackTransactionAsync();
                throw;

            }



        }
    }
}

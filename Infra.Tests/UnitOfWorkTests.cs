using Domain.Entities;
using Infra.Repository;
using Infra.UoW;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using FluentAssertions;

namespace Infra.Tests
{
    public class UnitOfWorkTests
    {
        [Fact]
        public async Task CommitAsync_ShouldPersistChanges()
        {
            var options = new DbContextOptionsBuilder<DataBaseContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            var context = new DataBaseContext(options);
            var repo = new BaseRepository<Activity>(context);

            var uow = new UnitOfWork(context, repo);
            await uow.ActivityRepository.AddAsync(new Activity
            {
                Title = "test insert 1",
                Description = "Test description",
                TaskStatus = 3,
                DueDate = DateTime.Now.AddMonths(2),
            });

            var result = await uow.CommitAsync();
            result.Should().Be(1);
        }

       
       
    }
}

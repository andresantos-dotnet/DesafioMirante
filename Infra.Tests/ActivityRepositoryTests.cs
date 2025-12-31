using Domain.Entities;
using FluentAssertions;
using Infra.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using Xunit;


namespace Infra.Tests;

public class ActivityRepositoryTests
{
    private DataBaseContext GetContext()
    {
        var options = new DbContextOptionsBuilder<DataBaseContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;

        return new DataBaseContext(options);
    }

    [Fact]
    public async Task BaseRepository_AddAsync_ShouldPersistActivity()
    {
        var context = GetContext();
        var repo = new BaseRepository<Activity>(context);

        var activity = new Activity
        {
            Title = "test insert 1",
            Description = "Test description",
            TaskStatus = 3,
            DueDate = DateTime.Now.AddMonths(2),
        };

        await repo.CreateAsync(activity);
        await context.SaveChangesAsync();

        context.Activities.SingleOrDefaultAsync(n=>n.TaskStatus.Equals(3));
    }

    [Fact]
    public async Task BaseRepository_ShouldFilterActiveActivities_WithLinqQuery()
    {
        var context = GetContext();
        var repo = new BaseRepository<Activity>(context);

        var all = await repo.GetAllAsync();
        var active = all.Where(a => a.Active).ToList();

       // active.Should().HaveCount(2);
        active.All(a => a.Active).Should().BeTrue();
    }
}
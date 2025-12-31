

using Domain.Entities;
using FluentAssertions;
using Xunit;

namespace Domain.Tests;

public class ActivityDomainTests
{
    [Fact]
    public void Activity_ShouldBeCreated_WithValidState()
    {
        var activity = new Activity
        {
            Title = "test insert 1",
            Description = "test description",
            Active = true,
            TaskStatus = 1,
            DueDate = DateTime.Now.AddMonths(2),

        };

        activity.Title.Should().NotBeNullOrEmpty();
        activity.TaskStatus.Should().BeGreaterThan(0);
        activity.Active.Should().BeTrue();
        activity.DueDate.Should().BeSameDateAs(DateTime.Now.AddMonths(2));
        
    }
}
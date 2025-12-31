using AutoMapper;
using Domain.Dtos.Activity;
using Domain.Entities;
using Domain.Interfaces;
using Domain.Interfaces.Application;
using Domain.Interfaces.Repository;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.JSInterop.Infrastructure;
using Moq;

using webapi.Controllers;
using Xunit;

namespace WebAPI.Tests;

public class ActivityControllerTests
{
    private readonly Mock<IActivityApplication> _mockApp;
    private readonly ActivityController _controller;

    public ActivityControllerTests()
    {
        _mockApp = new Mock<IActivityApplication>();
        _controller = new ActivityController(_mockApp.Object);
    }

    [Fact]
    public async Task GetAll_ShouldReturnOk_WithActivities()
    {
        _mockApp.Setup(x => x.GetAll()).ReturnsAsync(new List<ActivityDto>());
        var result = await _controller.GetAll();

        result.Should().BeOfType<OkObjectResult>();
        _mockApp.Verify(x => x.GetAll(), Times.Once);
    }

    [Fact]
    public async Task Get_ShouldReturnOk_WhenActivityExists()
    {
        _mockApp.Setup(x => x.Get(It.IsAny<int>())).ReturnsAsync(new ActivityDto { Title = "primeiro insert" });
        var result = await _controller.Get(1);

        result.Should().BeOfType<OkObjectResult>();
        _mockApp.Verify(x => x.Get(1), Times.Once);
    }

  

}

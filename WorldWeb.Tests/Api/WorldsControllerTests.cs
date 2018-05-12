namespace WorldWeb.Tests.Api
{
    using FluentAssertions;
    using Microsoft.AspNetCore.Mvc;
    using Moq;
    using System.Collections.Generic;
    using System.Linq;
    using WorldWeb.Api.Controllers;
    using WorldWeb.Core.Domain;
    using WorldWeb.Core.Repositories;
    using WorldWeb.Tests.Fixtures;
    using Xunit;

    public class WorldsControllerTests
    {
        [Fact]
        public void GetReturnsAllWorlds()
        {
            var worldRepository = WorldRepository()
                .Contains(new World(1, "Dune Universe"))
                .Contains(new World(2, "Tolkein Legendarium", "Middle Earth plus"));

            var controller = new WorldsController(worldRepository.Object);
            var result = controller.Get();

            result.Should().BeOfType<OkObjectResult>();
            (result as OkObjectResult).Value.Should().BeAssignableTo<IEnumerable<World>>();

            var worlds = (result as OkObjectResult).Value as IEnumerable<World>;
            worlds.Count().Should().Be(2);

            worlds.Should().ContainSingle(w => w.Id == 2);
            var tolkeins = worlds.Single(w => w.Id == 2);
            tolkeins.Name.Should().Be("Tolkein Legendarium");
            tolkeins.Description.Should().Be("Middle Earth plus");
        }

        private static Mock<IWorldRepository> WorldRepository()
        {
            return new Mock<IWorldRepository>();
        }
    }
}

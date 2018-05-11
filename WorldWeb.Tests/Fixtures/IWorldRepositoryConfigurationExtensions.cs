namespace WorldWeb.Tests.Fixtures
{
    using Moq;
    using System.Collections.Generic;
    using WorldWeb.Core.Domain;
    using WorldWeb.Core.Repositories;

    public static class IWorldRepositoryConfigurationExtensions
    {
        public static Mock<IWorldRepository> Contains(this Mock<IWorldRepository> repository, World world)
        {
            var result = repository.Object.Get();
            var worlds = result == null ? new List<World>() : new List<World>(result.Resource);
            worlds.Add(world);
            repository.Setup(r => r.Get()).Returns(RepositoryActionResult<IEnumerable<World>>.Found(worlds));
            return repository;
        }
    }
}

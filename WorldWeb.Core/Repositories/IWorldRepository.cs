namespace WorldWeb.Core.Repositories
{
    using System.Collections.Generic;
    using WorldWeb.Core.Domain;

    public interface IWorldRepository
    {
        RepositoryActionResult<IEnumerable<World>> Get();
    }
}

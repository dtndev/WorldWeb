namespace WorldWeb.Infrastructure.Repositories
{
    using Dapper;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using System.Linq;
    using WorldWeb.Core.Domain;
    using WorldWeb.Core.Repositories;

    public class SqlServerWorldRepository : IWorldRepository
    {
        private readonly SqlConnectionProvider connectionProvider;

        public SqlServerWorldRepository(SqlConnectionProvider connectionProvider)
        {
            this.connectionProvider = connectionProvider;
        }

        public RepositoryActionResult<IEnumerable<World>> Get()
        {
            using (SqlConnection conn = this.connectionProvider.WorldWebConnection())
            {
                var records = conn.Query<WorldRecord>("World_GetList", commandType: CommandType.StoredProcedure);
                return RepositoryActionResult<IEnumerable<World>>.Found(records.Select(wr => wr.ToWorld()));
            }
        }

        private class WorldRecord
        {
            public int Id { get; set; }

            public string Name { get; set; }

            public string Description { get; set; }

            internal World ToWorld()
            {
                return new World(this.Id, this.Name, this.Description);
            }
        }
    }
}

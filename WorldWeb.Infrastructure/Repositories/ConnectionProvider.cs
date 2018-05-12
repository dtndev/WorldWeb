namespace WorldWeb.Infrastructure.Repositories
{
    using Microsoft.Extensions.Configuration;
    using System.Data.SqlClient;

    public class SqlConnectionProvider
    {
        private readonly IConfiguration config;

        public SqlConnectionProvider(IConfiguration config)
        {
            this.config = config;
        }

        internal SqlConnection WorldWebConnection()
        {
            return new SqlConnection(this.config.GetConnectionString("WorldWeb"));
        }
    }
}

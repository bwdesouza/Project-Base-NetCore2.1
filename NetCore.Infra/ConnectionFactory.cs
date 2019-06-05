using System.Data.Common;
using System.Data.SqlClient;
using NetCore.CrossCutting;
using NetCore.Domain.Interfaces;

namespace NetCore.Infra
{
    public class ConnectionFactory : IConnectionFactory
    {
        /// <summary>
        /// Abre uma conexão com a Plataforma autoral
        /// </summary>
        /// <returns></returns>
        public DbConnection GetOpenBDConnection()
        {
            var connection = new SqlConnection(ConnectionStrings.BancoDadosConnection);

            if (connection.State != System.Data.ConnectionState.Open)
                connection.Open();

            return connection;
        }
    }
}

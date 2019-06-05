using Dapper;
using NetCore.Domain.Models;
using NetCore.Domain.Repositories;
using System.Data;
using System.Data.Common;

namespace NetCore.Infra.Repositories
{
    public class BaseRepository: IBaseRepository
    {
        #region Propertities
        /// <summary>
        /// Boleano que indica se e conexão local ou externa.
        /// </summary>
        private bool _localConnection;
        /// <summary>
        /// Transação externa.
        /// </summary>
        public DbTransaction _Transaction { get; private set; }
        /// <summary>
        /// Conexão do SQL
        /// </summary>
        private DbConnection Connection { get; set; }
        #endregion

        #region Public Methods
        /// <summary>
        /// Atribui uma conexão externa.
        /// </summary>
        /// <param name="conn"></param>
        public virtual void SetTransaction(DbTransaction trans)
        {
            this._Transaction = trans;
            this.Connection = trans.Connection;
        }
        /// <summary>
        /// Executa uma comando sql.
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public int Execute(string sql, object param = null)
        {
            try
            {
                var conn = GetConnection();
                if (_localConnection)
                    return conn.Execute(sql, param);

                return conn.Execute(sql, param, _Transaction);
            }
            finally
            {
                DisposeIfLocalConnection();
            }
        }
        /// <summary>
        /// Retorna o primeiro objeto que encontrar.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <param name="transaction"></param>
        /// <param name="commandTimeout"></param>
        /// <param name="commandType"></param>
        /// <returns></returns>
        public T QueryFirstOrDefault<T>(string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            try
            {
                var conn = GetConnection();
                if (_localConnection)
                    return conn.QueryFirstOrDefault<T>(sql, param);

                return conn.QueryFirstOrDefault<T>(sql, param, _Transaction);
            }
            finally
            {
                DisposeIfLocalConnection();
            }
        }
        #endregion

        #region Private or Protected Methods
        /// <summary>
        /// Obtém a Conexão caso já exista ou cria uma nova.
        /// </summary>
        /// <returns></returns>
        protected DbConnection GetConnection()
        {
            if (this.Connection != null)
                return Connection;

            _localConnection = true;
            this.Connection = new ConnectionFactory().GetOpenBDConnection();
            return Connection;
        }
        /// <summary>
        /// Dispose em caso de conexão local.
        /// </summary>
        protected void DisposeIfLocalConnection()
        {
            if (_localConnection)
            {
                this.Connection.Dispose();
                this.Connection = null;
            }
        }
        
        #endregion
    }
}
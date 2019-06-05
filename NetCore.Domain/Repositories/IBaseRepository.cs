using System.Data;
using System.Data.Common;

namespace NetCore.Domain.Repositories
{
    public interface IBaseRepository
    {
        /// <summary>
        /// Atribui uma transação externa ao repositório.
        /// </summary>
        /// <param name="transaction"></param>
        void SetTransaction(DbTransaction transaction);
        /// <summary>
        /// Executa um comando no dapper.
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        int Execute(string sql, object param = null);
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
        T QueryFirstOrDefault<T>(string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null);
    }
}
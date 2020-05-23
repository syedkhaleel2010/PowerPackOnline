using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace DbConnection
{
    public abstract class SqlRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private EDbConnectionTypes _dbType;
        private readonly IConfiguration _config;

        public SqlRepository(IConfiguration configuration)
        {
            _dbType = EDbConnectionTypes.Sql;
            _config = configuration;
        }

        public IDbConnection GetOpenConnection()
        {
            return DbConnectionFactory.GetDbConnection(_dbType, _config.GetConnectionString("PowerPackConStr"));
        }

        public abstract void DeleteAsync(int id);
        public abstract Task<IEnumerable<TEntity>> GetAllAsync();
        public abstract Task<TEntity> GetAsync(int id);
        public abstract void InsertAsync(TEntity entity);
        public abstract void UpdateAsync(TEntity entityToUpdate);
    }
}

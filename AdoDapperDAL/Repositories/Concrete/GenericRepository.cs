using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using AdoDapperDAL.Connection.Abstract;
using AdoDapperDAL.Exceptions;
using AdoDapperDAL.Repositories.Abstract;
using Dapper;
using Dapper.Contrib.Extensions;

namespace AdoDapperDAL.Repositories.Concrete
{
    public abstract class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        protected readonly IDbConnection Connection;

        protected GenericRepository(IConnectionFactory connectionFactory)
        {
            Connection = connectionFactory.GetConnection();
            Connection.Open();
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            const string sql = "EXEC [GetAllProc] @Table_Name";
            var tableAttribute =
                (TableAttribute) Attribute.GetCustomAttribute(typeof(TEntity), typeof (TableAttribute))!;
            var values = new { Table_Name = tableAttribute.Name};
            IEnumerable<TEntity> results = await Connection.QueryAsync<TEntity>(sql, values);
            
            return results;
        }

        public virtual async Task<TEntity> GetByIdAsync(int id)
        {
            const string? sql = "EXEC [GetByIdProc] @Table_Name, @Id";
            var tableAttribute =
                (TableAttribute) Attribute.GetCustomAttribute(typeof(TEntity), typeof (TableAttribute))!;
            var values = new { Table_Name = tableAttribute.Name, Id = id};
            var result = await Connection.QueryFirstOrDefaultAsync<TEntity>(sql, values);
            
            return result ?? throw new EntityNotFoundException(typeof(TEntity).Name, id);
        }
        
        public virtual async Task<int> InsertAsync(TEntity entity)
        {
            var propInfo = entity.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public)
                .FirstOrDefault(x => x.Name.Equals("Id"));

            if(propInfo != null)
                propInfo.SetValue(entity, 0);
            
            return await Connection.InsertAsync(entity);
        }

        public virtual async Task<bool> UpdateAsync(TEntity entity)
        {
            var propInfo = entity.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public)
                .FirstOrDefault(x => x.Name.Equals("Id"));

            var exception = new EntityNotFoundException(typeof(TEntity).Name, "empty");

            if (propInfo != null)
            {
                var idObj = propInfo.GetValue(entity) ?? throw exception;
                await GetByIdAsync((int) idObj);
            }
            else
                throw exception;

            return await Connection.UpdateAsync(entity);
        }

        public virtual async Task DeleteByIdAsync(int id)
        {
            await GetByIdAsync(id);

            const string sql = "EXEC [DeleteByIdProc] @Table_Name, @Id";
            var tableAttribute =
                (TableAttribute) Attribute.GetCustomAttribute(typeof(TEntity), typeof (TableAttribute))!;
            var values = new { Table_Name = tableAttribute.Name, Id = id };
            await Connection.ExecuteAsync(sql, values);
        }
        
        public void Dispose()
        {
            Connection.Close();
            Connection.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}

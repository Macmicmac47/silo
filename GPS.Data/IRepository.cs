using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace GPS.Data
{
    public interface IRepository<T> where T:BaseEntity
    {
        IQueryable<T> GetAll();
        T Get(long id);
        IQueryable<T> GetQueryable(long id);
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
        void InsertWithStoredProcedure(string commandText, params object[] parameters);
        IList<T> GetListwithStoredProcedure<T>(string storedProcedure,
              List<SqlParameter> parameters);
    }
}

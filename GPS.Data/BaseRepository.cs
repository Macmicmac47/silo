using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace GPS.Data
{
    public class BaseRepository<T>:IRepository<T> where T:BaseEntity
    {
        private readonly GPSContext context;
        private DbSet<T> entities;
        string errorMessage = string.Empty;

        public BaseRepository(GPSContext context)
        {
            this.context = context;
            entities = context.Set<T>();
        }
        public IQueryable<T> GetAll()
        {
            return entities.AsQueryable();
        }

        public T Get(long id)
        {
            return entities.Find(id);
        }
        public IQueryable<T> GetQueryable(long id)
        {
            return entities.Where(x => x.Id == id).AsQueryable();
        }
        public void Insert(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Add(entity);
            SaveChange();
        }

        public void Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            SaveChange();
        }

        public void Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Remove(entity);
            SaveChange();
        }
        private void SaveChange()
        {
            context.SaveChanges();
        }

        public void InsertWithStoredProcedure(string commandText, params object[] parameters)
        {
            context.ExecuteStoredProcedureInsert<T>(commandText, parameters);
        }

        public IList<T> GetListwithStoredProcedure<T>(string storedProcedure, List<SqlParameter> parameters)
        {
           var resultset= context.ExecuteStoredProcedureforList<T>(storedProcedure, parameters);
            return resultset.ToList();
        }
    }
}

   
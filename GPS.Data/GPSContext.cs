using GPS.Core.Domain;
using GPS.Data.Map;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Reflection;

namespace GPS.Data
{
    public class GPSContext : DbContext
    {
        public GPSContext(DbContextOptions<GPSContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            new HospitalMap(modelBuilder.Entity<Hospital>());
            new CountryMap(modelBuilder.Entity<Country>());
            new ProfessionalCategoryMap(modelBuilder.Entity<ProfessionalCategory>());
            new DemographicMap(modelBuilder.Entity<Demographic>());
            new DepartmentMap(modelBuilder.Entity<Department>());
        }

        public void ExecuteStoredProcedureInsert<T>(string commandText, params object[] parameters) 
        {
            Database.ExecuteSqlCommand(commandText, parameters);
        }

        public IList<T> ExecuteStoredProcedureforList<T>(string storedProcedure,
              List<SqlParameter> parameters)

        {
            using (var cmd = Database.GetDbConnection().CreateCommand())
            {
                cmd.CommandText = storedProcedure;
                cmd.CommandType = CommandType.StoredProcedure;
                if (parameters != null)
                {


                    foreach (var parameter in parameters)
                    {
                        cmd.Parameters.Add(parameter);
                    }
                }

                if (cmd.Connection.State != ConnectionState.Open)
                    cmd.Connection.Open();

                using (var dataReader = cmd.ExecuteReader())
                {
                    var resultset = DataReaderMapToList<T>(dataReader);
                    return resultset;
                }
            }


        }

        private static List<T> DataReaderMapToList<T>(DbDataReader dr)
        {
            List<T> list = new List<T>();
            while (dr.Read())
            {
                var obj = Activator.CreateInstance<T>();
                foreach (PropertyInfo prop in obj.GetType().GetProperties())
                {
                    if (prop.Name != "Id")
                    {
                        if (dr[prop.Name] !=null && !Equals(dr[prop.Name], DBNull.Value))
                        {
                            prop.SetValue(obj, dr[prop.Name], null);
                        }
                    }
                }
                list.Add(obj);
            }
            return list;
        }
    }
}

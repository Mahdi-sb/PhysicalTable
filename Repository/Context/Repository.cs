using Infrastructure.DTO;
using Microsoft.EntityFrameworkCore;
using Repository.Query;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Context
{
    public class Repository : IRepository
    {
        private readonly AppDBContext _Context;
        public Repository(AppDBContext Context)
        {
            _Context = Context;
        }

        public void CreateTable(string query)
        {
            _Context.Database.ExecuteSqlRaw(query);
        }

        public List<string> AllTableNameInDB()
        {
            var command = _Context.Database.GetDbConnection().CreateCommand();
            command.CommandText = SqlQuery.AllTableName;
            _Context.Database.OpenConnection();
            var result = command.ExecuteReader();
            var TableName = new List<string>();
            while (result.Read())
            {
                TableName.Add(result.GetString(0));
            }
            _Context.Database.CloseConnection();
            return TableName;
            

        }

        public List<(string,string)> AllColumnOfTable(string Table)
        {
            var command = _Context.Database.GetDbConnection().CreateCommand();
            command.CommandText = SqlQuery.AllColumn(Table);
            _Context.Database.OpenConnection();
            var result = command.ExecuteReader();
            var TableName = new List<(string ,string)>();
            while (result.Read())
            {
               // if (result.GetString(0) == "Id") continue;
                TableName.Add((result.GetString(0) , result.GetString(1) ));
            }
            _Context.Database.CloseConnection();
            return TableName;
        }

        public void Insert(string query)
        {
            _Context.Database.ExecuteSqlRaw(query);
        }

        public List<string> AllValueOfTable(string name , int count)
        {
            var command = _Context.Database.GetDbConnection().CreateCommand();
            command.CommandText = SqlQuery.AllData(name);
            _Context.Database.OpenConnection();
            var result = command.ExecuteReader();
            var TableName = new List<string>();
            while (result.Read())
            {
                for (int i = 0; i < count; i++)
                {
                    TableName.Add(result.GetValue(i).ToString());
                }
            }
            _Context.Database.CloseConnection();
            
            return TableName;
        }

    }
}

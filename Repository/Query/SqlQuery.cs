using Infrastructure.DTO;
using Infrastructure.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Query
{
     public class SqlQuery
    {

        public static string CreateTable(TableDTO Table)
        {
            string query = "CREATE TABLE " + Table.TableName + " (";
            foreach (var item in Table.TypeList)
            {
                if (item.Type == ColumnTypes.STRING)
                {
                    query += item.ColumnName + " NVARCHAR(MAX),";
                    continue;

                }
                if (item.Type == ColumnTypes.BOOL)
                {
                    query += item.ColumnName + " BIT,";
                    continue;

                }
                query += item.ColumnName + " " + item.Type + ",";
            }
            query += ");";
            return query;
        }

        public static string AllTableName = "SELECT TABLE_NAME FROM information_schema.tables; ";

        public static string AllColumn(string name)
        {
            return "SELECT COLUMN_NAME , DATA_TYPE FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '" + name + "';";
        }
        public static string AllData(string name)
        {
            return "SELECT * FROM " + name;
        }

        public static string Insert(List<TypesDTO> type , string name)
        {
            string query = "INSERT INTO " + name + " VALUES ( ";//value1, value2, value3, ...);";
            
            for (int i = 0; i < type.Count; i++)
            {

                if (i + 1 == type.Count) 
                {
                    if (type[i].FieldType == ColumnTypes.INT)
                    {
                        query += type[i].Value + ")";
                        continue;
                    }
                    query +="'"+ type[i].Value+"')"; 
                    continue; 
                }
                if (type[i].FieldType == ColumnTypes.INT) { query += type[i].Value + ","; continue; }
 
                query += "'"+type[i].Value + "',";
                
            }
            return query;
        }
    }
}

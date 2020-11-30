using Infrastructure.DTO;
using Infrastructure.Enum;
using PhysicalTable.ViewModel;
using System.Collections.Generic;

namespace PhysicalTable.Mapper
{
    public class Map
    {
       static public TableDTO TableList(TableView tables)
        {
            TableDTO list = new TableDTO();
            var types = new List<(ColumnTypes,string)>();
            foreach (var item in tables.TypeList)
            {
                types.Add((item.Type,item.ColumnName));
            }
            list.TableName = tables.TableName;
            list.TypeList=types;
            return list;
        }

       static public List<TypesDTO> TypeList(List<(string Column,string Types)> types , string name)
        {
            List<TypesDTO> list = new List<TypesDTO>();
            foreach (var item in types)
            {
                list.Add(new TypesDTO(item.Column, FindType(item.Types),"",name));
            }
            return list;
        }

         static ColumnTypes FindType(string type)
        {
            if (type == "nvarchar") return ColumnTypes.STRING;
            if (type == "bit") return ColumnTypes.BOOL;
            return ColumnTypes.INT;
        }

        static public List<TypesDTO> TypeList(List<TypesDTO> types , string name )
        {
            var list = new List<TypesDTO>();
            foreach (var item in types)
            {
                list.Add(new TypesDTO(item.FieldName, item.FieldType, item.Value, name));
            }
            return list;
        }


        public static List<string> ColumnList(List<(string column,string)> column)
        {
            var list = new List<string>();
            foreach (var item in column)
            {
                list.Add(item.column);
            }
            return list;
        }

        public static List<ShowDTO> valueList(List<string> value )
        {
            var list = new List<ShowDTO>();
            foreach (var item in value)
            {
                list.Add(new ShowDTO(item));
            }
            return list;
        }

    }

}

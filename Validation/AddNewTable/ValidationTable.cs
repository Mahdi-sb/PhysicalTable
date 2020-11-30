
using Infrastructure;
using Infrastructure.DTO;
using Repository.Context;
using System.Collections.Generic;

namespace Validation.AddNewTable
{
    public class ValidationTable : ICheckTableInput
    {
        IRepository _repo;
        public ValidationTable(IRepository repo)
        {
            _repo = repo;
        }

        public string CheckAllinput(TableDTO table)
        {
            if (CheckTableName(table.TableName) != Massage.IsOk) return CheckTableName(table.TableName);
            if (ColumnName(table) != Massage.IsOk) return ColumnName(table);
            if (NumberOfColumn(table) != Massage.IsOk) return NumberOfColumn(table);
            return Massage.IsOk;
        }

        public string CheckTableName(string TableName)
        {
            
            return _repo.AllTableNameInDB().Contains(TableName) ? Massage.RepetitiveTableName : Massage.IsOk;
        }

        public string ColumnName(TableDTO table)
        {
            var name = " ";
            foreach (var item in table.TypeList)
            {

                if (item.ColumnName == name)
                {
                    return Massage.RepetitiveColumnName;
                }
                name = item.ColumnName;
            }
            return Massage.IsOk;
        }

        public string NumberOfColumn(TableDTO Types)
        {
            return Types.TypeList.Count== 0 ? Massage.AddColumn : Massage.IsOk;


        }

        //public string CheckAllinput(List<TypesDTO> Types, string TableName)
        //{
        //    if (CheckTableName(TableName) != Massage.IsOk) return CheckTableName(TableName);
        //    if (ColumnName(Types) != Massage.IsOk) return ColumnName(Types);
        //    if (NumberOfColumn(Types) != Massage.IsOk) return NumberOfColumn(Types);
        //    return Massage.IsOk;

        //}

        //public string CheckTableName(string TableName)
        //{
        //    return _db.Tables.FindValue(x => x.TableName == TableName) ?
        //    Massage.RepetitiveTableName : Massage.IsOk;
        //}

        //public string ColumnName(List<TypesDTO> Types)
        //{
        //    var name = " ";
        //    foreach (var item in Types)
        //    {

        //        if (item.FieldName == name)
        //        {
        //            return Massage.RepetitiveColumnName;
        //        }
        //        name = item.FieldName;
        //    }
        //    return Massage.IsOk;
        //}

        //public string NumberOfColumn(List<TypesDTO> Types)
        //{
        //    return Types.Count == 0 ? Massage.AddColumn : Massage.IsOk;
        //}
    }
}

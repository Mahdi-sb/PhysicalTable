using Infrastructure;
using Infrastructure.DTO;
using Repository.Context;
using Repository.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Validation.AddValueToDB;

namespace Service.AddValueToDB
{
    public class AddValue : IAddValue
    {
        IRepository _repo;
        ICheckValue _check;
        public AddValue(IRepository repo , ICheckValue check)
        {
            _repo = repo;
            _check = check;
        }

        public string AddValueToTable(List<TypesDTO> types , string TableName)
        {
            if (_check.CheckValues(types) != Massage.IsOk) return _check.CheckValues(types);
            _repo.Insert(SqlQuery.Insert(types,TableName));
            return Massage.IsOk;
        }

        public List<(string column, string type)> AllColumn(string name)
        {
            return _repo.AllColumnOfTable(name);
        }

        public List<string> AllTable()
        {
            var list = _repo.AllTableNameInDB().Where(x=>x!="Times").ToList();
            return list;
        }



    }
}


using Infrastructure;
using Infrastructure.DTO;
using Repository.Context;
using Repository.Query;
using Validation.AddNewTable;

namespace Service.AddNewTable
{
    public class AddTable :IAddtable
    {
        IRepository _repo;
        ICheckTableInput _check;
        public AddTable(IRepository repo , ICheckTableInput check)
        {
            _repo = repo;
            _check = check;
        }

        public string AddTableToDB( TableDTO table)
        {
            if (_check.CheckAllinput(table) != Massage.IsOk) return _check.CheckAllinput(table);
            _repo.CreateTable(SqlQuery.CreateTable(table));
            return Massage.IsOk;
        }
    }
}

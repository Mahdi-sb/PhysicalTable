using Repository.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.ShowValueOfTable
{
    public class ShowValue : IShowValue
    {
        IRepository _repo;
        public ShowValue(IRepository repo)
        {
            _repo = repo;
        }
        public List<(string , string)> AllColumn(string name)
        {
            return _repo.AllColumnOfTable(name);
        }

        public List<string> AllValue(string name , int count)
        {
            return _repo.AllValueOfTable(name,count);
        }
    }
}

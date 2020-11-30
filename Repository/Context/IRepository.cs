using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Context
{
   public interface IRepository
    {
        void CreateTable(string query);
        public List<string> AllTableNameInDB();
        public List<(string, string)> AllColumnOfTable(string Table);
        public List<string> AllValueOfTable(string name, int count);
        void Insert(string query);


    }
}

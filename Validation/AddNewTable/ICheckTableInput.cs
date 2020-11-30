using Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Validation.AddNewTable
{
   public interface ICheckTableInput 
    {
        public string ColumnName(TableDTO table);
        public string NumberOfColumn(TableDTO Types);
        public string CheckTableName(string TableName);
        public string CheckAllinput(TableDTO table);




    }
}

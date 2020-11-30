using Infrastructure.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.DTO
{
   public class TableDTO
    {
        
        public string TableName { get; set; }
        public List<(ColumnTypes Type ,string ColumnName)> TypeList { get; set; }
        


    }
}

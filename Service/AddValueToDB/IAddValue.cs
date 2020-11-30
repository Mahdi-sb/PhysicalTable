using Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.AddValueToDB
{
    public interface IAddValue
    {
        List<string> AllTable();
        List<(string column, string type)> AllColumn(string name);

        string AddValueToTable(List<TypesDTO> types , string TableName);
    }
}

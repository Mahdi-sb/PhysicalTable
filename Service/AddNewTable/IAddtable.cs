using Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.AddNewTable
{
    public interface IAddtable
    {


        string AddTableToDB(TableDTO table);


    }
}

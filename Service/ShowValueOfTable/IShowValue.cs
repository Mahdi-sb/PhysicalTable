using System;
using System.Collections.Generic;
using System.Text;

namespace Service.ShowValueOfTable
{
    public interface IShowValue
    {

        List<(string , string)> AllColumn(string name);
        List<string> AllValue(string name, int count);

    }
}

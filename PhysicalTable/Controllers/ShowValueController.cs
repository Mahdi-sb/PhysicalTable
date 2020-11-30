using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PhysicalTable.Mapper;
using Service.ShowValueOfTable;

namespace PhysicalTable.Controllers
{
    public class ShowValueController : Controller
    {
        IShowValue _service;
        public ShowValueController(IShowValue service)
        {
            _service = service;
        }
        /// <summary>
        /// show data of table 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult ShowData(string TableName)
        {
            var Column = Map.ColumnList(_service.AllColumn(TableName));
            ViewData["column"] = Column;
            var values = Map.valueList(_service.AllValue(TableName,Column.Count));
           //var values = _map.ValueList(_service.ValueOfTable(id));
            return View(values);
        }
    }
}

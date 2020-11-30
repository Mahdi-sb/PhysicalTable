using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infrastructure;
using Infrastructure.DTO;
using Microsoft.AspNetCore.Mvc;
using PhysicalTable.Mapper;
using Service.AddValueToDB;

namespace PhysicalTable.Controllers
{
    public class AddValueController : Controller
    {
        IAddValue _service;
        public AddValueController(IAddValue service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult ChooseTable()
        {
            var list = _service.AllTable();
            return View(list);
        }


        [HttpGet]
        public IActionResult AddDataInTable(string TableName)
        {

            var list =Map.TypeList( _service.AllColumn(TableName), TableName);
            return View(list);
        }

        [HttpPost]
        public IActionResult AddDataInTable(List<TypesDTO> values, string TableName)
        {
            var model = Map.TypeList(values , TableName);
            if (ModelState.IsValid)
            {
                string error = _service.AddValueToTable(values, TableName);
                if (error != Massage.IsOk)
                {
                    ViewData["ErrorMessage"] = error;
                    return View(model);
                }
                return RedirectToAction("Index", "Home");
            }
            ViewData["ErrorMessage"] = Massage.FillFields;
            return View(model);
        }





    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;
using PhysicalTable.Mapper;
using PhysicalTable.ViewModel;
using Service.AddNewTable;

namespace PhysicalTable.Controllers
{
    public class AddNewTableController : Controller
    {
        IAddtable _service;
        public AddNewTableController(IAddtable service)
        {
            _service = service;
        }





        [HttpGet]
        public IActionResult AddTable()
        {
            TableView ViewModel = new TableView();

            return View(ViewModel);
        }

        [HttpPost]
        public IActionResult AddTable(TableView model)
        {

            if (ModelState.IsValid)
            {
                var error = _service.AddTableToDB(Map.TableList(model));
                if (error != Massage.IsOk)
                {
                    ViewData["ErrorMessage"] = error;
                    return View("AddTable", model);
                }
                return RedirectToAction("Index", "Home");
            }
            return View("AddTable", model);   
        }
    }
}

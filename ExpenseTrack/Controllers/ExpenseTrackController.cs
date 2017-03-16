using ExpenseTrack.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExpenseTrack.Controllers
{
    public class ExpenseTrackController : Controller
    {
        // GET: ExpenseTrack
        public ActionResult Index()
        {
            ViewBag.Message = "類別";
            var items = new List<SelectListItem> {
                new SelectListItem { Text = "支出", Value = "1" },
                new SelectListItem { Text = "收入", Value = "2" }, };

            ViewBag.CategoryItems = items;
            return View();
            
        }

        public ActionResult ExpenseList()
        {
            
            ExpenseList t = new ExpenseList();
            var myList = t.GetData();
          //  ViewData["ViewDataTest"] = myList;
            return PartialView(myList);

        }
    }
}
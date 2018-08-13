using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcGridApp.Models;
using System.IO;
using System.Web.UI.WebControls;

namespace MvcGridApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Welcome to ASP.NET MVC!";
            CarModels cm = new CarModels();
            List<Cars> model = cm.getAllCars();

            GridView gv = new GridView();
            gv.DataSource = model;
            gv.DataBind();
            Session["Cars"] = gv;

            return View(model);
        }

        public ActionResult Download()
        {
            if (Session["Cars"] != null)
            {
                return new DownloadFileActionResult((GridView)Session["Cars"], "Cars.xls");
            }
            else 
            {
                return new JavaScriptResult();
            }
        }


        public ActionResult About()
        {
            return View();
        }
    }
}

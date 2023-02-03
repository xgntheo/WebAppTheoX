using WebAppTheo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebAppTheo.Controllers
{
    public class ClientController : Controller
    {

        // GET: Client
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Ajout_Client()
        {
            ViewBag.Message = "Ajouter de nouveaux clients";

            return View();
        }
    }
}
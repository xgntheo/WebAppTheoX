using WebAppTheo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebAppTheo.Controllers
{
    public class FormController : Controller
    {
        DevTestTXEntities db = new DevTestTXEntities();

        // GET: Form
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Formulaire()
        {
            try
            {
                ViewBag.Message = "Entrer les informations de maintenance";

                ViewBag.listeClient = db.Client.ToList();
                ViewBag.listFormulaire = db.Formulaire.ToList();
                return View();
            }
            catch
            {
                return HttpNotFound();
            }

        }

        [HttpPost]
        public ActionResult Formulaire(Formulaire form)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //form.Prix = 
                    db.Formulaire.Add(form);
                    db.SaveChanges();
                }

                return RedirectToAction("Formulaire");
            }
            catch
            {

                return HttpNotFound();

            }

        }

    }
}
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
        DevTestTXEntities1 db = new DevTestTXEntities1();

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

                ViewBag.listeEquipement = db.Equipement.ToList();
                ViewBag.listeTechnicien = db.Technicien.ToList();
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
        public ActionResult Formulaire(Formulaire form, Equipement equipm)
        {
            //var Temps = form.TempsMinute; //L'information entré dans le form

            if (ModelState.IsValid)
            {
                if(form.IdEquipm == 2)
                {
                    equipm.NomEquipm = "Vélo";
                }
                else
                {
                    equipm.NomEquipm = "Ski";
                }
                
                db.Equipement.Add(equipm);
                db.SaveChanges();


                form.IdEquipm = equipm.IdEquipm;
            }

            //try
            //{
            if (ModelState.IsValid)
            {
                if(equipm.NomEquipm == "Vélo")//ID Vélo
                {
                    

                    if (form.TypeMaintenance == "Révision")//Révision
                    {
                        form.TempsMinute = 45;
                        form.Prix = 50;
                    }
                    else if(form.TypeMaintenance == "Réparation")//Réparation perso
                    {
                        if (form.ReparationDiverse == "Pneu/Câble de frein")
                        {
                            form.Prix = (form.TempsMinute * 1) + 30 + 15;
                        }
                        else if (form.ReparationDiverse == "Pneu")
                        {
                            form.Prix = (form.TempsMinute * 1) + 30;
                        }
                        else if (form.ReparationDiverse == "Câble de frein")
                        {
                            form.Prix = (form.TempsMinute * 1) + 15;
                        }
                    }
                }
                else if (equipm.NomEquipm == "Ski")//ID Ski
                {
                    //form.IdEquipm = equipm.IdEquipm; //??

                    if (form.TypeMaintenance == "Révision")//Revision
                    {
                        form.TempsMinute = 15;
                        form.Prix = 20;
                    }
                    else if (form.TypeMaintenance == "Réparation")//Réparation perso
                    {
                        if (form.ReparationDiverse == "Fixation complète/Semelle")
                        {
                            form.Prix = (form.TempsMinute * 1) +50 + 20;
                        }
                        else if (form.ReparationDiverse == "Fixation complète")
                        {
                            form.Prix = (form.TempsMinute * 1) + 50;
                        }
                        else if (form.ReparationDiverse == "Semelle")
                        {
                            form.Prix = (form.TempsMinute * 1) + 20;
                        }
                    }
                }

                form.DateAjout = DateTime.Now;
                db.Formulaire.Add(form);
                db.SaveChanges();
            }

            return RedirectToAction("Formulaire");
            //}
            //catch
            //{

            //    return HttpNotFound();

            //}

        }

    }
}
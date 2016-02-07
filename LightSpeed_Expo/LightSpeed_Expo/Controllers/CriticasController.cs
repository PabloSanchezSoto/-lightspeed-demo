using LightSpeed_Expo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LightSpeed_Expo.Controllers
{
    public class CriticasController : Controller
    {
        //
        // GET: /Criticas/Create
        public ActionResult Create(int id)
        {
            ViewBag.backId = id;
            return View();
        } 

        //
        // POST: /Criticas/Create
        [HttpPost]
        public ActionResult Create(Critica critica)
        {
            try
            {
                using (var uow = LightSpeed_Expo.MvcApplication.LightSpeedContext.CreateUnitOfWork())
                {
                    uow.Add(critica);
                    uow.SaveChanges();
                }
                return RedirectToAction("../Peliculas/Details/", new { id = critica.PeliculaId });
            }
            catch
            {
                return View();
            }
        }
    }
}

using LightSpeed_Expo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace LightSpeed_Expo.Controllers
{
    public class PeliculasController : Controller
    {
        //
        // GET: /Peliculas/
        public ActionResult Index()
        {
            using (var uow = LightSpeed_Expo.MvcApplication.LightSpeedContext.CreateUnitOfWork())
            {
                return View(uow.Peliculas.ToList());

                //foreach (var movie in uow.Movies.OrderBy(m => m.CreatedOn))
                //{
                //    Console.WriteLine("{0} - comment count: {1}", movie.Title, movie.Comments.Count());
                //}

            }
        }

        //
        // GET: /Peliculas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(400);
            }

            using (var uow = LightSpeed_Expo.MvcApplication.LightSpeedContext.CreateUnitOfWork())
            {
                Pelicula pelicula = uow.Peliculas.FirstOrDefault(p => p.Id == id);
                var criticas = pelicula.Criticas;
                if (pelicula == null)
                {
                    return HttpNotFound();
                }
                ViewBag.criticas = criticas;
                return View(pelicula);
            }
        }

        //
        // GET: /Peliculas/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Peliculas/Create
        [HttpPost]
        public ActionResult Create(Pelicula pelicula)
        {
            try
            {
                using (var uow = LightSpeed_Expo.MvcApplication.LightSpeedContext.CreateUnitOfWork())
                {
                    uow.Add(pelicula);
                    uow.SaveChanges();
                    uow.Dispose();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Peliculas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(400);
            }

            using (var uow = LightSpeed_Expo.MvcApplication.LightSpeedContext.CreateUnitOfWork())
            {
                Pelicula pelicula = uow.Peliculas.FirstOrDefault(p => p.Id == id);
                if (pelicula == null)
                {
                    return HttpNotFound();
                }
                return View(pelicula);
            }
        }

        //
        // POST: /Peliculas/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Pelicula pelicula)
        {
            using (var uow = LightSpeed_Expo.MvcApplication.LightSpeedContext.CreateUnitOfWork())
            {
                try
                {
                    if (ModelState.IsValid)
                    {
                        Pelicula peliculaOriginal = uow.Peliculas.FirstOrDefault(p => p.Id == id);
                        if (peliculaOriginal == null)
                        {
                            return HttpNotFound();
                        }
                        peliculaOriginal.Titulo      = pelicula.Titulo;
                        peliculaOriginal.Descripcion = pelicula.Descripcion;
                        uow.SaveChanges();
                        return RedirectToAction("Index");
                    }
                    return View(pelicula);
                }
                catch
                {
                    return View(pelicula);
                }
            }
        }

        //
        // GET: /Peliculas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(400);
            }
            using(var uow = LightSpeed_Expo.MvcApplication.LightSpeedContext.CreateUnitOfWork())
	        {
                Pelicula pelicula = uow.Peliculas.FirstOrDefault(p => p.Id == id);
                if (pelicula == null)
                {
                    return HttpNotFound();
                }
                return View(pelicula);
	        }
        }

        //
        // POST: /Peliculas/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            using (var uow = LightSpeed_Expo.MvcApplication.LightSpeedContext.CreateUnitOfWork())
            {
                try
                {
                    Pelicula pelicula = uow.Peliculas.FirstOrDefault(p => p.Id == id);
                    if (pelicula == null)
                    {
                        return HttpNotFound();
                    }
                    uow.Remove(pelicula);
                    uow.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch
                {
                    return View();
                }
            }
        }
    }
}

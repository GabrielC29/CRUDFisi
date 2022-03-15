using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CRUDFisi.Models;
using CRUDFisi.Models.ViewModels;

namespace CRUDFisi.Controllers
{
    public class AlumnosController : Controller
    {
        // GET: Alumnos
        public ActionResult Index()
        {

            List<ListAlumnosViewModel> lst;
            using(FisiEntities db = new FisiEntities())
            {
                lst = (from p in db.alumnos
                          select new ListAlumnosViewModel
                          {
                              Id = p.id,
                              Nombre = p.nombre,
                              Apellido = p.apellido,
                              Codigo = p.codigo,

                          }).ToList();
            }

            return View(lst);
        }
        
        public ActionResult Nuevo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Nuevo(AlumnosViewModel model)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    using(FisiEntities db = new FisiEntities())
                    {
                        var oAlumnos = new alumnos();
                        oAlumnos.nombre = model.Nombre;
                        oAlumnos.apellido = model.Apellido;
                        oAlumnos.codigo = model.Codigo;

                        db.alumnos.Add(oAlumnos);
                        db.SaveChanges();
                    }

                    return Redirect("~/Alumnos/");

                }

                return View(model);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public ActionResult Editar(int id)
        {
            AlumnosViewModel model = new AlumnosViewModel();
            using(FisiEntities db = new FisiEntities())
            {
                var oAlumnos = db.alumnos.Find(id);
                model.Nombre = oAlumnos.nombre;
                model.Apellido = oAlumnos.apellido;
                model.Codigo = oAlumnos.codigo;
                model.Id = oAlumnos.id;
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult Editar(AlumnosViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (FisiEntities db = new FisiEntities())
                    {
                        var oAlumnos = db.alumnos.Find(model.Id);
                        oAlumnos.nombre = model.Nombre;
                        oAlumnos.apellido = model.Apellido;
                        oAlumnos.codigo = model.Codigo;

                        db.Entry(oAlumnos).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                    }

                    return Redirect("~/Alumnos/");

                }

                return View(model);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet]
        public ActionResult Eliminar(int id)
        {
            AlumnosViewModel model = new AlumnosViewModel();
            using (FisiEntities db = new FisiEntities())
            {
                var oAlumnos = db.alumnos.Find(id);
                db.alumnos.Remove(oAlumnos);
                db.SaveChanges();
            }

            return Redirect("~/Alumnos/");
        }
    }
}
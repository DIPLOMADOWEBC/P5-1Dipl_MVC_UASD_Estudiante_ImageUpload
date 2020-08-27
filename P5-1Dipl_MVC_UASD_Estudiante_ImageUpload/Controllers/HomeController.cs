using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace P5_1Dipl_MVC_UASD_Estudiante_ImageUpload.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Estudiantes()
        {
            return View();
        }

        public ActionResult Detalle()
        {
            return View();
        }

        public ActionResult FileUpload(HttpPostedFileBase file)
        {
            if (file != null)
            {
                EmpleadosDB1Entities db = new EmpleadosDB1Entities();
                string ImageName = System.IO.Path.GetFileName(file.FileName);
                string physicalPath = Server.MapPath("~/Images/" + ImageName);
                file.SaveAs(physicalPath);
                tblEstudiante estudiante = new tblEstudiante();
                estudiante.Nombres = Request.Form["Nombres"];
                estudiante.Apellidos = Request.Form["Apellidos"];
                estudiante.Direccion = Request.Form["Direccion"];
                estudiante.Telefono = Request.Form["Telefono"];
                estudiante.Cedula = Request.Form["Cedula"];
                estudiante.ImagenUrl = ImageName;
                if (TryValidateModel(estudiante))
                {
                    db.tblEstudiante.Add(estudiante);
                    db.SaveChanges();
                    return RedirectToAction("../home/Detalle/");
                }
                else
                {
                    return View("../home/Estudiantes", estudiante);
                }
            }
            return RedirectToAction("../home/Detalle/");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
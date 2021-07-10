using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExamenFinal.DB;
using ExamenFinal.Models;
using Microsoft.AspNetCore.Mvc;

namespace ExamenFinal.Controllers
{
    public class ContactoController : Controller
    {
        private AppContextDB context;
        public ContactoController(AppContextDB context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            var contactos = context.Contactos.Where(a => a.Id_Usuario == getlooged().Id_User).ToList();
            return View(contactos);
        }
        public IActionResult Usuarios()
        {
            var usuarios = context.Usuarios.Where(a=>a.Id_User!=getlooged().Id_User).ToList();
            return View(usuarios);
        }
        public IActionResult EnviarSolicitud(int idamigo)
        {
            Solicitud solicitud = new Solicitud();
            solicitud.Id_Usuario_Origen = getlooged().Id_User;
            solicitud.Id_Usuario_Destino = idamigo;
            solicitud.Estado_Aceptacion = false;
            context.Solicitudes.Add(solicitud);
            context.SaveChanges();
            return RedirectToAction("Usuarios");
        }
        public IActionResult MisSolicitudes()
        {
            var solicitudes = context.Solicitudes.Where(a => a.Id_Usuario_Destino == getlooged().Id_User && a.Estado_Aceptacion == false).ToList();
            return View(solicitudes);
        }
        public IActionResult AceptarSolicitud(int idsolicitud)
        {
            
            var solicitud = context.Solicitudes.Find(idsolicitud);
            Contacto contacto = new Contacto();
            contacto.Id_Usuario = getlooged().Id_User;
            contacto.Id_Amigo = solicitud.Id_Usuario_Origen;
            context.Contactos.Add(contacto);
            context.SaveChanges();
            solicitud.Estado_Aceptacion = true;
            context.SaveChanges();
           

            return RedirectToAction("MisSolicitudes");
        }
        private User getlooged()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return null;
            }
            var claims = HttpContext.User.Claims.First();
            var listaClaims = claims.Subject.Claims.ToList();
            var id_usuario = listaClaims[0].Value;
            var usuario = context.Usuarios.Find(Convert.ToInt32(id_usuario));
            return usuario;
        }
    }
}

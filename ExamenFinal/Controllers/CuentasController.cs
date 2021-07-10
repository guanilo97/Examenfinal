using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExamenFinal.DB;
using ExamenFinal.Models;
using Microsoft.AspNetCore.Mvc;

namespace ExamenFinal.Controllers
{
    public class CuentasController : Controller
    {
        private AppContextDB context;
        public CuentasController(AppContextDB context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            var cuentas = context.Cuentas.Where(a => a.Id_Usuario == getlooged().Id_User).ToList();
            return View(cuentas);
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
        [HttpGet]
        public IActionResult Crear()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Crear(Cuenta cuenta)
        {
            cuenta.Id_Usuario = getlooged().Id_User;
            if (cuenta.Categoria == 2)
            {
                cuenta.Limite_Credito = cuenta.Saldo_Inicial;
            }
            else
            {
                cuenta.Limite_Credito = 0;
            }
            context.Cuentas.Add(cuenta);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}

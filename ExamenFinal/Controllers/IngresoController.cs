using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExamenFinal.DB;
using ExamenFinal.Models;
using Microsoft.AspNetCore.Mvc;

namespace ExamenFinal.Controllers
{
    public class IngresoController : Controller
    { 
    private AppContextDB context;
    public IngresoController(AppContextDB context)
    {
        this.context = context;
    }
    public IActionResult Index(int idcuenta)
    {
        ViewBag.Id_Cuenta = idcuenta;
        var ingresos = context.Ingresos.Where(a => a.Id_Cuenta==idcuenta).ToList();
        return View(ingresos);
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
    public IActionResult Crear(int idcuenta)
    {
            ViewBag.Id_Cuenta = idcuenta;
            return View();
    }
        [HttpPost]
        public IActionResult Crear(Ingreso ingreso, int idcuenta)
        {
            ViewBag.Id_Cuenta = idcuenta;
            var cuentaDB = context.Cuentas.Find(idcuenta);
            cuentaDB.Saldo_Inicial = cuentaDB.Saldo_Inicial + ingreso.Monto;
            context.SaveChanges();

            ingreso.Id_Cuenta = idcuenta;
            context.Ingresos.Add(ingreso);
            context.SaveChanges();
            return RedirectToAction("Index", new { idcuenta = idcuenta });
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExamenFinal.DB;
using ExamenFinal.Models;
using Microsoft.AspNetCore.Mvc;

namespace ExamenFinal.Controllers
{
    public class TransferenciaController : Controller
    {
        private AppContextDB context;
        public TransferenciaController(AppContextDB context)
        {
            this.context = context;
        }
        public IActionResult Index(int idcuenta)
        {
            ViewBag.Id_Cuenta = idcuenta;
            var transferencias = context.Transferencias.Where(a => a.Id_Usuario==getlooged().Id_User).ToList();
            return View(transferencias);
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
            ViewBag.CuentasOrigen = context.Cuentas.Where(a => a.Id_Usuario == getlooged().Id_User).ToList();
            ViewBag.CuentasDestino = context.Cuentas.Where(a => a.Id_Usuario == getlooged().Id_User).ToList();
            return View();
        }
        [HttpPost]
        public IActionResult Crear(Transferencia transferencia)
        {
            var cuentaorigenDB = context.Cuentas.Find(transferencia.Id_Cuenta_Origen);
            cuentaorigenDB.Saldo_Inicial = cuentaorigenDB.Saldo_Inicial - transferencia.Monto;
            context.SaveChanges();
            var cuentadestinoDB = context.Cuentas.Find(transferencia.Id_Cuenta_Destino);
            cuentadestinoDB.Saldo_Inicial = cuentadestinoDB.Saldo_Inicial + transferencia.Monto;
            context.SaveChanges();
            transferencia.Descripcion = "Transferencia";
            transferencia.Fecha_Hora = DateTime.Now;
            transferencia.Id_Usuario = getlooged().Id_User;
            context.Transferencias.Add(transferencia);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult TransferirAmigo( int idamigo)
        {
            ViewBag.idamigo = idamigo;
            ViewBag.CuentasOrigen = context.Cuentas.Where(a => a.Id_Usuario == getlooged().Id_User).ToList();
            ViewBag.cuentasdestino = context.Cuentas.Where(a => a.Id_Usuario == idamigo).ToList();
            return View();
        }
        [HttpPost]
        public IActionResult TransferirAmigo(Transferencia transferencia, int idamigo)
        {
            var cuentaorigenDB = context.Cuentas.Find(transferencia.Id_Cuenta_Origen);
            cuentaorigenDB.Saldo_Inicial = cuentaorigenDB.Saldo_Inicial - transferencia.Monto;
            context.SaveChanges();
            var cuentadestinoDB = context.Cuentas.Find(transferencia.Id_Cuenta_Destino);
            cuentadestinoDB.Saldo_Inicial = cuentadestinoDB.Saldo_Inicial + transferencia.Monto;
            context.SaveChanges();
            transferencia.Descripcion = "Transferencia";
            transferencia.Fecha_Hora = DateTime.Now;
            transferencia.Id_Usuario = getlooged().Id_User;
            context.Transferencias.Add(transferencia);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
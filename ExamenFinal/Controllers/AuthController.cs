using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using ExamenFinal.DB;
using ExamenFinal.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace ExamenFinal.Controllers
{
    public class AuthController : Controller
    {
        private AppContextDB context;
        private IConfiguration configurations;
        public AuthController(AppContextDB context, IConfiguration configurations)
        {
            this.context = context;
            this.configurations = configurations;
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            var usuario = context.Usuarios
               .FirstOrDefault(o => o.Username == username && o.Password == CreateHash(password));
            if (usuario == null)
            {
                TempData["AuthMessaje"] = "Correo o contraseña incorrectos";
                return RedirectToAction("Login");
            }
            else
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, usuario.Id_User.ToString())
                };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
                HttpContext.SignInAsync(claimsPrincipal);

                    return RedirectToAction("Index", "Cuentas");
            }
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(User user)
        {
            user.Password = CreateHash(user.Password);
            context.Usuarios.Add(user);
            context.SaveChanges();
            return RedirectToAction("Login", "Auth");
        }
        [HttpGet]
        public IActionResult Logaut()
        {
            HttpContext.SignOutAsync();
            return RedirectToAction("Login");
        }

        private string CreateHash(string input)
        {
            input += configurations.GetValue<string>("Key");
            var sha = SHA512.Create();
            var bytes = Encoding.Default.GetBytes(input);
            var hash = sha.ComputeHash(bytes);
            return Convert.ToBase64String(hash);
        }
    }
}

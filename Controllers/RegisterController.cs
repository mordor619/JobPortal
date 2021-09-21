using JobPortalDI.ProjModel;
using JobPortalDI.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobPortalDI.Controllers
{
    public class RegisterController : Controller
    {
        static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(RegisterController));

        private readonly ILogintblServ<Logintbl> serv;
        public RegisterController(ILogintblServ<Logintbl> _serv)
        {
            serv = _serv;
        }

        public IActionResult Register()
        {
            ViewBag.Username = HttpContext.Session.GetString("Username");
            ViewBag.Usertype = HttpContext.Session.GetString("Usertype");

            return View();
        }


        [HttpPost]
        public IActionResult Register(Logintbl obj)
        {

            try
            {
               
                serv.AddUser(obj);
            }
            catch (Exception)
            {
                ViewBag.errorReg = "**Username already exists!";

                //Console.WriteLine("\n" + ViewBag.errorReg + "\n");

                return View();
            }

            _log4net.Info("A new user registered!");

            return RedirectToAction("Login", "Login");
        }


    }
}

using JobPortalDI.ProjModel;
using JobPortalDI.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobPortalDI.Controllers
{
    public class DeleteMyJobController : Controller
    {
        private readonly IMyJobServ<Myjob> serv;

        public DeleteMyJobController() { }

        [ActivatorUtilitiesConstructor]
        public DeleteMyJobController(IMyJobServ<Myjob> _serv)
        {
            serv = _serv;
        }


        public IActionResult DeleteMyJob(int id)
        {
            ViewBag.Username = HttpContext.Session.GetString("Username");
            ViewBag.Usertype = HttpContext.Session.GetString("Usertype");



            serv.deleteMyJob(id);

            return RedirectToAction("Index", "Login");
        }
    }
}

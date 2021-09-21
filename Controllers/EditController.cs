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
    public class EditController : Controller
    {
        static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(EditController));

        private readonly IJobServ<Job> serv;

        public EditController() { }

        [ActivatorUtilitiesConstructor]
        public EditController(IJobServ<Job> _serv)
        {
            serv = _serv;
        }

        public IActionResult EditJob(int id)
        {
            ViewBag.Username = HttpContext.Session.GetString("Username");
            ViewBag.Usertype = HttpContext.Session.GetString("Usertype");

            Job j = serv.getJobById(id);

            

            return View(j);
        }


        [HttpPost]
        public IActionResult Edit(Job j)
        {
            ViewBag.Username = HttpContext.Session.GetString("Username");
            ViewBag.Usertype = HttpContext.Session.GetString("Usertype");


            serv.editJob(j);

            _log4net.Info("job data updated by " + ViewBag.Username);

            return RedirectToAction("Index", "Login");

        }



    }
}

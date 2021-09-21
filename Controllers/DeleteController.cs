using JobPortalDI.ProjModel;
using JobPortalDI.Repository;
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
    public class DeleteController : Controller
    {
        static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(DeleteController));

        private readonly IJobServ<Job> serv;

        public DeleteController() { }

        [ActivatorUtilitiesConstructor]
        public DeleteController(IJobServ<Job> _serv)
        {
            serv = _serv;
        }

        public IActionResult Delete(int id)
        {
            ViewBag.Username = HttpContext.Session.GetString("Username");
            ViewBag.Usertype = HttpContext.Session.GetString("Usertype");

            

            serv.deleteJob(id);

            _log4net.Info("job deleted with id " + id);

            return RedirectToAction("Index", "Login");
        }

        

    }
}

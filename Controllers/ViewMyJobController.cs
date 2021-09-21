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
    public class ViewMyJobController : Controller
    {
        public static List<Myjob> myJobs = new List<Myjob>();

        private readonly IMyJobServ<Myjob> serv;

        public ViewMyJobController() { }


        [ActivatorUtilitiesConstructor]
        public ViewMyJobController(IMyJobServ<Myjob> _serv)
        {
            serv = _serv;
        }


        public IActionResult ViewMyJob(int id)
        {
            ViewBag.Username = HttpContext.Session.GetString("Username");
            ViewBag.Usertype = HttpContext.Session.GetString("Usertype");

            myJobs = serv.getMyJobs();

            foreach (Myjob item in myJobs)
            {
                if (item.Id == id)
                {
                    return View(item);
                }
            }

            return View();
        }
    }
}

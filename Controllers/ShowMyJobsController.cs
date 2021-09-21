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
    public class ShowMyJobsController : Controller
    {
        public static List<Myjob> myJobs = new List<Myjob>();
        private readonly IMyJobServ<Myjob> serv;

        public ShowMyJobsController() { }


        [ActivatorUtilitiesConstructor]
        public ShowMyJobsController(IMyJobServ<Myjob> _serv)
        {
            serv = _serv;
        }

        public IActionResult ShowMyJobs()
        {
            ViewBag.Username = HttpContext.Session.GetString("Username");
            ViewBag.Usertype = HttpContext.Session.GetString("Usertype");

            int uid = (int)HttpContext.Session.GetInt32("Userid");

            myJobs = serv.getMyJobs();

            List<Myjob> particularUserJobs = new List<Myjob>();

            foreach (Myjob item in myJobs)
            {
                if (item.Userid == uid)
                {
                    particularUserJobs.Add(item);
                }
            }

            return View(particularUserJobs);
        }


    }
}

using JobPortalDI.ProjModel;
using JobPortalDI.Service;
using JobPortalDI.Views.Login;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobPortalDI.Controllers
{
    public class GetjobController : Controller
    {
        static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(GetjobController));

        private readonly IJobServ<Job> serv;

        public GetjobController() { }

        [ActivatorUtilitiesConstructor]
        public GetjobController(IJobServ<Job> _serv)
        {
            serv = _serv;
        }

        public static MyViewModel viewModel;

        public IActionResult viewJob()
        {
            ViewBag.Username = HttpContext.Session.GetString("Username");
            ViewBag.Usertype = HttpContext.Session.GetString("Usertype");

            return View();
        }

        [HttpPost]
        public IActionResult viewJob(int cid)
        {
            ViewBag.Username = HttpContext.Session.GetString("Username");
            ViewBag.Usertype = HttpContext.Session.GetString("Usertype");

            int userid = Convert.ToInt32(HttpContext.Session.GetInt32("Userid"));

            List<Job> jobsFiltered = new List<Job>();
            List<Job> particularUserJobsFiltered = new List<Job>();

            //Console.WriteLine("cid recieved: " + cid);

            cid = Convert.ToInt32(Request.Form["category"]);


            List<Job> jobs = serv.getAllJobs();

                foreach (Job item in jobs)
                {
                    if (item.Userid == userid)
                    {
                        particularUserJobsFiltered.Add(item);
                    }
                }
            

            foreach (Job item in particularUserJobsFiltered)
            {
                if (item.Cid == cid)
                {
                    jobsFiltered.Add(item);
                }
            }

            String domName;

            switch (cid)
            {
                case 1:
                    domName = "business";
                    break;
                case 2:
                    domName = "retail";
                    break;
                case 3:
                    domName = "technology";
                    break;
                case 4:
                    domName = "construction";
                    break;

                default:
                    domName = "not found";
                    break;
            }

            _log4net.Info(ViewBag.Username + " tried to see jobs in " + domName + " domain.");

            return View(jobsFiltered);
        }
    }
}

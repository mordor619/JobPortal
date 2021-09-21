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
    public class ApplyJobController : Controller
    {
        static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(ApplyJobController));

        private static readonly IMyJobRepo<Myjob> _repo = new MyJobRepo();
        private readonly IMyJobServ<Myjob> servMyJob = new MyJobServ(_repo);

        private readonly IJobServ<Job> serv;


        [ActivatorUtilitiesConstructor]
        public ApplyJobController(IJobServ<Job> _serv)
        {
            serv = _serv;
        }


        public IActionResult ApplyJob(int id)
        {
            ViewBag.Username = HttpContext.Session.GetString("Username");
            ViewBag.Usertype = HttpContext.Session.GetString("Usertype");

            Job j = serv.getJobById(id);

            Myjob j1 = (Myjob)j;



            //use this method in Myjob.cs in case of error(if you scaffold again)

            //    public static explicit operator Myjob(Job j)
            //{
            //    return new Myjob()
            //    {
            //        Userid = j.Userid,
            //        Cid = j.Cid,
            //        Company = j.Company,
            //        JobTitle = j.JobTitle,
            //        Description = j.Description,
            //        Salary = j.Salary,
            //        Location = j.Location,
            //        ContactUser = j.ContactUser,
            //        ContactEmail = j.ContactEmail
            //    };
            //}

            int uid = (int)HttpContext.Session.GetInt32("Userid");
            j1.Userid = uid;


            servMyJob.addToMyJobs(j1);

            _log4net.Info("applied for job with id " + id);

            return RedirectToAction("Index", "Login");
        }

    }
}

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
    public class CreateController : Controller
    {
        static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(CreateController));

        private readonly IJobServ<Job> serv;

        [ActivatorUtilitiesConstructor]
        public CreateController(IJobServ<Job> _serv)
        {
            serv = _serv;
        }

        public IActionResult Create()
        {
            ViewBag.Username = HttpContext.Session.GetString("Username");
            ViewBag.Usertype = HttpContext.Session.GetString("Usertype");

            int uid = (int)HttpContext.Session.GetInt32("Userid");
            MyViewModel v1 = LoginController.getItems(uid);
            ViewBag.categoryData = v1.ListB.ToList();
            ViewBag.uid = uid;

            return View();
        }

        [HttpPost]
        public IActionResult CreateJob(Job j)
        {
            ViewBag.Username = HttpContext.Session.GetString("Username");
            ViewBag.Usertype = HttpContext.Session.GetString("Usertype");

            int cid = Convert.ToInt32(Request.Form["category"]);
            j.Cid = cid;

            //using (var db = new JobportalDIContext())
            //{
            //    db.Jobs.Add(j);
            //    db.SaveChanges();
            //}

            serv.createJob(j);

            _log4net.Info("New job created by " + j.ContactUser);

            return RedirectToAction("Index", "Login");
        }
    }
}

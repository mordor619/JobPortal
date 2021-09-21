using JobPortalDI.ProjModel;
using JobPortalDI.Repository;
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
    public class LoginController : Controller
    {
        static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(LoginController));

        private static readonly IJobRepo<Job> _repo = new JobRepo();
        private static readonly ICategoryRepo<Category> _repoCat = new CategoryRepo();

        private readonly ILogintblServ<Logintbl> serv;
        private readonly IJobServ<Job> servJob = new JobServ(_repo);
        private readonly ICategoryServ<Category> servCat = new CategoryServ(_repoCat);

        public LoginController() { }

        //use for multiple constructors
        [ActivatorUtilitiesConstructor]
        public LoginController(ILogintblServ<Logintbl> _serv)
        {
            serv = _serv;
        }


        public static List<Job> jobs = new List<Job>();
        public static List<Category> categories = new List<Category>();
        public static MyViewModel viewModel;
        public static string usertype;

        public static MyViewModel getItems(int uid)
        {
            LoginController lg = new LoginController();

            List<Job> particularUserJobs = new List<Job>();

            jobs = lg.servJob.getAllJobs();


            foreach (Job item in jobs)
            {
                if (item.Userid == uid)
                {
                    particularUserJobs.Add(item);
                }
            }          


            categories = lg.servCat.getCategories();

            viewModel = new MyViewModel();



            if (usertype.Equals("Admin"))
            {
                viewModel.ListA = particularUserJobs;
            }
            else if (usertype.Equals("User"))
            {
                viewModel.ListA = jobs;
            }


            viewModel.ListB = categories;

            return viewModel;
        }

        public IActionResult viewJob(int id)
        {
            ViewBag.Username = HttpContext.Session.GetString("Username");
            ViewBag.Usertype = HttpContext.Session.GetString("Usertype");

            foreach (Job item in jobs)
            {
                if (item.Id == id)
                {
                    _log4net.Info("job posting " + item.JobTitle + " viewed by " + ViewBag.Username);
                    return View(item);
                }
            }

            return View();
        }

        public IActionResult Index()
        {
            ViewBag.Username = HttpContext.Session.GetString("Username");
            ViewBag.Usertype = HttpContext.Session.GetString("Usertype");

            int userid = Convert.ToInt32(HttpContext.Session.GetInt32("Userid"));

            if (ViewBag.Username == null)
            {
                return RedirectToAction("Login");
            }


            MyViewModel v1 = getItems(userid);

            return View(v1);

        }


        public IActionResult Login()
        {
            ViewBag.Username = HttpContext.Session.GetString("Username");
            ViewBag.Usertype = HttpContext.Session.GetString("Usertype");

            return View();
        }


        [HttpPost]
        public IActionResult Login(Logintbl obj)
        {
            ViewBag.Username = HttpContext.Session.GetString("Username");
            ViewBag.Usertype = HttpContext.Session.GetString("Usertype");

            //using (var db = new JobportalDIContext())
            //{
            //Logintbl result = (from i in db.Logintbls
            //                   where i.Username == obj.Username && i.Userpass == obj.Userpass
            //                   select i).FirstOrDefault();

            Logintbl result = serv.GetUser(obj);

                if (result != null)
                {
                    HttpContext.Session.SetString("Username", result.Fullname);
                    HttpContext.Session.SetInt32("Userid", result.Userid);
                    HttpContext.Session.SetString("Usertype", result.Usertype);

                    usertype = result.Usertype;

                    _log4net.Info("login by " + result.Username);

                    return RedirectToAction("Index", "Login");  //filename and folder
                }
                else
                {
                    ViewBag.error = "**Credentials are wrong!";
                    return View();
                }
            //}
        }


        public IActionResult Logout()
        {
            ViewBag.Username = HttpContext.Session.GetString("Username");
            ViewBag.Usertype = HttpContext.Session.GetString("Usertype");

            _log4net.Info("logout by " + ViewBag.Username);

            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }


        public IActionResult GoBack()
        {
            ViewBag.Username = HttpContext.Session.GetString("Username");
            ViewBag.Usertype = HttpContext.Session.GetString("Usertype");

            return RedirectToAction("Index", "Login");
        }

    }
}

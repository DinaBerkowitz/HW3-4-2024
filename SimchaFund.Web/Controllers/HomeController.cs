using Microsoft.AspNetCore.Mvc;
using SimchaFund.Web.Models;
using System.Diagnostics;
using SimchaFund.Data;

namespace SimchaFund.Web.Controllers
{
    public class HomeController : Controller
    {


        private string _connectionString = @"Data Source=.\sqlexpress;Initial Catalog=SimchaFunds; Integrated Security=true;";


        public IActionResult Index()
        {
            DBManager manager = new DBManager(_connectionString);
            SimchaViewModel vm = new SimchaViewModel();
           vm.simchas =   manager.GetAllSimchas();

            return View(vm);
        }

        public IActionResult Add()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Added(Contributer c)
        {
            DBManager manager = new(_connectionString);
            manager.AddContributer(c);
            return Redirect("/home/contributers");
        }

        public IActionResult Contributers()
        {
            DBManager manager = new DBManager(_connectionString);
            ContributersViewModel vm = new ContributersViewModel();
            vm.contributers = manager.GetAllContributers();

            return View(vm);
        }

        public IActionResult AddSimcha()
        {
            return View();
        }

        public IActionResult NewSimcha(Simcha s)
        {
            DBManager manager = new(_connectionString);
            manager.AddSimcha(s);
            return Redirect("/home/index");
        }
    }



    }

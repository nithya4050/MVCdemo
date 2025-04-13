using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using MVCDemo.Helper;
using MVCDemo.Models;



namespace MVCDemo.Controllers
{
    public class HomeController: Controller
    {
        List<Student> olist;
        private readonly IMathLogiccs mathLogiccs;
        private readonly IStringLocalizer<HomeController> _localizer;

        
        public HomeController(IMathLogiccs mathlogicvalue, IStringLocalizer<HomeController> localizer)
        {
            _localizer = localizer;
            mathLogiccs = mathlogicvalue;

            olist = new List<Student>
            {
                new Student { Sid = 1, Sname = "Devisri", Profilepicture = "devisri.jpg", Age = 35, Description = "I am Working in Accenture" },
                new Student { Sid = 2, Sname = "Jana", Profilepicture = "jana.jpg", Age = 35, Description = "I am Working in IBM" },
                new Student { Sid = 3, Sname = "Renuga", Profilepicture = "Renuga.jpg", Age = 35, Description = "I am Working in TCS" },
                new Student { Sid = 4, Sname = "Selvam", Profilepicture = "selva.jpg", Age = 35, Description = "I am Working in CTS" },
                new Student { Sid = 5, Sname = "Naren", Profilepicture = "Naren.jpg", Age = 35, Description = "I am Working in Wipro" },

                new Student { Sid = 6, Sname = "Pooja", Profilepicture = "Pooja.jpg", Age = 35, Description = "I am Working in Accenture" },
                new Student { Sid = 7, Sname = "Pavithra", Profilepicture = "Pavithra.jpg", Age = 35, Description = "I am Working in IBM" },
                new Student { Sid = 8, Sname = "Ayesha", Profilepicture = "Ayesha.jpg", Age = 35, Description = "I am Working in TCS" },
                new Student { Sid = 9, Sname = "Nithya", Profilepicture = "Nithya.jpg", Age = 35, Description = "I am Working in CTS" },
                new Student { Sid = 10, Sname = "Nikil", Profilepicture = "Nikil.jpg", Age = 35, Description = "I am Working in Wipro" },
                new Student { Sid = 11, Sname = "Bhavin", Profilepicture = "Bhavin.jpg", Age = 35, Description = "I am Working in CTS" },
                new Student { Sid = 12, Sname = "Abitha", Profilepicture = "Ayesha.jpg", Age = 35, Description = "I am Working in Wipro" }

            };
        }




        [HttpPost]
        public IActionResult ChangeLanguage(string culture)
        {
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
            );
            return RedirectToAction("Index");
        }


        public IActionResult Index()
        {
            ViewData["Welcome"] = _localizer["Welcome"];
            mathLogiccs.Add(1, 2);
            mathLogiccs.Sub(10, 2);

            ViewBag.EmployeeDate = new Employee { Eid = 1, Ename = "Jana" };
            return View(olist);
            //return View();
        }

        [Route("JSQUARE")]
        [Route("JS")]
        [Route("JSS")]

        [Route("msdevbuild/JSS")]

        public IActionResult Aboutus()
        {
            Dashboard dashboard = new Dashboard();
            Student stud = new Student { Sid = 1, Sname = "DeviSri", Profilepicture = "devisri", Age = 35, Description = "I am Working in Accenture" };

            Employee emp = new Employee { Eid = 1, Ename="Jana"};
            dashboard.Student = stud;
            dashboard.Employee = emp;

            return View(dashboard);
        }

        [HttpGet("Home/user/sname")]
        public IActionResult UserDetails([FromQuery]int sid,[FromRoute]string sname)
        {
            Student filterstudent = olist.Where(x => x.Sid == sid).FirstOrDefault();
            return View(filterstudent);
        }


        [HttpGet("UserDetails")]
        [HttpGet("Home/UserDetails")]
        [HttpGet("Home/User")]

        public IActionResult Login()
        {
            return View();
        }
    }
}

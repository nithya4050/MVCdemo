using MVCDemo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using MVCDemo.DA;
using Azure.Messaging;
using Microsoft.IdentityModel.Tokens;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace MVCDemo.Controllers
{
    public class UserController : Controller
    {
        private readonly AppDBContext appDBContextobj;

        public UserController(AppDBContext appDBContext)
        {
            appDBContextobj = appDBContext;
        }

        public IActionResult Reg()
        {
            return View(new Student());
        }

        [HttpPost]
        public IActionResult SaveData(Student data)
        {
            appDBContextobj.Students.Add(data);
            appDBContextobj.SaveChanges();
            return View("Reg",data);
        }

        [Route("User/DeleteData/{id}")]
        public IActionResult DeleteData(int id)
        {
            var stud = appDBContextobj.Students.ToList();
            var single = stud.Where(x => x.Sid == id).FirstOrDefault();
            if(single != null)
            {
                appDBContextobj.Students.Remove(single);
                appDBContextobj.SaveChanges();
            }
            return View("Reg", single);
        }

       




        [Route("User/UpdateData/{id}")]
        public IActionResult UpdateData(Student data)
        {
          
            var single =  appDBContextobj.Students.FirstOrDefault(x => x.Sid == data.Sid);
            
            if (single != null)
            {
                single.Sname = single.Sname;
                single.Education = single.Education;
                single.Profilepicture = single.Profilepicture;
                single.Age = single.Age;
                single.Description = single.Description;
                single.DateOfbirth = single.DateOfbirth;
                single.Email = single.Email;

                appDBContextobj.SaveChanges();
            }
            return View("Reg", single);
        }




        [Route("User/ReadData/{id}")]
        public IActionResult ReadData(int id)
        {
            var stud = appDBContextobj.Students.ToList();
            var single = stud.Where(x => x.Sid == id).FirstOrDefault();
            
            
            return View("Reg", single);
        }
    }
}

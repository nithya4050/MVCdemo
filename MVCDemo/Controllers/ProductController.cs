using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using MVCDemo.Models;
using static System.Net.Mime.MediaTypeNames;
using System.Security.Cryptography;

namespace MVCDemo.Controllers
{
    public class ProductController : Controller
    {
        Student stud;
        //List<Product> olist;


        public ProductController()
        {
            //olist = new List<Product>

            //new Product { id = 1, Name="Laptop",   Price=1000,   ImageUrl = "laptop.jpg" },
            //new Product { id = 2, Name = "Phone", Price = 500, ImageUrl = "phone.jpg" },
            //new Product { id = 3, Name = "Tablet", Price = 300, ImageUrl = "tablet.jpg" },
            //new Product { id = 4, Name = "Monitor", Price = 200, ImageUrl = "monitor.jpg" },
            //new Product { id = 5, Name = "Keyboard", Price = 50, ImageUrl = "keyboard.jpg" },
            //new Product { id = 6, Name = "Mouse", Price = 30, ImageUrl = "mouse.jpg" },
            //new Product { id = 7, Name = "Printer", Price = 150, ImageUrl = "printer.jpg" },
            //new Product { id = 8, Name = "Headphones", Price = 80, ImageUrl = "headphones.jpg" },
            //new Product { id = 9, Name = "Speakers", Price = 120, ImageUrl = "speaker.jpg" },
            //new Product { id = 10, Name = "Webcam", Price = 60, ImageUrl = "webcam.jpg" }

        }


        public IActionResult Login()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Index()
        {
            //stud = new Student { Sid = 1, Sname = "DeviSri", Profilepicture = "devisri", Age = 35, Description = "I am Working in Accenture" };
            return View(stud);
        }



        //public IActionResult SaveData(string save,string delete,string clear,Student stud)
        //{
        //    if (save is not null)
        //    {
        //        int value = 10;
        //    }
        //    else if(delete is not null)
        //    {
        //        string name = "Delete";
        //    }
        //    else if (clear is not null)
        //    {
        //        string name = "Clear";
        //    }
        //    return View();
        //}

        [HttpPost]
        public IActionResult SaveData(Student stud)
        {
            string conn = "Integrated Security=SSPI; Persist Security Info=False; Initial Catalog=mvcdemo; Data Source=NITHYA\\SQLEXPRESS; Encrypt=false";
            SqlConnection sqlconn = new SqlConnection(conn);
            sqlconn.Open();
            string query = "insert into student(sid,sname,Education,Age,Description) values(@Sid,@Sname,@Education,@Age,@Description)";
            SqlCommand cmd = new SqlCommand(query, sqlconn);
            cmd.Parameters.AddWithValue("@Sid", stud.Sid);
            cmd.Parameters.AddWithValue("@Sname", stud.Sname);
            cmd.Parameters.AddWithValue("@Education", stud.Education);
            //cmd.Parameters.AddWithValue("@Profilepic", stud.Profilepicture);
            cmd.Parameters.AddWithValue("@Age", stud.Age);
            cmd.Parameters.AddWithValue("@Description", stud.Description);
            cmd.ExecuteNonQuery();
            sqlconn.Close();

            return View("Index",stud);
        }



        [HttpPost]

        public IActionResult DeleteData(Student data)
        {
            string conn = "Integrated Security=SSPI; Persist Security Info=False; Initial Catalog=mvcdemo; Data Source=NITHYA\\SQLEXPRESS; Encrypt=false";
            SqlConnection sqlconn = new SqlConnection(conn);
            sqlconn.Open();
            string query = "Delete from student where sid=@Sid";
            SqlCommand cmd = new SqlCommand(query, sqlconn);
            cmd.Parameters.AddWithValue("@Sid", data.Sid);
            cmd.ExecuteNonQuery();
            sqlconn.Close();

            return View("Index",data);
        }

        [HttpPost]

        public IActionResult ClearData(Student data)
        {
            Student stud1 = new Student();
            return View("Index",data);
        }

      
    }
}

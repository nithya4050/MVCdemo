using System.ComponentModel.DataAnnotations;

namespace MVCDemo.Models
{
    public class Student
    {
        [Key]
        public int Sid { get; set; } 

       public string Sname { get; set; }

        public string Education { get; set; }

        public string Profilepicture { get; set; }

        public int Age { get; set; }

        public string Description { get; set; }

        public string DateOfbirth { get; set; }

        public string Email { get; set; }

    }
}

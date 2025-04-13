using System.ComponentModel.DataAnnotations;

namespace MVCDemo.Models
{
    public class Employee
    {
        [Key]
        public int Eid { get; set; }
        public string Ename { get; set; }


    }
}

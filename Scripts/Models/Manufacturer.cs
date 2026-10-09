using DemoExam.Scripts;
using DemoExam.Scripts.Models;
using System.Collections.Generic;

namespace DemoExam.Scripts.Models
{
    public class Manufacturer
    {
        public int id { get; set; }
        public string name { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
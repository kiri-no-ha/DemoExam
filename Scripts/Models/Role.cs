using System.Collections.Generic;

namespace DemoExam.Scripts.Models
{
    public class Role
    {
        public int id { get; set; }
        public string name { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
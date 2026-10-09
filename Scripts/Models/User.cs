using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Windows.Controls;

namespace DemoExam.Scripts.Models
{
    public class User
    {
        public int id { get; set; }
        public string login { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string patronymic { get; set; }
        public int role_id { get; set; }

        [ForeignKey("role_id")]
        public virtual Role Role { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DemoExam.Scripts.Models
{
    public class Order
    {
        public int id { get; set; }
        public string order_date { get; set; }
        public int user_id { get; set; }

        [ForeignKey("user_id")]
        public virtual User User { get; set; }

        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}
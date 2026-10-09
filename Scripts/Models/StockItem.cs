using DemoExam.Scripts;
using DemoExam.Scripts.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DemoExam.Scripts.Models
{
    public class StockItem
    {
        public int id { get; set; }
        public int product_id { get; set; }
        public int quantity { get; set; }

        [ForeignKey("product_id")]
        public virtual Product Product { get; set; }

        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}
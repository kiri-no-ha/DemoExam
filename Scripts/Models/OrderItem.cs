using System.ComponentModel.DataAnnotations.Schema;
using System.Windows.Controls;

namespace DemoExam.Scripts.Models
{
    public class OrderItem
    {
        public int id { get; set; }
        public int order_id { get; set; }
        public int stock_item_id { get; set; }
        public int quantity { get; set; }
        public float unit_price { get; set; }

        [ForeignKey("order_id")]
        public virtual Order Order { get; set; }

        [ForeignKey("stock_item_id")]
        public virtual StockItem StockItem { get; set; }
    }
}
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using DemoExam.Scripts.Models;

namespace DemoExam.Scripts.Models
{
    public class Product
    {
        public int id { get; set; }
        public string name { get; set; }
        public int category_id { get; set; }
        public int manufacturer_id { get; set; }
        public string description { get; set; }
        public string composition { get; set; }
        public float price { get; set; }
        public string image_file_name { get; set; }

        [ForeignKey("category_id")]
        public virtual Category Category { get; set; }

        [ForeignKey("manufacturer_id")]
        public virtual Manufacturer Manufacturer { get; set; }

        public virtual ICollection<StockItem> StockItems { get; set; }
    }
}
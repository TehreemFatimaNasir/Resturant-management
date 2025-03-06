using System.ComponentModel.DataAnnotations;

namespace WebApplication4.Models

{
    public class Order
    {
        [Key]
        public int id { get; set; }
        public string customername { get; set; }
        public string items { get; set; }
        public decimal totalprice { get; set; }
        public string status { get; set; } 
    }
}

using System.ComponentModel.DataAnnotations;

namespace WebApplication4.Models
{
    public class Food
    {
        [Key]
        public int Id { get; set; }
        public string foodname { get; set; }
        public string category { get; set; }
        public decimal price { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication4.Models
{
    public class Cart
    {
        [Key]
        public int id { get; set; }

        public string foodname { get; set; }

         public int quantity { get; set; }
    }
}


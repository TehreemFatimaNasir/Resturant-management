using System.ComponentModel.DataAnnotations;



namespace WebApplication4.Models
{
    public class Reservation
    {
        [Key]
        public int Id { get; set; }
        public string customername { get; set; }
        public DateTime reservationdate { get; set; }
        public int tablenumber { get; set; }
        public int booked { get; set; }
    }
}

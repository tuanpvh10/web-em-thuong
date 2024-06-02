using System.ComponentModel.DataAnnotations;

namespace WebEmThuong.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string? Email { get; set; }
        [Required]
        public DateOnly Date { get; set; }
        [Required]
        public TimeOnly Time { get; set; }
        [Required]
        public double PhoneNumber { get; set; }
        public int NumberPeople { get; set; }
        public string Status { get; set; } = "Waiting";
    }
}

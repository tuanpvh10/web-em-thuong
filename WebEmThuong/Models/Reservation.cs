namespace WebEmThuong.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateOnly Date { get; set; }
        public TimeOnly Time { get; set; }
        public int PhoneNumber { get; set; }
        public int NumberPeople { get; set; }
        public string Status { get; set; } = "Waiting";
    }
}

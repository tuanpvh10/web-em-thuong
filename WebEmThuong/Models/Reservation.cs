namespace WebEmThuong.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime Created { get; set; }
        public string PhoneNumber { get; set; }
        public int NumberPeople { get; set; }
    }
}

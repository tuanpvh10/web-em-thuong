namespace WebEmThuong.Models
{
    public class HomeViewModel
    {
        public List<BackGround> BackGrounds { get; set; }
        public List<AboutHomePageManagement> AboutHomePageManagements { get; set; }
        public List<Comment> Comments { get; set; }
        public List<Instagram> Instagrams { get; set; }
        public List<SpecialOffers> SpecialOffers { get; set; }
        public List<ReservationHomePage> ReservationHomePages { get; set; }
        public Reservation Reservation { get; set; }
        public List<Galleries> Galleries { get; set; }
    }
}

using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace WebEmThuong.Models
{
    public class SpecialOffers
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        [ValidateNever]
        public string ImgUrl { get; set; }
    }
}

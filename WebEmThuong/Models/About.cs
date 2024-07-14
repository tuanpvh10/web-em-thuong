using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace WebEmThuong.Models
{
    public class About
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Desciption { get; set; }
        [ValidateNever]
        public string ImgUrl1 { get; set; }
        [ValidateNever]
        public string ImgUrl2 { get; set; }
        [ValidateNever]
        public string ImgUrl3 { get; set; }
    }
}

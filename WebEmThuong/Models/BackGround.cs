using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace WebEmThuong.Models
{
    public class BackGround
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Slogan { get; set; }
        [ValidateNever]
        public string ImgUrl { get; set; }
    }
}

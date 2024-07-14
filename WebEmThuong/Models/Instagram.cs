using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace WebEmThuong.Models
{
    public class Instagram
    {
        public int Id { get; set; }
        public int No { get; set; }
        [ValidateNever]
        public string ImgUrl { get; set; }
    }
}

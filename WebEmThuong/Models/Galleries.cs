using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace WebEmThuong.Models
{
    public class Galleries
    {
        public int Id { get; set; }
        public string Title { get; set; }
        [ValidateNever]
        public string ImgUrl { get; set; }
    }
}

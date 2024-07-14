using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace WebEmThuong.Models
{
    public class AboutHomePageManagement
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Desciption { get; set; }
        [ValidateNever]
        public string ImgUrl { get; set; }
    }
}

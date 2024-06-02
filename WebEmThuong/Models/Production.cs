using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.Drawing;

namespace WebEmThuong.Models
{
    public class Production
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
        public int Rating { get; set; }
        [ValidateNever]
        public string ImgUrl { get; set; }
        public int Sort { get; set; }
        public int CatagoryId { get; set; }
    }
}

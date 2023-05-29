using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTaskPrasBLL.ValidationRules;

namespace TestTaskPrasBLL.DTOs
{
    public class CreatePostDTO
    {
        [Display(Name = "Title")]
        [Required(ErrorMessage = "{0} is a required field")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Title Max length is 50 and min is 5")]
        public string Title { get; set; }
        [Display(Name = "Subtitle")]
        [Required(ErrorMessage = "{0} is a required field")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "Text Max length is 100 and min is 5")]
        public string Subtitle { get; set; }
        [Display(Name = "Text")]
        [Required(ErrorMessage = "{0} is a required field")]
        [StringLength(500, MinimumLength = 5, ErrorMessage = "Text Max length is 500 and min is 5")]
        public string Text { get; set; }
        [Display(Name = "Image")]
        [DataType(DataType.Upload)]
        [Required(ErrorMessage = "{0} is a required field")]
        [AllowedExtensions(new string[] { ".jpg", ".png" }, ErrorMessage = "Only JPG and PNG file formats are allowed.")]
        [MaxFileSize(20 * 1024 * 1024, ErrorMessage = "Maximum file size allowed is 20MB.")]
        public IFormFile ImagePath { get; set; }
    }
}

using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTaskPrasBLL.DTOs
{
    public class PostDTO
    {
        public int Id { get; set; }
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

        public string? ImagePath { get; set; }
    }
}

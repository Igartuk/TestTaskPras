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
    public class EditPostDTO
    {
        public int Id { get; set; }
        [Display(Name = "Title")]
        [Required(ErrorMessage = "{0} is a required field")]
        [StringLength(10, MinimumLength = 5, ErrorMessage = " Max length is {0} and min is 5")]
        public string Title { get; set; }
        [Display(Name = "Subtitle")]
        [Required(ErrorMessage = "{0} is a required field")]
        [StringLength(20, MinimumLength = 5, ErrorMessage = " Max length is {0} and min is 5")]
        public string Subtitle { get; set; }
        [Display(Name = "Text")]
        [Required(ErrorMessage = "{0} is a required field")]
        [StringLength(100,MinimumLength =5, ErrorMessage = " Max length is {0} and min is 5")]
        public string Text { get; set; }        
        public string? ImagePath { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplicationBookStore3.Models
{
    public class LogInViewModel
    {
        [Required]
        public string Mail { get; set; }

        [Required(ErrorMessage = "كلمة المرور مطلوبة ")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
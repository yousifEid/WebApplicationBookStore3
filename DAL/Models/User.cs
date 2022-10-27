using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DAL.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }


        [Required(ErrorMessage = "الاسم مطلوب")]
        public string Name { get; set; }


        [Required(ErrorMessage = "الاميل مطلوب")]
        public string Mail { get; set; }


        [Required(ErrorMessage = "كلمة المرور مطلوبة ")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
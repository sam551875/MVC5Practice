using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MVC5Practice.Models
{
    public class Person
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="名字欄位為必填！")]
        public string Name { get; set; }

        [Required]
        [Range(1,10, ErrorMessage = "請輸入年紀以確保小於10歲")]
        public int age { get; set; }
    
    }
}
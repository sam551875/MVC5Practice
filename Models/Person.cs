using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace MVC5Practice.Models
{
    public class Person
    {
        [DisplayName("姓名")]
        public int Id { get; set; }

        [Required(ErrorMessageResourceName ="Person_Name_Required",ErrorMessageResourceType =typeof(ResourceFile.Resource1))]
        public string Name { get; set; }

        [Required(ErrorMessageResourceName = "Person_Age_Required", ErrorMessageResourceType = typeof(ResourceFile.Resource1))]
        [Range(1,10, ErrorMessageResourceName = "Person_Age_Range", ErrorMessageResourceType = typeof(ResourceFile.Resource1))]
        public int age { get; set; }
    
    }
}
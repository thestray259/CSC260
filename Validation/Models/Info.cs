using Validation.Validators; 
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Validation.Models
{
    public class Info
    {
        [Required(ErrorMessage = "Name cannot be empty.")]
        public string Name { get; set; }
        [Required]
        public int Age { get; set; }


        public string StreetAddress { get; set; }
        //[Required(ErrorMessage = "City cannot be empty.")]
        public string City { get; set; }
        //[Required(ErrorMessage = "State cannot be empty.")]
        public string State { get; set; }
        public int ZipCode { get; set; }
    }
}

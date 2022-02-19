using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MahimaModhawala.Models
{
    public class Products
    {
        

        public int ProductId { get; set; }
        
        [Required(ErrorMessage="please enter Name")]
        public string ProductName { get; set; }

        [Required(ErrorMessage = "please enter Rate")]

        public decimal Rate { get; set; }

        [Required(ErrorMessage = "please enter Description")]

        public string Description { get; set; }

        [Required(ErrorMessage = "please enter CategoryName")]

        public string CategoryName { get; set; }
    }
}
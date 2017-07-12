using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MaerskContainerWebApp.Models
{
    public class Customer
    {
        public int id { get; set; }

        [Display(Name = "Customer Name")]
        public string  CustomerName { get; set; }
        public int Age { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MaerskContainerWebApp.Models
{
    public class Warehouse
    {
        public int id { get; set; }
        public string Location { get; set; }
        [Display(Name="Warehouse Name")]
        public string Name { get; set; }
    }
}
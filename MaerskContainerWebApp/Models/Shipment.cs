using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MaerskContainerWebApp.Models
{
    public class Shipment
    {
        public int id { get; set; }

        [ForeignKey("Customer")]
        [Display(Name = "Customer ID")]
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }

        [ForeignKey("Cargo")]
        [Display(Name = "Cargo ID")]
        public int CargoId { get; set; }
        public virtual Cargo Cargo { get; set; }

        public string Source { get; set; }

        public string Destination { get; set; }

        [Display(Name = "Shipping Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy/MM/dd HH:mm}")]
        public DateTime ShippingDate { get; set; }

        [Display(Name = "Arrival Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy/MM/dd HH:mm}")]
        public DateTime ArrivalDate { get; set; }

        public string status { get; set; }
    }
}
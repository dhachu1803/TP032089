using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MaerskContainerWebApp.Models
{
    public class Cargo
    {
        public int Id { get; set; }

        [Display(Name = "Cargo Volume")]
        public int CargoVolume { get; set; }

        [Display(Name = "Cargo Weight")]
        public int CargoWeight { get; set; }

        [Display(Name = "Warehouse ID")]
        [ForeignKey("Warehouse")]
        public int WarehouseId { get; set; }

        public virtual Warehouse Warehouse { get; set; }

        [ForeignKey("Customer")]
        public int CustomerId { get; set; }

        public virtual Customer Customer { get; set; }
    }
}
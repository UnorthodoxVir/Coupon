using Coupon.Models;
using Catel.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Coupon.Models
{
    public class VehicleModel : ModelBase
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "ادخل نوع المركبة")]
        [Display(Name = "نوع المركبة")]
        public string Name { get; set; }

        [Display(Name = "ماركة المركبة")]
        public virtual VehicleMake VehicleMake { get; set; }

        [Required(ErrorMessage = "ادخل موديل المركبة")]
        [ForeignKey(nameof(VehicleMake))]
        [Display(Name = "موديل المركبة")]
        public Guid vmId { get; set; }
    }
}
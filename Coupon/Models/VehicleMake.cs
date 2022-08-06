using Catel.Data;
using Coupon.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Coupon.Models
{
    public class VehicleMake : ModelBase
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "ادخل اسم المصنع")]
        [Display(Name = "اسم المصنع")]
        public string Name { get; set; }
    }
}
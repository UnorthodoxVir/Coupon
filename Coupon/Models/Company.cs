using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using static Coupon.Models.Enum;

namespace Coupon.Models
{
    public class Company
    {
        [Key]
        public Guid Id { get; set; }

        [Display(Name = "اسم المنشآة")]
        public string Name { get; set; }

        [Display(Name = "الرقم الضريبي")]
        public string VatNo { get; set; }

        [Display(Name = "السجل التجاري")]
        public string CrNo { get; set; }

        [Display(Name = "المدينة")]
        public City City { get; set; }

        [Display(Name = "الشعار")]
        public string Logo { get; set; }
    }
}

using Microsoft.AspNetCore.Http;
using static Coupon.Models.Enum;

namespace Coupon.ViewModel
{
    public class CompanyViewModel
    {
        public string Name { get; set; }

        public string VatNo { get; set; }

        public string CrNo { get; set; }

        public City City { get; set; }

        public IFormFile Logo { get; set; }

    }
}

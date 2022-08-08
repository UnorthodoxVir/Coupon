using Coupon.Data;
using Coupon.Data.Repositories;
using Coupon.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Coupon.Services;
using System.Threading.Tasks;
using Coupon.ViewModel;
using System.Collections.Generic;
using System.Linq;
using System;

namespace Coupon.Controllers
{
    public class CouponsController : Controller
    {
        private readonly CodeGeneratorService _codeService;
        private readonly CompCouponsRepository _compCouponsRepository;
        private readonly CouponCardsRepository _couponCardsRepository;
        private readonly CompanyRepository _companiesRepository;
        private readonly SmsService _smsService;
        private readonly EmailService _emailService;
        public CouponsController(CompCouponsRepository compCouponsRepository, CouponCardsRepository couponCardsRepository, CompanyRepository companyRepository, SmsService smsService, EmailService emailService, CodeGeneratorService codeService)
        {
            _compCouponsRepository = compCouponsRepository;
            _couponCardsRepository = couponCardsRepository;
            _companiesRepository = companyRepository;
            _smsService = smsService;
            _emailService = emailService;
            _codeService = codeService;
        }

        // GET: CouponsController
        public ActionResult Index(int? City, int? DiscountType)
        {
            var model = new CouponsViewModel();
            model.CouponCards = _couponCardsRepository.List().ToList();

            foreach (var coupon in model.CouponCards)
            {
                coupon.CompCoupon = _compCouponsRepository.Get(coupon.CouponId);
                coupon.CompCoupon.Company = _companiesRepository.Get(coupon.CompCoupon.CompId);
            }

            model.CouponCards = model.CouponCards.Where(o => o.CompCoupon.ExpireDate >= DateTime.Now).ToList();

            if (City != null && City != 78)
            {
                model.CouponCards = model.CouponCards.Where(o => (int)o.CompCoupon.Company.City == City).ToList();
            }

            if(DiscountType != null && DiscountType != 0)
            {
                model.CouponCards = model.CouponCards.Where(o=>(int)o.CompCoupon.DiscountType == DiscountType).ToList();
            }


            model.CouponCards = model.CouponCards.OrderBy(o => o.Used).ToList();


            return View(model);
        }

        // GET: CouponsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CouponsController/Create
        public ActionResult Create()
        {
            ViewBag.Companies = new SelectList(_companiesRepository.List(), "Id", "Name");
            return View();
        }

        // POST: CouponsController/Create
        [HttpPost]
        public ActionResult Create(CompCoupon coupon)
        {

            _compCouponsRepository.Add(coupon);

            for (int i = 0; i < coupon.Count; i++)
            {
                _couponCardsRepository.Add(new CouponCard()
                {
                    Code = _codeService.RandomString(5),
                    CouponId = coupon.Id,
                    CustomerId = null,
                    Used = false,
                });
            }

            

            return View();
        }

        // GET: CouponsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CouponsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CouponsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CouponsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}

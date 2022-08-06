using Coupon.Data.Repositories;
using Coupon.Models;
using Coupon.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Coupon.Controllers
{
    public class CustomersController : Controller
    {

        private readonly CouponCardsRepository _cardsRepository;
        private readonly CustomersRepository _customersRepository;
        private readonly Services.EmailService _emailService;
        private readonly Services.SmsService _smsService;
        private readonly Services.CodeGeneratorService _codeService;
        private readonly CompCouponsRepository _compCouponsRepository;
        private readonly CompanyRepository _companyRepository;
        private readonly OTPRepository _OTPRepository;
        public CustomersController(CustomersRepository customersRepository, Services.EmailService emailService, Services.SmsService smsService, CouponCardsRepository cardsRepository, Services.CodeGeneratorService codeService, CompCouponsRepository compCouponsRepository, CompanyRepository companyRepository, OTPRepository oTPRepository)
        {
            _customersRepository = customersRepository;
            _emailService = emailService;
            _smsService = smsService;
            _cardsRepository = cardsRepository;
            _codeService = codeService;
            _compCouponsRepository = compCouponsRepository;
            _companyRepository = companyRepository;
            _OTPRepository = oTPRepository;
        }

        // GET: CustomersController
        public ActionResult Index()
        {
            return View();
        }

        // GET: CustomersController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CustomersController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CustomersController/Create
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CustomerViewModel model)
        {

            var customer = new Customer()
            {
                City = (Models.Enum.City)model.City,
                Email = model.Email,
                Model = model.Model,
                PhoneNumber = model.PhoneNumber,
                UsedCoupon = model.UsedCoupon,
                PlateNumber = model.PlateNumber,
                Name = model.Name,
                Vehicle = model.Vehicle
            };

            var coupon = _cardsRepository.Get(customer.UsedCoupon);
            _cardsRepository.Update(coupon);
            _customersRepository.Add(customer);


            var otp = new OTP()
            {
                Code = _codeService.GenerateOTP(),
                CustomerId = customer.Id,
                isUsed = false,
            };

            _OTPRepository.Add(otp);

            await _smsService.AuthenticatePhone(otp.Code, customer.PhoneNumber);


            return Json(new { success = true });
        }

        [HttpPost]
        public JsonResult SubmitOTP([FromBody] OTPViewModel OTP)
        {
            var otp = _OTPRepository.List().Where(o=>o.Code == OTP.Code).FirstOrDefault();

            if(otp != null && otp.isUsed == false)
            {
                var customer = _customersRepository.Get(otp.CustomerId);
                var coupon = _cardsRepository.Get(customer.UsedCoupon);
                var CompanyName = _companyRepository.Get(_compCouponsRepository.List().Where(o => o.Id == coupon.CouponId).FirstOrDefault().CompId).Name;

                otp.isUsed = true;

                _OTPRepository.Update(otp);

                _smsService.sendMsg(customer.Name, coupon.Code, customer.PhoneNumber, CompanyName);

                return Json(new { success = true, isValid = true });
            }
            else
            {
                return Json(new {success = true, isValid = false});
            }

        }

        // GET: CustomersController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CustomersController/Edit/5
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

        // GET: CustomersController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CustomersController/Delete/5
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

        [HttpPost]
        public async Task<JsonResult> CheckPhoneNumber([FromBody] PhoneCheckViewModel model)
        {
            var customerPhoneNumber = _customersRepository.List().Where(o => o.PhoneNumber == model.PhoneNumber).FirstOrDefault();
            if (customerPhoneNumber == null)
            {
                return Json(new { isUsed = false, success = true });
            }
            else
            {
                return Json(new { isUsed = true, success = true });
            }
        }

    }
}

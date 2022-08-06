using Coupon.Data.Repositories;
using Coupon.Models;
using Coupon.ViewModel;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;

namespace Coupon.Controllers
{
    public class CompaniesController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly CompanyRepository _companyRepository;
        public CompaniesController(CompanyRepository companyRepository, IWebHostEnvironment webHostEnvironment)
        {
            _companyRepository = companyRepository;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: CompaniesController
        public ActionResult Index()
        {
            return View(_companyRepository.List());
        }

        // GET: CompaniesController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CompaniesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CompaniesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CompanyViewModel model)
        {
            var stringFileName = UploadFile(model);

            var company = new Company
            {
                City = model.City,
                CrNo = model.CrNo,
                Name = model.Name,
                VatNo = model.VatNo,
                Logo = stringFileName
            };

            _companyRepository.Add(company);

            return RedirectToAction(nameof(Index));
        }

        private string UploadFile(CompanyViewModel model)
        {
            string fileName = null;

            if(model.Logo != null)
            {
                string dir = Path.Combine(_webHostEnvironment.WebRootPath, "images");
                fileName = Guid.NewGuid().ToString() + "-" + model.Logo.FileName;
                string path = Path.Combine(dir, fileName);
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    model.Logo.CopyTo(fileStream);
                }
            }
            return fileName;
        }

        // GET: CompaniesController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CompaniesController/Edit/5
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

        // GET: CompaniesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CompaniesController/Delete/5
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

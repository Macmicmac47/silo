using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GPS.Core.Domain;
using GPS.Service.Country;
using GPS.Service.Hospital;
using GPS.Web.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.Internal;
using Microsoft.AspNetCore.Mvc;

namespace GPS.Web.Controllers
{
    public class HospitalController : Controller
    {
        private readonly IHospitalService _hospitalService;
        private readonly ICountryService _countryService;
        private readonly IHostingEnvironment _hostingEnvironment;

        public HospitalController(IHospitalService hospitalService, ICountryService countryService, IHostingEnvironment hostingEnvironment)
        {
            this._hospitalService = hospitalService;
            this._countryService = countryService;
            this._hostingEnvironment = hostingEnvironment;
        }
        public IActionResult Index()
        {
            List<HospitalViewModel> model = new List<HospitalViewModel>();



            _hospitalService.GetHospitals().ToList().ForEach(c =>
            {
                HospitalViewModel hospital = new HospitalViewModel
                {
                    HospitalId = c.Id,
                    HospitalName = c.HospitalName,
                    HospitalAddress = c.HospitalAddress,
                    HospitalPhoneNumber = c.HospitalPhoneNumber,
                    CountryId = c.CountryId,
                    CountryfalfPath = string.Format("{0}{1}", _countryService.GetCountrybyId(c.CountryId).Select(x => x.TwoLetterIsoCode.Trim()).First().ToLower(), ".png"),
                    CountryName = _countryService.GetCountrybyId(c.CountryId).Select(x => x.Name).First()
                };
                model.Add(hospital);
            });

            return View(model);
        }
        public PartialViewResult AddEditHospital(long? id)
        {
            HospitalViewModel model = new HospitalViewModel();
            if (id.HasValue && id.Value != 0)
            {
                var hospital = _hospitalService.GetHospitalbyId(id.Value).SingleOrDefault();
                if (hospital != null)
                {
                    model.HospitalAddress = hospital.HospitalAddress;
                    model.HospitalName = hospital.HospitalName;
                    model.HospitalPhoneNumber = hospital.HospitalPhoneNumber;
                    model.Url = hospital.Url;
                    model.Host = hospital.Host;
                    model.SecureUrl = hospital.SecureUrl;
                    model.SslEnabled = hospital.SslEnabled;

                }
            }

            return PartialView("_AddEditHospital", model);
        }

        [HttpPost]
        public IActionResult AddEditHospital(long? id, HospitalViewModel model)
        {

            if (id.HasValue && id.Value != 0)
            {
                // 
                var hospital = _hospitalService.GetHospitalbyId(id.Value).SingleOrDefault();
                if (hospital != null)
                {
                    hospital.HospitalName = model.HospitalName;
                    hospital.Host = model.Host;
                    hospital.HospitalAddress = model.HospitalAddress;
                    hospital.HospitalPhoneNumber = model.HospitalPhoneNumber;
                    hospital.SecureUrl = model.SecureUrl;
                    hospital.SslEnabled = model.SslEnabled;
                    hospital.Url = model.Url;
                    _hospitalService.UpdateHospital(hospital);


                }

            }
            else
            {
                var hospital = new Hospital();
                hospital.HospitalName = model.HospitalName;
                hospital.Host = model.Host;
                hospital.HospitalAddress = model.HospitalAddress;
                hospital.HospitalPhoneNumber = model.HospitalPhoneNumber;
                hospital.SecureUrl = model.SecureUrl;
                hospital.SslEnabled = model.SslEnabled;
                hospital.Url = model.Url;
                _hospitalService.AddHospital(hospital);
            }
            return RedirectToAction("Index");
        }
    }
}
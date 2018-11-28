using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using GPS.Core.Domain;
using GPS.Service.CareTeam;
using GPS.Service.Category;
using GPS.Service.Country;
using GPS.Service.Demographic;
using GPS.Service.Department;
using GPS.Service.Gender;
using GPS.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GPS.Web.Controllers
{
    public class CareTeamMemberController : Controller
    {
        private readonly ICareTeamService _teamMemberService;
        private readonly IGenderService _iGenderService;
        private readonly IDemographicService _idemogrphicService;
        private readonly IProfessionalCategory _iprofessionalCategory;
        private readonly IDepartmentService _departmentService;
        private readonly ICountryService _countryService;

        public CareTeamMemberController(ICareTeamService teamMemberService,
                                        IGenderService iGenderService,
                                        IDemographicService idemogrphicService,
                                        IProfessionalCategory iprofessionalCategory,
                                        IDepartmentService departmentService,
                                        ICountryService countryService)
        {
            this._teamMemberService = teamMemberService;
            this._iGenderService = iGenderService;
            this._idemogrphicService = idemogrphicService;
            this._iprofessionalCategory = iprofessionalCategory;
            this._departmentService = departmentService;
            this._countryService = countryService;
        }
        public IActionResult Index(string searchText, string option)
        {
            List<TeamMemberViewModel> list = new List<TeamMemberViewModel>();
            if (!string.IsNullOrEmpty(searchText) && new List<string> { "lastname", "phone" }.Exists(v => v == option.ToLower()))
            {
                var query = _teamMemberService.GetTeamMembersInitialInformation(option, searchText);
                foreach (var caTeam in query)
                {
                    list.Add(new TeamMemberViewModel()
                    {
                        CareTeamMemberId = caTeam.CareTeamMemberId,
                        Name = string.Format("{0},{1}", caTeam.LastName, caTeam.FirstName),
                        EmailAddress = caTeam.EmailAddress,
                        Address = string.Format("{0} {1} {2}, {3}", caTeam.Address1, caTeam.City, caTeam.Province, caTeam.PostalCode),
                        PhoneNumber = caTeam.PhoneNumber,
                        profession = caTeam.Profession,
                        CellNumber = caTeam.CellNumber
                    });
                }
            }
            else
            {
                ViewBag.EmptyMessage = "Search Criteria is Null";
            }
            return View(list);
        }
        public IActionResult SearchView()
        {
            return PartialView("_SearchView");
        }
        public ActionResult NewTeamMember()
        {
            var vm = new TeamMemberViewModel();
            vm.professionList = _iprofessionalCategory.GetCategories().ToList()
                                      .Select(n => new SelectListItem()
                                      {
                                          Value = n.ProfessionalCategoryId.ToString(),
                                          Text = n.Name
                                      }).ToList();
            vm.DepartmentLists = _departmentService.GetDsepartments()
                                        .Select(n => new SelectListItem()
                                        {
                                            Value = n.DepartmentId.ToString(),
                                            Text = n.Name
                                        }).ToList();

            vm.Demographics = _idemogrphicService.GetDemographics()
                                        .Select(n => new SelectListItem()
                                        {
                                            Value = n.DemographicId.ToString(),
                                            Text = n.Name
                                        }).ToList();
            vm.CountryList = _countryService.GetCountries()
                                        .Select(n => new SelectListItem()
                                        {
                                            Value = n.CountryId.ToString(),
                                            Text = n.Name
                                        }).ToList();
            return View(vm);
        }

        public async Task<IActionResult> Register(TeamMemberViewModel model, IFormFile PhotoFilePath)
        {
            if (ModelState.IsValid)
            {
                try
                {

                    CareTeamMemberView mod = null;
                    List<TeamMemberViewModel> list = new List<TeamMemberViewModel>();

                    if (PhotoFilePath == null || PhotoFilePath.Length == 0)
                        return Content("file not selected");

                    if (PhotoFilePath.Length > 0)
                    {

                        var path = Path.Combine(
                                    Directory.GetCurrentDirectory(), "wwwroot/uploads/",
                                    PhotoFilePath.FileName);

                        using (var stream = new FileStream(path, FileMode.Create))
                        {
                            await PhotoFilePath.CopyToAsync(stream);
                        }
                        mod = new CareTeamMemberView()
                        {
                            Address1 = model.Address,
                            CellNumber = model.CellNumber,
                            City = model.City,
                            Company = model.Company,
                            DateofBirth = model.DateofBirth,
                            Demographic = model.Demographic,
                            EmailAddress = model.EmailAddress,
                            EmergencyContactName = model.EmergencyContactName,
                            EmergencyContactPhoneNumber = model.EmergencyContactPhoneNumber,
                            FirstName = model.FirstName,
                            Gender = model.Gender,
                            HireDate = model.HireDate,
                            LastName = model.LastName,
                            MiddleName = model.MiddleName,
                            PhoneNumber = model.PhoneNumber,
                            PostalCode = model.PostalCode,
                            ProfessionalCategoryId = Convert.ToUInt32(model.profession),
                            Specialization = model.Specialization,
                            Province = model.Province,
                            TerminationDate = model.TerminationDate,
                            PhotoFilePath = PhotoFilePath.FileName,
                            Address2 = "",
                            CountryId = Convert.ToUInt32(model.Country),
                            PlaceofBirth = model.PlaceofBirth

                        };
                    }
                    _teamMemberService.AddnewTeamMember(mod);
                    list.Add(model);
                    return View("Index", list);

                }
                catch (Exception)
                {

                    throw;
                }

            }
            return View("NewTeamMember", model);
        }
       
    }
}
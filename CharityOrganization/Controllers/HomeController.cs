using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Stripe;
using System.Threading.Tasks;
using Newtonsoft.Json;
using CharityOrganization.Models;


namespace CharityNeeds.Controllers
{
    public class HomeController : Controller
    {
        private CharityEntities db = new CharityEntities();
        public ActionResult About()
        {
            return View("About");
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Donations()
        {
            return View("Donations");
        }


        public ActionResult OneTimeDonations()
        {
            TempData["CurrentUrl"] = "/Home/OneTimeDonations";
            
            List<string> cities = (from item in db.Organisations
                                   select item.OrganisationCity).Distinct().ToList();
            List<string> organisationNames = (from item in db.Organisations
                                              select item.OrganisationName).Distinct().ToList();
            ViewBag.City = new SelectList(cities);
            ViewBag.OrganisationNames = new SelectList(organisationNames);
            ViewBag.ReturnUrl = TempData["CurrentUrl"];
            return View("OneTimeDonations");
        }



        [HttpPost]
        public ActionResult OneTimeDonations(FormCollection form)
        {
            if (ModelState.IsValid)
            {
               
                string CityName = form["City"].ToString();
                if (CityName != "")
                {
                    TempData["cityName"] = CityName;
                    TempData["RedirectFrom"] = "OneTimeDonations";
                    return RedirectToAction("CharityInCity");

                }
                string OrgName = form["OrganisationNames"].ToString();
                if (OrgName != "")
                {
                    TempData["orgName"] = OrgName;
                    TempData["RedirectFrom"] = "OneTimeDonations";
                    return RedirectToAction("CharityOrganisation");
                }
            }
            return View("Index");


        }

        public ActionResult CharityInCity()
        {
            string CityName = TempData["cityName"].ToString();
            ViewBag.CitySelected = CityName;
            ViewBag.RedirectFrom = TempData["RedirectFrom"];
            return View(db.Organisations.ToList());
        }

        public ActionResult CharityOrganisation()
        {
            string OrgName = TempData["orgName"].ToString();
            ViewBag.OrgName = OrgName;
            ViewBag.RedirectFrom = TempData["RedirectFrom"];
            return View(db.Organisations.ToList());
        }

        public ActionResult OrgSearch(string orgSearchWord)
        {
            if (ModelState.IsValid)
            {
                ViewBag.SearchOrgWord = orgSearchWord;
                //TempData["orgName"] = db.Organisations.Where(u => u.OrganisationCity.Contains(orgSearchWord)).ToString();
                //return RedirectToAction("CharityOrganisation", "Home");
                return View(db.Organisations.Where(u => u.OrganisationCity.Contains(orgSearchWord)).ToList());
            }
            else
                return View("Index");
        }

        public ActionResult MonthlyDonations()
        {
            List<string> cities = (from item in db.Organisations
                                   select item.OrganisationCity).Distinct().ToList();
            List<string> organisationNames = (from item in db.Organisations
                                              select item.OrganisationName).Distinct().ToList();
            //foreach (var item in db.Organisations)
            //{
            //    if (!cityNames.Contains(item.OrganisationCity.ToString()))
            //        cityNames.Add(item.OrganisationCity);
            //}
            ViewBag.City = new SelectList(cities);
            ViewBag.OrganisationNames = new SelectList(organisationNames);
            return View("MonthlyDonations");
        }

        [HttpPost]
        public ActionResult MonthlyDonations(FormCollection form)
        {
            if (ModelState.IsValid)
            {

                string CityName = form["City"].ToString();
                if (CityName != "")
                {
                    TempData["cityName"] = CityName;
                    TempData["RedirectFrom"] = "MonthlyDonations";
                    return RedirectToAction("CharityInCity");

                }
                string OrgName = form["OrganisationNames"].ToString();
                if (OrgName != "")
                {
                    TempData["orgName"] = OrgName;
                    TempData["RedirectFrom"] = "MonthlyDonations";
                    return RedirectToAction("CharityOrganisation");
                }
            }
            return View("Index");
        }
        
       public ActionResult Donate(string Organization)
        {
            if (ModelState.IsValid)
            {
                string userName = User.Identity.Name;
                ViewBag.user = userName;
                ViewBag.OrgName = Organization;
                return View();
            }
            return View("Index");
        }

    public ActionResult ContactUs()
        {
            return View("About");
        }

       
        public ActionResult BuildAnIdea()
        {
            return View("BuildAnIdea");
        }

        public ActionResult CreateAccount()
        {
            return View("CreateAccount");
        }

        

    }
}
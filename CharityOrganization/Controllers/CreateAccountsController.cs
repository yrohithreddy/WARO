using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CharityOrganization.Models;
using System.Reflection;

namespace CharityNeeds.Controllers
{
    public class CreateAccountsController : Controller
    {
        private CharityEntities db = new CharityEntities();




        // GET: CreateAccounts/Create
        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CustomerID,FirstName,LastName,Gender,EmailAddress,VerifyEmailAddress,PhoneNumber,CurrentAddress,CreatePassword,VerifyPassword")] CreateAccount createAccount)
        {
            if (ModelState.IsValid)
            {
                db.CreateAccounts.Add(createAccount);
                db.SaveChanges();
                LogInCustomer logInCustomer = new LogInCustomer();
                logInCustomer.EmailAddress = createAccount.EmailAddress;
                logInCustomer.CustomerPassword = createAccount.CreatePassword;
                logInCustomer.CustomerID = db.CreateAccounts.Where(u => u.EmailAddress == createAccount.EmailAddress).Select(u => u.CustomerID).FirstOrDefault();
                db.LogInCustomers.Add(logInCustomer);
                db.SaveChanges();
                return RedirectToAction("Index", "Home", new { Name = createAccount.LastName, check = 1 });
            }

            return View(createAccount);

        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

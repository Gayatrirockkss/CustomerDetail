using Customer_Details.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Customer_Details.Service;
using System.Threading.Tasks;

namespace Customer_Details.Controllers
{
    [HandleError]
    public class CustomerDataController : Controller
    {
        private Intern_DBEntities dbcontext = new Intern_DBEntities();
        public bool status;

        #region============== Login() Method========================
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Login([Bind(Include = "Login_Userid,Login_UserName,Login_Password")] LoginDetail login)
        {
            Session["UserName"] = login.Login_UserName;
            Session["Password"] = login.Login_Password;
            status = await CustomerDataAccess.LoginAsync(login);
            if (status == true)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View("DataNotFound");
            }
        }
        #endregion
        #region============ GET() Method================================
        [CustomAuthenticationFilter]
        public async Task<ActionResult> Index()
        {
            return View(await CustomerDataAccess.GetDataAsync());
        }
        #endregion

        #region=====================Create() Method================
        //Custom Authorization filter which will give rights only to Admin
        [CustomAuthorizationFilter(Roles ="Admin")]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create([Bind(Include = "Person_ID,Person_Name,Person_Age,Person_Occupation,Person_Mail")] PersonalDataDetail personalDataDetail)
        {
            if (ModelState.IsValid)
            {
                status = await CustomerDataAccess.AddDataAsync(personalDataDetail);
            }
            if (status == true)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View("DataNotFound");
            }
        }
        #endregion

        #region================Update() Method==========================================

        public async Task<ActionResult> Update(int? id)
        {
            if (id == null)
            {
                return View("DataNotFound");
            }

            return View(await CustomerDataAccess.UpdateDataAsync(id));
        }
        [HttpPost]
        public async Task<ActionResult> Update([Bind(Include = "Person_ID,Person_Name,Person_Age,Person_Occupation,Person_Mail")] PersonalDataDetail personalDataDetail)
        {
            if (ModelState.IsValid)
            {
                status = await CustomerDataAccess.UpdateDataAsync(personalDataDetail);
            }
            if(status == true)
            {
                return View();
            }
            else
            {
                return View("DataNotFound");
            }
        }
        #endregion

        #region======================Delete() Method========================================

        
        
        public async Task<ActionResult> Delete(int id)
        {
            if (ModelState.IsValid)
            {
                status = await CustomerDataAccess.DeleteDataAsync(id);
            }
            if (status == true)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View("DataNotFound");
            }
            
        }
        #endregion

        #region============================Detail() method=========================================

        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return View("DataNotFound");
            }
            
            return View(await CustomerDataAccess.GetDetailDataAsync(id));
        }
        #endregion

        public async Task<ActionResult> CascadingDropDown()
        {
            return  Redirect("CascadingDropDownList/MyIndex");
        }
    }
}
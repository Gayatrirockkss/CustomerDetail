using Customer_Details.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Customer_Details.Controllers
{
    [HandleError]
    public class CascadingDropDownListController : Controller
    {
        private Intern_DBEntities dbcontext = new Intern_DBEntities();
        // GET: CascadingDropDownList
        public ActionResult Index()
        {
            Location loc = new Location();
            List<SelectListItem> countryNames = new List<SelectListItem>();
            List<SelectListItem> stateNames = new List<SelectListItem>();


            List<CountryDetail> country = dbcontext.CountryDetails.ToList();
            List<StateDetail> state = dbcontext.StateDetails.ToList();

            country.ForEach(x =>
            {
                countryNames.Add(new SelectListItem { Text = x.CountryName, Value = x.CountryID.ToString() });
            });
            state.ForEach(x =>
            {
                stateNames.Add(new SelectListItem { Text = x.StateName, Value = x.CountryID.ToString() });
            });

            loc.CountryName = countryNames;
            loc.StateName = stateNames;


            return View(loc);

        }
        [HttpPost]
        public ActionResult GetState(string countryId)
        {
            int conId;
            List<SelectListItem> stateNames = new List<SelectListItem>();
            if (!string.IsNullOrEmpty(countryId))
            {
                conId = Convert.ToInt32(countryId);
                List<StateDetail> states = dbcontext.StateDetails.Where(x => x.CountryID == conId).ToList();
                states.ForEach(x =>
                {
                    stateNames.Add(new SelectListItem { Text = x.StateName, Value = x.StateID.ToString() });
                });
            }
            return Json(stateNames, JsonRequestBehavior.AllowGet);
        }
    }
}
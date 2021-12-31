using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Customer_Details.Models
{
    public class Location
    {
        public List<SelectListItem> CountryName { get; set; }
        public List<SelectListItem> StateName { get; set; }
    }
}
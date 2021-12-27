//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Customer_Details.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class PersonalDataDetail
    {
        public int Person_ID { get; set; }

        [Required(ErrorMessage = "The Person Name field is required")]
        public string Person_Name { get; set; }


        [Required(ErrorMessage = "The Person Age field is required")]
        public int Person_Age { get; set; }


        [Required(ErrorMessage = "The Person Occupation field is required")]
        public string Person_Occupation { get; set; }


        [Required(ErrorMessage = "The Person Mail field is required")]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                            @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                            @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$",
                            ErrorMessage = "Email is not valid")]
        public string Person_Mail { get; set; }
    }
}
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
    
    public partial class StateDetail
    {
        public int StateID { get; set; }
        public Nullable<int> CountryID { get; set; }
        public string StateName { get; set; }
    
        public virtual CountryDetail CountryDetail { get; set; }
    }
}
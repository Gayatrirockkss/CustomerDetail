﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Intern_DBEntities : DbContext
    {
        public Intern_DBEntities()
            : base("name=Intern_DBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<PersonalDataDetail> PersonalDataDetails { get; set; }
        public DbSet<LoginDetail> LoginDetails { get; set; }
        public DbSet<CountryDetail> CountryDetails { get; set; }
        public DbSet<StateDetail> StateDetails { get; set; }
    }
}

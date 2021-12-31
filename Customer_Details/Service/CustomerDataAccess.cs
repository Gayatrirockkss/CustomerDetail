using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Threading.Tasks;
using Customer_Details.Models;
using System.Web.UI.WebControls;

namespace Customer_Details.Service
{
    public class CustomerDataAccess
    {
        private static bool status;
        static PersonalDataDetail personalData = new PersonalDataDetail();
        public async static Task<List<PersonalDataDetail>> GetDataAsync()
        {
            List<PersonalDataDetail> personalData = new List<PersonalDataDetail>();
            try
            {
                using (var dbcontext = new Intern_DBEntities())
                {
                    personalData = dbcontext.PersonalDataDetails.ToList();
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return personalData;
        }

        public async static Task<bool> AddDataAsync(PersonalDataDetail personalDataDetail)
        {
            if (personalDataDetail != null)
            {
                try
                {
                    using (var dbcontext = new Intern_DBEntities())
                    {
                        dbcontext.PersonalDataDetails.Add(personalDataDetail);
                        await dbcontext.SaveChangesAsync();
                        status = true;

                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            else
            {
                status = false;
            }
            return status;
        }

        public async static Task<bool> UpdateDataAsync(PersonalDataDetail personalDataDetail)
        {
            if (personalDataDetail != null)
            {
                try
                {
                    using (var dbcontext = new Intern_DBEntities())
                    {
                        dbcontext.PersonalDataDetails.Add(personalDataDetail);
                        dbcontext.Entry(personalDataDetail).State = EntityState.Modified;
                        await dbcontext.SaveChangesAsync();
                        status = true;

                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            else
            {
                status = false;
            }
            return status;
        }

        public async static Task<PersonalDataDetail> UpdateDataAsync(int? id)
        {
            try
            {
                using (var dbcontext = new Intern_DBEntities())
                {
                    personalData = dbcontext.PersonalDataDetails.Where(s => s.Person_ID == id).FirstOrDefault();

                    return  personalData;

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return personalData;
        }

        public async static Task<bool> DeleteDataAsync(int id)
        {
            try
            {
                using (var dbcontext = new Intern_DBEntities())
                {
                    var personalDataDetail = dbcontext.PersonalDataDetails.Where(s => s.Person_ID == id).FirstOrDefault();
                    if (personalDataDetail != null)
                    {
                        dbcontext.PersonalDataDetails.Remove(personalDataDetail);
                        await dbcontext.SaveChangesAsync();
                        status = true;
                    }
                    else
                    {
                        status = false;
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return status;
        }

        public async static Task<PersonalDataDetail> GetDetailDataAsync(int? id)
        {
            try
            {
                using (var dbcontext = new Intern_DBEntities())
                {
                    personalData = dbcontext.PersonalDataDetails.Where(s => s.Person_ID == id).FirstOrDefault();

                    return personalData;

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return personalData;
        }
        public async static Task<bool> LoginAsync(LoginDetail login)
        {
            try
            {
                    using (var dbcontext = new Intern_DBEntities())
                    {
                        var loginAuthentication = dbcontext.LoginDetails
                            .Where(l => l.Login_UserName == login.Login_UserName && l.Login_Password == login.Login_Password)
                            .FirstOrDefault();

                        if (loginAuthentication != null)
                        {
                            status = true;
                        }
                        else
                            status = false;
                    }
                
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return status;
        }
    }
}
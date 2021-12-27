using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Threading.Tasks;
using Customer_Details.Models;

namespace Customer_Details.Service
{
    public class CustomerDataAccess
    {
        public async static Task<List<PersonalDataDetail>> GetDataAsync()
        {
            using(var dbcontext = new Intern_DBEntities())
            {
                var query = from item in dbcontext.PersonalDataDetails
                            select item;
                return await query.ToListAsync();
            }
        }

        public async static Task<bool> AddDataAsync(PersonalDataDetail personalDataDetail)
        {
            if (personalDataDetail != null)
            {
                using (var dbcontext = new Intern_DBEntities())
                {
                    dbcontext.PersonalDataDetails.Add(personalDataDetail);
                    await dbcontext.SaveChangesAsync();
                    return true;

                }
            }
            else
            {
                return false;
            }
        }

        public async static Task<bool> UpdateDataAsync(PersonalDataDetail personalDataDetail)
        {
            if (personalDataDetail != null)
            {
                using (var dbcontext = new Intern_DBEntities())
                {
                    dbcontext.PersonalDataDetails.Add(personalDataDetail);
                    dbcontext.Entry(personalDataDetail).State = EntityState.Modified;
                    await dbcontext.SaveChangesAsync();
                    return true;

                }
            }
            else
            {
                return false;
            }
        }

        public async static Task<PersonalDataDetail> UpdateDataAsync(int? id)
        {
            using (var dbcontext = new Intern_DBEntities())
            {
                var personalDataDetail = dbcontext.PersonalDataDetails.Where(s => s.Person_ID == id).FirstOrDefaultAsync();

                return await personalDataDetail;

            }
        }

        public async static Task<bool> DeleteDataAsync(int id)
        {
            using (var dbcontext = new Intern_DBEntities())
            {
                var personalDataDetail = dbcontext.PersonalDataDetails.Where(s => s.Person_ID == id).FirstOrDefault();
                if (personalDataDetail != null)
                {
                    dbcontext.PersonalDataDetails.Remove(personalDataDetail);
                    await dbcontext.SaveChangesAsync();
                    return true;
                }
                else
                {
                    return false;
                }

            }
        }

        public async static Task<PersonalDataDetail> GetDetailDataAsync(int? id)
        {
            using (var dbcontext = new Intern_DBEntities())
            {
                var personalDataDetail = dbcontext.PersonalDataDetails.Where(s => s.Person_ID == id).FirstOrDefaultAsync();
                
                return await personalDataDetail;

            }
        }
        
    }
}
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tk.Soc.LAS.Models;

namespace Tk.Soc.LAS.UnitTest
{
    public static class DbHelper
    {
        public static void InsertDataIntoMysql(int count)
        {
            using (var dbContext = new TkSocLASDbContext())
            {
                int index = 0;
                while (index < count)
                {
                    string name = "星城科技    " + index.ToString();
                    var company = new Company
                    {
                        Name = name,
                        Address = "湖南长沙雨花区"
                    };
                    dbContext.Companys.Add(company);
                    index++;
                }
                dbContext.SaveChanges();
            }
        }

        public static int GetCompanyConut()
        {
            var dbContext = new TkSocLASDbContext();
            return dbContext.Companys.Count();
        }

        public static void DelectCompanyDataAsync(int id, int limitCount)
        {
            int minId = id >= limitCount ? id - limitCount : 0;

            var dbContext = new TkSocLASDbContext();

            var companyList = dbContext.Companys
                .Where(c => c.Id < id & c.Id >= minId)
                .Select(o => new Company
                {
                    Id = o.Id,
                    Name = o.Name,
                    Address = o.Address
                })
            .ToList();

            dbContext.Companys.RemoveRange(companyList);
            dbContext.SaveChanges();
        }
    }
}

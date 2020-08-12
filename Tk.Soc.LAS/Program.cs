using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Tk.Soc.LAS.LasHelper;
using Tk.Soc.LAS.Models;
using Tk.Soc.LAS.UnitTest;

namespace Tk.Soc.LAS
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //LocalTestHelper.OnStart();
            //DbHelper.GetCompanyDataTest();
            DbHelper.GetCompanyDataByLimit(3000, 4000);
           // Console.WriteLine(DbHelper.DelectAllCompanyData());
            //Console.WriteLine(DbHelper.InsertDataIntoMysql(30000));
        }
    }
}

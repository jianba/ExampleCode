using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Tk.Soc.LAS.Models;
using Tk.Soc.LAS.UnitTest;

namespace Tk.Soc.LAS
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            //DbHelper.InsertDataIntoMysql(1000);

            string path = @"D:\WorkMaterial\日常\2020-8-11-性能测试\Conf\test.txt";

            Console.WriteLine("-----数据库现有数据 {0} 条------\n", DbHelper.GetCompanyConut());

            try
            {
                StreamReader sr = new StreamReader(path, Encoding.Default);
                String line = sr.ReadLine();
                int limit = 10;

                if (!string.IsNullOrEmpty(line))
                {
                    int count = 0;
                    string strId = line.Replace("--- ", "");
                    int id = int.Parse(strId.Trim());

                    while (true)
                    {
                        DbHelper.DelectCompanyDataAsync(id, limit);
                        Console.WriteLine("成功第 {0} 次删除数据。", ++count);

                        int companyCount = DbHelper.GetCompanyConut();
                        Console.WriteLine("数据库剩余 {0} 条数据", companyCount);

                        id = id >= limit ? id - limit : 0;

                        Thread.Sleep(2000);
                    }
                }
                else
                {
                    Console.WriteLine("读取数据失败");
                }
            }
            catch(Exception e)
            {
                Console.WriteLine("读取数据失败，异常如下：\n{0}",e.ToString());
            }

            //Console.WriteLine(DbHelper.GetCompanyConut());
            Console.ReadKey();
        }
    }
}

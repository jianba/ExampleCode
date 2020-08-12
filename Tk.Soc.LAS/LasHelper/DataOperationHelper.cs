using System;
using System.IO;
using System.Text;
using System.Threading;
using Microsoft.Extensions.Configuration;

namespace Tk.Soc.LAS.LasHelper
{
    public static class DataOperationHelper
    {
        public static void OnStart()
        {
            var configurationBuilder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");
            IConfiguration config = configurationBuilder.Build();

            string path = @"D:\WorkMaterial\日常\2020-8-11-性能测试\Conf\test.txt";
            Int64 limit = config[TkSocLASSettings]
            int sleepTime = int.Parse("1000"); 
            
            //Int64 limit = Int64.Parse("100");
            //int sleepTime = int.Parse("1000");

            try
            {
                StreamReader streamReader = new StreamReader(path, Encoding.Default);
                String line = streamReader.ReadLine();

                if (!string.IsNullOrEmpty(line))
                {
                    string strId = line.Replace("--- ", "");
                    Int64 id = Int64.Parse(strId.Trim());
                    Console.WriteLine("ID = {0} ", id);

                    while (true)
                    {
                        Int64 count = DbHelper.RemoveLimitRangeData(id, limit);
                        Console.WriteLine("成功删除 {0} 条数据。", count);

                        id = id >= limit ? id - limit : 0;
                        Thread.Sleep(sleepTime);
                    }
                }
                else
                {
                    Console.WriteLine("读取数据失败");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("读取数据失败，异常如下：\n{0}", e.ToString());
            }

            Console.ReadKey();
        }
    }
}

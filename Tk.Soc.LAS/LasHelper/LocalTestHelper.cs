﻿using System;
using System.IO;
using System.Text;
using System.Threading;
using Tk.Soc.LAS.UnitTest;

namespace Tk.Soc.LAS.LasHelper
{
    public static class LocalTestHelper
    {
        public static void OnStart()
        {

            //DbHelper.InsertDataIntoMysql(1000);

            string path = @"D:\WorkMaterial\日常\2020-8-11-性能测试\Conf\test.txt";

           // Console.WriteLine("-----数据库现有数据 {0} 条------\n", DbHelper.GetCompanyConut());

            try
            {
                StreamReader sr = new StreamReader(path, Encoding.Default);
                String line = sr.ReadLine();
                Int64 limit = 100;

                if (!string.IsNullOrEmpty(line))
                {                   
                    string strId = line.Replace("--- ", "");
                    Int64 id = Int64.Parse(strId.Trim());

                    Console.WriteLine("ID = {0} ", id);

                    while (true)
                    {
                       // long count = DbHelper.DelectCompanyData(id, limit);
                        Console.WriteLine("成功删除 {0} 条数据。", count);

                        id = id >= limit ? id - limit : 0;

                        Thread.Sleep(1000);
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

            //Console.WriteLine(DbHelper.GetCompanyConut());
            Console.ReadKey();
        }
    }
}

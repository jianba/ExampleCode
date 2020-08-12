using System;
using System.Collections.Generic;
using System.Linq;
using Tk.Soc.LAS.Models;

namespace Tk.Soc.LAS
{
    public static class DbHelper
    {
        public static int RemoveLimitRangeData(Int64 id, Int64 limitCount)
        {
            Int64 minId = id >= limitCount ? id - limitCount : 0;
            return RemoveRangeData(minId, id);
        }
        
        public static void GetCompanyDataTest()
        {          
            var dbContext = new TkSocLASDbContext();
            Int64 min = 3000, max = 4000;

            List<t_svr_proc_all_history_bak> logList = dbContext.t_svr_proc_all_history_bak
                .Where(c => c.id < max && c.id >= min)
                .Select(o => new t_svr_proc_all_history_bak
                {
                    id = o.id,
                    pid = o.pid,
                    proc_name = o.proc_name,
                    proc_cpu = o.proc_cpu,
                    proc_mem = o.proc_mem,
                    proc_cmd = o.proc_cmd,
                    proc_param = o.proc_param,
                    proc_user = o.proc_user,
                    proc_start_time = o.proc_start_time,
                    proc_status =o.proc_status,
                    cpu_wait_proc_num = o.cpu_wait_proc_num,
                    sample_time = o.sample_time,
                    asset_id = o.asset_id,
                    files_open_num = o.files_open_num
                })
                .ToList();

            Console.WriteLine(logList.Count);

            foreach (var item in logList)
            {
                Console.WriteLine("ID = {0}  --   pid = {1}", item.id.ToString(), item.pid.ToString());
            }

            Int64 tt = 3000;
            var xx = dbContext.t_svr_proc_all_history_bak.Where(o => o.id == tt).FirstOrDefault();
            Console.WriteLine(xx.proc_name.ToString());

            var x = dbContext.t_svr_proc_all_history_bak.Where(o => o.id == tt).ToList();
        }
        
        public static int RemoveRangeData(Int64 minId, Int64 maxId)
        {          
            var dbContext = new TkSocLASDbContext();

            List<t_svr_proc_all_history_bak> logList = dbContext.t_svr_proc_all_history_bak
                .Where(c => c.id >= minId && c.id <= maxId)
                .Select(o => new t_svr_proc_all_history_bak
                {
                    id = o.id,
                    pid = o.pid,
                    proc_name = o.proc_name,
                    proc_cpu = o.proc_cpu,
                    proc_mem = o.proc_mem,
                    proc_cmd = o.proc_cmd,
                    proc_param = o.proc_param,
                    proc_user = o.proc_user,
                    proc_start_time = o.proc_start_time,
                    proc_status =o.proc_status,
                    cpu_wait_proc_num = o.cpu_wait_proc_num,
                    sample_time = o.sample_time,
                    asset_id = o.asset_id,
                    files_open_num = o.files_open_num
                })
                .ToList();
            dbContext.t_svr_proc_all_history_bak.RemoveRange(logList);

            return dbContext.SaveChanges();
        }
    }
}

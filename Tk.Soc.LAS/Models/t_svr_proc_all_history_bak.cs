using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace Tk.Soc.LAS.Models
{
    public class t_svr_proc_all_history_bak
    {
        public Int64 id { get; set; }
        public int? pid  { get; set; }
        public string? proc_name { get; set; }
        public float? proc_cpu { get; set; }
        public Int64? proc_mem { get; set; }
        public string? proc_cmd { get; set; }
        public string? proc_param { get; set; }
        public string? proc_user { get; set; }
        public DateTime? proc_start_time { get; set; }
        public byte? proc_status { get; set; }
        public byte? cpu_wait_proc_num { get; set; }
        public DateTime sample_time { get; set; }
        public string? asset_id { get; set; }
        public int? files_open_num { get; set; }
    }
}

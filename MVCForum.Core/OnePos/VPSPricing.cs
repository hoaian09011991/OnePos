using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCForum.Domain.OnePos
{
    public class VPSPricing
    {
        public int Id { get; set; }
        public string CPU { get; set; }
        public string RAM { get; set; }
        public string DiskSpace { get; set; }
        public string BandWidth { get; set; }
        public string Setup { get; set; }
        public string IP { get; set; }
        public string Price { get; set; }
        public int SortOrder { get; set; }
    }
}

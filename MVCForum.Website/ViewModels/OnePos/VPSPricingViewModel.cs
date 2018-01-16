using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCForum.Website.ViewModels
{
    public class VPSPricingViewModel
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
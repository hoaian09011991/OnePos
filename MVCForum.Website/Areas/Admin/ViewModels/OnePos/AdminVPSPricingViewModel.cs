using MVCForum.Domain.OnePos;
using System.Collections.Generic;
using System.ComponentModel;

namespace MVCForum.Website.Areas.Admin.ViewModels
{
        public class ListVPSPricingViewModel
        {
            public IEnumerable<VPSPricing> VPSPricings { get; set; }
        }
    public class EditVPSPricingViewModel
    {
        public int Id { get; set; }
        [DisplayName("CPU")]
        public string CPU { get; set; }
        [DisplayName("RAM")]
        public string RAM { get; set; }
        [DisplayName("DiskSpace")]
        public string DiskSpace { get; set; }
        [DisplayName("BandWidth")]
        public string BandWidth { get; set; }
        [DisplayName("Setup")]
        public string Setup { get; set; }
        [DisplayName("IP")]
        public string IP { get; set; }
        [DisplayName("Price")]
        public string Price { get; set; }
        [DisplayName("SortOrder")]
        public int SortOrder { get; set; }
    }

}
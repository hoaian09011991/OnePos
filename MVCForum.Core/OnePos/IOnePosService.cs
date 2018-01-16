using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCForum.Domain.OnePos
{
    public partial interface IOnePosService
    {
        #region vps pricing
        List<VPSPricing> VPSPricing_GetAll();
        VPSPricing VPSPricing_Get(int id);
        VPSPricing VPSPricing_Add(VPSPricing item);
        #endregion
    }
}

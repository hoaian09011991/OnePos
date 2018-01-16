using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVCForum.Domain.OnePos;
using MVCForum.Services.Data.Context;
using MVCForum.Domain.Interfaces;
using MVCForum.Domain.Constants;
using MVCForum.Domain.Interfaces.Services;

namespace MVCForum.Services.OnePos
{
    public partial class OnePosService: IOnePosService
    {
        private readonly MVCForumContext _context;
        private readonly ICacheService _cacheService;
        public OnePosService(IMVCForumContext context, ICacheService cacheService)
        {
            _context = context as MVCForumContext;
            _cacheService = cacheService;
        }

        #region vps pricing
        public List<VPSPricing> VPSPricing_GetAll() {
            var cacheKey = string.Concat(CacheKeys.VPSPricing.StartsWith, "GetAll");
            return _cacheService.CachePerRequest(cacheKey, () =>
            {
                //var orderedCategories = new List<VPSPricing>();
                var allCats = _context.VPSPricing
                        .AsNoTracking()
                        .OrderBy(x => x.SortOrder)
                        .ToList();
                return allCats;
            });
        }
        public VPSPricing VPSPricing_Get(int id)
        {
            var cacheKey = string.Concat(CacheKeys.VPSPricing.StartsWith, "Get");
            return _cacheService.CachePerRequest(cacheKey, () =>
            {
                //var orderedCategories = new List<VPSPricing>();
                var allCats = _context.VPSPricing.Find(id);
                return allCats;
            });
        }
        public VPSPricing VPSPricing_Add(VPSPricing item)
        {
            // Add the category
            return _context.VPSPricing.Add(item);
        }
        #endregion
    }
}

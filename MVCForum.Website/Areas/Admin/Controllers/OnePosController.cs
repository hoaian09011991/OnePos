using MVCForum.Domain.Constants;
using MVCForum.Domain.Interfaces.Services;
using MVCForum.Domain.Interfaces.UnitOfWork;
using MVCForum.Domain.OnePos;
using MVCForum.Website.Areas.Admin.ViewModels;
using MVCForum.Website.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCForum.Website.Areas.Admin.Controllers
{
    [Authorize(Roles = AppConstants.AdminRoleName)]
    public class OnePosController : BaseAdminController
    {
        private readonly IOnePosService _onePosService;
        public OnePosController(
            ILoggingService loggingService,
            IUnitOfWorkManager unitOfWorkManager,
            IMembershipService membershipService,
            ILocalizationService localizationService,
            ISettingsService settingsService,
            IOnePosService onePosService)
            : base(loggingService, unitOfWorkManager, membershipService, localizationService, settingsService)
        {
            _onePosService = onePosService;
        }

        // GET: Admin/OnePos/HomeSlider
        public ActionResult HomeSlider()
        {
            return View("HomeSlider");
        }
        #region vps pricing

        
        // GET: Admin/OnePos/VPSPricing
        public ActionResult VPSPricing()
        {
            var listVps = new List<VPSPricing>();
            using (UnitOfWorkManager.NewUnitOfWork())
            {
                listVps = _onePosService.VPSPricing_GetAll();
            }
            return View("VPSPricing", new ListVPSPricingViewModel() { VPSPricings = listVps });
        }
        public ActionResult EditVPSPricing(int id)
        {
            using (UnitOfWorkManager.NewUnitOfWork())
            {
                var category = _onePosService.VPSPricing_Get(id);
                var categoryViewModel = new EditVPSPricingViewModel()
                {
                    BandWidth = category.BandWidth,
                    CPU = category.CPU,
                    DiskSpace = category.DiskSpace,
                    IP = category.IP,
                    Price = category.Price,
                    RAM = category.RAM,
                    Setup = category.Setup,
                    SortOrder = category.SortOrder,
                    Id = category.Id
                };

                return View(categoryViewModel);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateCategory(VPSPricingViewModel vpsViewModel)
        {
            if (ModelState.IsValid)
            {
                using (var unitOfWork = UnitOfWorkManager.NewUnitOfWork())
                {
                    try
                    {
                        var vps = new VPSPricing
                        {
                            BandWidth = vpsViewModel.BandWidth,
                            CPU = vpsViewModel.CPU,
                            DiskSpace = vpsViewModel.DiskSpace,
                            IP = vpsViewModel.IP,
                            Price = vpsViewModel.Price,
                            RAM = vpsViewModel.RAM,
                            Setup = vpsViewModel.Setup,
                            SortOrder = vpsViewModel.SortOrder
                        };

                        _onePosService.VPSPricing_Add(vps);

                        unitOfWork.Commit();
                    }
                    catch (Exception)
                    {
                        unitOfWork.Rollback();
                    }
                }
            }
            else
            {
                ModelState.AddModelError("", "There was an error creating the VPSPricing");
            }

            return RedirectToAction("Index");
        }
        #endregion
        // GET: Admin/OnePos/SMSPricing
        public ActionResult SMSPricing()
        {
            return View("SMSPricing");
        }
        // GET: Admin/OnePos/OnePosPricing
        public ActionResult OnePosPricing()
        {
            return View("OnePosPricing");
        }
        // GET: Admin/OnePos/WhyChooseUs
        public ActionResult WhyChooseUs()
        {
            return View("WhyChooseUs");
        }
        // GET: Admin/OnePos/Blogs
        public ActionResult Blogs()
        {
            return View("Blogs");
        }
        // GET: Admin/OnePos/Customers
        public ActionResult Customers()
        {
            return View("Customers");
        }
    }
}
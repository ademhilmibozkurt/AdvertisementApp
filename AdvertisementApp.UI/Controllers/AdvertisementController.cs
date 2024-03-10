using AdvertisementApp.Business.Interfaces;
using AdvertisementApp.Common.Enums;
using AdvertisementApp.Dtos.AppUserDtos;
using AdvertisementApp.Dtos.MilitaryStatusDtos;
using AdvertisementApp.UI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;

namespace AdvertisementApp.UI.Controllers
{
    public class AdvertisementController : Controller
    {
        private readonly IAppUserService _appUserService;

        public AdvertisementController(IAppUserService appUserService)
        {
            _appUserService = appUserService;
        }

        public IActionResult Index()
        {
            return View();
        }
        
        // send appeal to an advertisement
        [Authorize(Roles = "Member")]
        public async Task<IActionResult> SendAppeal(int advertisementId)
        {
            // take userId from role. that userId sends appeal to advertisement that has this advertisementId(from HumanResource view)
            var userId = int.Parse((User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)).Value);
            var userResponse = await _appUserService.GetByIdAsync<AppUserListDto>(userId);

            ViewBag.GenderId = userResponse.Data.GenderId;

            var items = Enum.GetValues(typeof(MilitaryStatusType));
            var list = new List<MilitaryStatusListDto>();

            foreach (int item in items)
            {
                list.Add(new MilitaryStatusListDto
                {
                    Id = item,
                    Definition = Enum.GetName(typeof(MilitaryStatusType), item)
                });
            }

            ViewBag.MilitaryStatus = new SelectList(list, "Id", "Definition");

            return View(new AdvertisementAppUserCreateModel
            {
                AppUserId = userId,
                AdvertisementId = advertisementId
            });
        }

        // send appeal to an advertisement
        [Authorize(Roles = "Member")]
        [HttpPost]
        public IActionResult SendAppealAsync(AdvertisementAppUserCreateModel model)
        {
            return View();
        }
    }
}

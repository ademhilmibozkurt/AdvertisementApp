using AdvertisementApp.Business.Interfaces;
using AdvertisementApp.UI.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace AdvertisementApp.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProvidedServiceService _providedService;
        private readonly IAdvertisementService _advertisementService;

        public HomeController(IProvidedServiceService providedService, IAdvertisementService advertisementService)
        {
            _providedService = providedService;
            _advertisementService = advertisementService;
        }

        public async Task<IActionResult> Index()
        {
            var response = await _providedService.GetAllAsync();
            return this.ResponseView(response);
        }
        
        public async Task<IActionResult> HumanResources()
        {
            var response = await _advertisementService.GetActivesAsync();
            return this.ResponseView(response);
        }
    }
}

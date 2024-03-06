using AdvertisementApp.Business.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AdvertisementApp.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProvidedServiceService _providedService;

        public HomeController(IProvidedServiceService providedService)
        {
            _providedService = providedService;
        }

        public async Task<IActionResult> Index()
        {
            var response = await _providedService.GetAllAsync();
            return View();
        }
    }
}

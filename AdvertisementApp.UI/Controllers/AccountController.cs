using AdvertisementApp.Business.Interfaces;
using AdvertisementApp.Common.Enums;
using AdvertisementApp.Common.ResponseObjects;
using AdvertisementApp.Dtos.AppUserDtos;
using AdvertisementApp.UI.Extensions;
using AdvertisementApp.UI.Models;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;

namespace AdvertisementApp.UI.Controllers
{
    public class AccountController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IAppUserService _appUserService;
        private readonly IGenderService _genderService;
        private readonly IValidator<AppUserCreateModel> _appUserCreateModelValidator;

        public AccountController(IMapper mapper, IAppUserService appUserService,
                                 IGenderService genderService, IValidator<AppUserCreateModel> appUserCreateModelValidator)
        {
            _mapper = mapper;
            _appUserService = appUserService;
            _genderService = genderService;
            _appUserCreateModelValidator = appUserCreateModelValidator;
        }

        public async Task<IActionResult> SignUp()
        {
            var response = await _genderService.GetAllAsync();
            var model = new AppUserCreateModel()
            {
                Genders = new SelectList(response.Data, "Id", "Definition")
            };

            return View(model);
        }
        
        [HttpPost]
        public async Task<IActionResult> SignUp(AppUserCreateModel model)
        {
            var result = _appUserCreateModelValidator.Validate(model);

            if (result.IsValid)
            {
                var dto = _mapper.Map<AppUserCreateDto>(model);
                var createResponse = await _appUserService.CreateWithRoleAsync(dto, (int)RoleType.Member);
                return this.ResponseRedirectToAction(createResponse, "SignIn");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
            }

            var response = await _genderService.GetAllAsync();
            model.Genders = new SelectList(response.Data, "Id", "Definition", model.GenderId); 

            return View(model);
        }
        
        public IActionResult SignIn()
        {
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> SignIn(AppUserLoginDto dto)
        {
            var result = await _appUserService.CheckUserAsync(dto);
            if (result.ResponseType == ResponseType.Success)
            {
                var roleResult = await _appUserService.GetRolesByUserIdAsync(result.Data.Id);
                var claims = new List<Claim>();

                if (roleResult.ResponseType == ResponseType.Success)
                {
                    foreach (var role in roleResult.Data)
                    {
                        claims.Add(new Claim(ClaimTypes.Role, role.Definition));
                    }
                }

                // add Id to claim is role exist or not
                claims.Add(new Claim(ClaimTypes.NameIdentifier, result.Data.Id.ToString()));

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var authProperties = new AuthenticationProperties{ IsPersistent = dto.RememberMe };

                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity),
                    authProperties);

                return RedirectToAction("Index", "Home");
            }
            ModelState.AddModelError("Kullanıcı adı veya şifre hatalı!", result.Message);

            return View(dto);
        }

        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }
    }
}

// lake 4000, normal 3500
// 3+1 yatak odası dolabı 30,000-32,000 arası
// 2,55 * 2,19 = 5,58

// 5,58 * 4000 = 22,340
// 5,58 * 3500 = 19,545
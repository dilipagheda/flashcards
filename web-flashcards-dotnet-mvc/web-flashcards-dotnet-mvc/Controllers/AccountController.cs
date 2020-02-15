using System;
using System.Collections.Generic;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using web_flashcards_dotnet_mvc.Services;
using web_flashcards_dotnet_mvc.Services.Models;
using web_flashcards_dotnet_mvc.ViewModels;

namespace web_flashcards_dotnet_mvc.Controllers
{
    public class AccountController : Controller
    {
        private readonly FlashcardClient _flashcardClient;

        public AccountController(FlashcardClient flashcardClient)
        {
            _flashcardClient = flashcardClient;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async System.Threading.Tasks.Task<IActionResult> Login(LoginViewModel loginViewModel)
        {

            if (!ModelState.IsValid)
            {
                return View(loginViewModel);
            }

            var applicationUser = await _flashcardClient.Login(loginViewModel.Email, loginViewModel.Password);

            if(applicationUser == null)
            {
                ModelState.AddModelError("loginError", "Login failed. User either not exist or invalid password.");
                return View(loginViewModel);
            }

            var claims = new List<Claim>
                            {
                                new Claim("AccessToken",applicationUser.Token)
                            };

            var claimsIdentity = new ClaimsIdentity(
                claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var authProperties = new AuthenticationProperties
            {
                //AllowRefresh = <bool>,
                // Refreshing the authentication session should be allowed.

                //ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(10),
                // The time at which the authentication ticket expires. A 
                // value set here overrides the ExpireTimeSpan option of 
                // CookieAuthenticationOptions set with AddCookie.

                //IsPersistent = true,
                // Whether the authentication session is persisted across 
                // multiple requests. When used with cookies, controls
                // whether the cookie's lifetime is absolute (matching the
                // lifetime of the authentication ticket) or session-based.

                //IssuedUtc = <DateTimeOffset>,
                // The time at which the authentication ticket was issued.

                //RedirectUri = <string>
                // The full path or absolute URI to be used as an http 
                // redirect response value.
            };

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                authProperties);

            return RedirectToAction("Index", "Home");
        }
    }
}

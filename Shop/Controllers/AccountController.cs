using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shop.Context;
using Shop.Data;
using Shop.Encrypt;
using Shop.Models;

namespace Shop.Controllers
{
        public class AccountController : Controller
        {
            private shopContext _context;
            
            public AccountController(shopContext context)
            {
                _context = context;
            }

            //[Authorize(Roles = "admin, user")]
            [Authorize]
            public async Task<IActionResult> Index()
            {
                return View();
            }

            public async Task<IActionResult> Register()
            {
                return View();
            }

            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Register(RegisterModel model)
            {
                if (ModelState.IsValid)
                {
                    User user = await _context.User.FirstOrDefaultAsync(u => u.Login == model.login);
                    if (user == null)
                    {

                        user = new User { Login = model.login, Password = await SHA.GenerateSHA256String(model.password+model.login),addres = model.addres};
                        Role userRole = await _context.Roles.FirstOrDefaultAsync(r => r.Name == "User");
                        if (userRole != null)
                            user.Role = userRole;

                        _context.User.Add(user);
                        await _context.SaveChangesAsync();

                        await Authenticate(user);

                        return RedirectToAction("Index", "Home");
                    }
                    else
                        ModelState.AddModelError("", "Некорректные логин и(или) пароль");
                }
                return View(model);
            }
            [HttpGet]
            public IActionResult Login()
            {
                return View();
            }
            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Login(LoginModel model)
            {
                if (ModelState.IsValid)
                {
                    var password = await SHA.GenerateSHA256String(model.password + model.email);
                    User user = await _context.User
                        .Include(u => u.Role)
                        .FirstOrDefaultAsync(u => u.Login == model.email && u.Password == password );
                    if (user != null)
                    {
                        await Authenticate(user);

                        return RedirectToAction("Index", "Home");
                    }
                    ModelState.AddModelError("", "Некорректные логин и(или) пароль");
                }
                return View(model);
            }


            private async Task Authenticate(User user)
            {
                // создаем один claim
                var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Login),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role?.Name)
            };
                // создаем объект ClaimsIdentity
                ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType,
                    ClaimsIdentity.DefaultRoleClaimType);
                // установка аутентификационных куки
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
            }

            public async Task<IActionResult> Logout()
            {
                await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                return RedirectToAction("Login", "Account");
            }
        }
    }
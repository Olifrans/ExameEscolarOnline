using ExameEscolar.BLL.Services;
using ExameEscolar.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ExameEscolarOnline.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService accountService;

        public AccountController(IAccountService accountService)
        {
            this.accountService = accountService;
        }

        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Login()
        {
            LoginViewModel sesObj = HttpContext.Session.Get<LoginViewModel>("loginvm") ;
            if (sesObj == null)
                return View();
            else
            {
                return RedirectUser(sesObj);
            }
        }

                
        public IActionResult Logout()
        {
            HttpContext.Session.Set<LoginViewModel>("loginvm", null);
            return RedirectToAction("Login");
        }



        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Login(LoginViewModel loginVewModel)
        {
            if (ModelState.IsValid)
            {
                LoginViewModel loginVM = accountService.Login(loginVewModel);
                if (loginVM != null)
                {
                    HttpContext.Session.Set<LoginViewModel>("loginvm", loginVM);
                    return RedirectUser(loginVM);
                }
            }
            return View(loginVewModel);           
        }


        public IActionResult RedirectUser(LoginViewModel loginViewModel)
        {
            if (loginViewModel.Funcao == (int)enumFuncoes.Admin)
            {
                return RedirectToAction("Index", "Usuario");
            }
            else if (loginViewModel.Funcao == (int)enumFuncoes.Professor)
            {
                return RedirectToAction("Index", "Exame");
            }
            return RedirectToAction("Index", "Estudante");
        }

    }
}

using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExameEscolar.BLL.Services;
using ExameEscolar.ViewModels;



namespace ExameEscolarOnline.Web.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IAccountService accountService;

        public UsuarioController(IAccountService accountService)
        {
            this.accountService = accountService;
        }



        public IActionResult Index(int pageNumber = 1, int pageSize = 10)
        {
            return View(accountService.GetAllProfessor(pageNumber, pageSize));
        }



        public IActionResult Create()
        {
            return View();
        }



        [HttpPost]
        public IActionResult Create(UsuarioViewModel usuarioViewModel)
        {
            if (ModelState.IsValid)
            {
                accountService.AddProfessor(usuarioViewModel);
                return RedirectToAction("Index");
            }
            return View(usuarioViewModel);
        }

    }
}

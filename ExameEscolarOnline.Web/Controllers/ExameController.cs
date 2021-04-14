using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExameEscolar.BLL.Services;
using ExameEscolar.ViewModels;
using Microsoft.AspNetCore.Http;
using System.Configuration;
using System.IO;


namespace ExameEscolarOnline.Web.Controllers
{
    public class ExameController : Controller
    {     
        private readonly IExameService _exameService;
        private readonly IGroupsService groupsService;

        public ExameController(IExameService exameService, IGroupsService groupsService)
        {
            _exameService = exameService;
            this.groupsService = groupsService;
        }

        public IActionResult Index(int pageNumber = 1, int pageSize = 10)
        {
            return View(_exameService.GetAllExame(pageNumber, pageSize));
        }


        public IActionResult Create()
        {
            var model = new ExameViewModel();
            model.GroupsList = groupsService.GetAllGroups();
            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> Create(ExameViewModel exameViewModel)
        {
            if (ModelState.IsValid)
            {
                await _exameService.AddExameAsync(exameViewModel);
                return RedirectToAction(nameof(Index));
            }
            return View(exameViewModel);
        }
    }
}

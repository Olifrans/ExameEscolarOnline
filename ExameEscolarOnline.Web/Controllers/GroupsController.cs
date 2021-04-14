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
    public class GroupsController : Controller
    {
        private readonly IGroupsService _groupsService;
        private readonly IEstudanteService _estudanteService;

        public GroupsController(IGroupsService groupsService, IEstudanteService estudanteService)
        {
            _groupsService = groupsService;
            _estudanteService = estudanteService;
        }

        public IActionResult Index(int pageNumber = 1, int pageSize = 10)
        {
            return View(_groupsService.GetAllGroups(pageNumber, pageSize));
        }


        public IActionResult Create()
        {
            return View();
        }


     
        public async Task<IActionResult> Create(GroupsViewModel groupsViewModel)
        {
            if (ModelState.IsValid)
            {
                groupsViewModel.UsuarioId = 1;
                await _groupsService.AddGroupsAsync(groupsViewModel);
                return RedirectToAction(nameof(Index));
            }
            return View(groupsViewModel);
        }

        public IActionResult Detalhes(string groupId)
        {
            var model = _groupsService.GetById(Convert.ToInt32(groupId));
            model.estudanteChecks = _estudanteService.GetAllEstudante().Select(
                a => new EstudanteCheckBoxListViewModel()
                {
                    Id = a.Id,
                    Nome = a.Nome,
                    Selected = a.GroupsId == Convert.ToInt32(groupId)
                }).ToList();
            return View(model);
        }


        [HttpPost]
        public IActionResult Detalhes(GroupsViewModel groupsViewModel)
        {
            bool resultado = _estudanteService.SetGroupIdToEstudante(groupsViewModel);
            if (resultado)
                return RedirectToAction("Detalhes", new { groupId = groupsViewModel.Id});
            return View(groupsViewModel);
        }

    }
}

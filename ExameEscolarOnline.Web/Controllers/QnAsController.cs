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
    public class QnAsController : Controller
    {
        private readonly IExameService _exameService;
        private readonly QnAsService _qnAsService;

        public QnAsController(IExameService exameService, QnAsService qnAsService)
        {
            this._exameService = exameService;
            this._qnAsService = qnAsService;
        }

        public IActionResult Index(int pageNumber = 1, int pageSize = 10)
        {
            return View(_qnAsService.GetAllExame(pageNumber, pageSize));
        }

        public IActionResult Create()
        {
            var model = new QnAsViewModel();
            model.ExameList = _exameService.GetAllExame();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(QnAsViewModel qnviewModel)
        {
            if (ModelState.IsValid)
            {
                await _qnAsService.AddExameAsync (qnviewModel);
                return RedirectToAction(nameof(Index));
            }
            return View(qnviewModel);
        }
    }
}

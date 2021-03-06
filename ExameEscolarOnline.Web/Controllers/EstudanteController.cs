using ExameEscolar.BLL.Services;
using ExameEscolar.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ExameEscolarOnline.Web.Controllers
{
    public class EstudanteController : Controller
    {
        private readonly IEstudanteService _estudanteService;
        private readonly IExameService _exameService;
        private readonly IQnAsService _qnAsService;

        public EstudanteController(IEstudanteService estudanteService, IExameService exameService, IQnAsService qnAsService)
        {
            this._estudanteService = estudanteService;
            this._exameService = exameService;
            this._qnAsService = qnAsService;
        }

        public IActionResult Index(int pageNumber = 1, int pageSize = 10)
        {
            return View(_estudanteService.GetAll(pageNumber, pageSize));
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult>Create(EstudanteViewModel usuarioViewModel)
        {
            if (ModelState.IsValid)
            {
                await _estudanteService.AddAsync(usuarioViewModel);
                return RedirectToAction(nameof(Index));
            }
            return View(_estudanteService);
        }

        public IActionResult AtendeExame()
        {
            var model = new AtendeExameViewModel();
            
            LoginViewModel sessionObj = HttpContext.
              Session.Get<LoginViewModel>("loginvm");
            if (sessionObj != null)
            {
                model.EstudanteId = Convert.ToInt32(sessionObj.Id);
                model.QnAs = new List<QnAsViewModel>();
                var exameDeHoje = _exameService.GetAllExame().
                    Where(a => a.DataInicio.Date == DateTime.Today.Date).FirstOrDefault();
                if (exameDeHoje != null)
                {
                    model.Menssagem = "Nenhum exame para hoje";
                }
                else
                {
                    if (!_qnAsService.IsExameAttendet(exameDeHoje.Id, model.EstudanteId))
                    {
                        model.QnAs = _qnAsService.GetAllQnAByExame(exameDeHoje.Id).ToList();
                        model.ExameNome = exameDeHoje.Titulo;
                        model.Menssagem = "";
                    }
                    else { model.Menssagem = "Você já fez esse exame"; }
                }
                return View(model);
            }
            return RedirectToAction("Login", "Account");
        }

        [HttpPost]
        public IActionResult AtendeExame(AtendeExameViewModel atendeExameViewModel)
        {
            bool resultado = _estudanteService.SetExameResultado(atendeExameViewModel);
            return RedirectToAction("AtendeExame");
        }

        public IActionResult Resultado(string estudanteId)
        {
            var model = _estudanteService.GetExameResultado(Convert.ToInt32(estudanteId));
            return View(model);
        }

        public IActionResult ViewResultado()
        {
            LoginViewModel sessionObj = HttpContext.Session.Get<LoginViewModel>("loginvm");
            if (sessionObj != null)
            {
                var model = _estudanteService.GetExameResultado(Convert.ToInt32(sessionObj.Id));
                return View(model);
            }
            return RedirectToAction("Login", "Account");
        }

        public IActionResult Perfil()
        {
            LoginViewModel sessionObj = HttpContext.Session.Get<LoginViewModel>("loginvm");
            if (sessionObj != null)
            {
                var model = _estudanteService.GetEstudanteDetalhes(Convert.ToInt32(sessionObj.Id));
                if (model.ImagemNomeArquivo != null)
                {
                    model.ImagemNomeArquivo = ConfigurationManager.GetFilePath() + model.ImagemNomeArquivo;
                }
                model.CVNomeArquivo = ConfigurationManager.GetFilePath() + model.CVNomeArquivo;
                return View(model);
            }
            return RedirectToAction("Login", "Account");
        }

        public IActionResult Perfil([FromForm]EstudanteViewModel estudanteViewModel)
        {
            if (estudanteViewModel.ImagemArquivo != null)
                estudanteViewModel.ImagemNomeArquivo = SaveEstudanteArquivo(estudanteViewModel.ImagemArquivo);

            if (estudanteViewModel.CVArquivo != null)
                estudanteViewModel.CVNomeArquivo = SaveEstudanteArquivo(estudanteViewModel.CVArquivo);

            _estudanteService.UpdateAsync(estudanteViewModel);
            return RedirectToAction("Perfil");

        }

        private string SaveEstudanteArquivo(IFormFile imagemArquivo)
        {
            if (imagemArquivo == null)
            {
                return string.Empty;
            }
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/file");
            return SaveArquivo(path, imagemArquivo);
        }

        private string SaveArquivo(string path, IFormFile imagemArquivo)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            var nomearquivo = Guid.NewGuid().ToString() + "." + imagemArquivo.FileName.Split('.')
                [imagemArquivo.FileName.Split('.').Length - 1];

            path = Path.Combine(path, nomearquivo);
            using(Stream stream = new FileStream(path, FileMode.Create))
            {
                imagemArquivo.CopyTo(stream);
            }
            return nomearquivo;
        }
    }
}

using Crud.Web.Models;
using Crud.Web.Repositorio;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Crud.Web.Controllers
{
    public class AdvogadoController : Controller
    {
        private readonly IAdvogadoRepositorio _advogadoRepositorio;

        public AdvogadoController(IAdvogadoRepositorio advogadoRepositorio)
        {
            _advogadoRepositorio = advogadoRepositorio;
        }

        public IActionResult Index()
        {
            List<AdvogadoModel> advogados = _advogadoRepositorio.BuscarTodos();

            return View(advogados);
        }

        public IActionResult Criar()
        {
            return View();
        }

        public IActionResult Editar(int id)
        {
            AdvogadoModel advogado = _advogadoRepositorio.ListarPorId(id);
            return View(advogado); 
        }

        public IActionResult ApagarConfirmacao(int id )
        {
            AdvogadoModel advogado = _advogadoRepositorio.ListarPorId(id);
            return View(advogado);
        }

        public IActionResult Apagar(int id)
        {
            try
            {
               bool apagado =  _advogadoRepositorio.Apagar(id);

                if (apagado)
                {
                    TempData["MensagemSucesso"] = "Cadastro apagado com sucesso!";  
                }
                else
                {
                    TempData["MensagemErro"] = "Ops, não conseguimos apagar seu cadastro!";
                }

                return RedirectToAction("Index");
            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos apagar seu cadastro!, detalhe, mais detalhes do erro: {erro.Message} ";
                return RedirectToAction("Index");
            }
          
        }

        [HttpPost]
        public IActionResult Criar(AdvogadoModel advogado)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _advogadoRepositorio.Adicionar(advogado);
                    TempData["MensagemSucesso"] = "Cadastro realizado com sucesso";
                    return RedirectToAction("Index");
                }

                return View(advogado);
            }
            catch (System.Exception erro)
            {

                TempData["MensagemErro"] = $"Ops, não conseguimos cadastrar seu contato, tente novamente, detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
            
        }

        [HttpPost]
        public IActionResult Editar(AdvogadoModel advogado)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _advogadoRepositorio.Atualizar(advogado);
                    TempData["MensagemSucesso"] = "Alteração realizada com sucesso";
                    return RedirectToAction("Index");
                }

                return View("Editar", advogado);
            }

            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos alterar seu cadastro, tente novamente, detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
           

        }
    }
}

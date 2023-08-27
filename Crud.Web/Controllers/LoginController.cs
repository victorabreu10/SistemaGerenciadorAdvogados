using Crud.Web.Helper;
using Crud.Web.Models;
using Crud.Web.Repositorio;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Crud.Web.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        //private readonly ISessao _sessao;

        public LoginController(IUsuarioRepositorio usuarioRepositorio /*ISessao sessao*/)
        {
            _usuarioRepositorio = usuarioRepositorio;
            //_sessao = sessao;   
        }
        public IActionResult Index()
        {
            //if (_sessao.BuscarSessaoUsuario() != null) return RedirectToAction("Index", "Home");
            return View();
        }

        public IActionResult Sair()
        {
            //_sessao.RemoverSessaoDoUsuario();
            return RedirectToAction("Index", "Login");
        }

        [HttpPost]
        public IActionResult Entrar(LoginModel loginModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    UsuarioModel usuario = _usuarioRepositorio.BuscarPorLogin(loginModel.Login);

                    if (usuario != null)
                    {
                        if (usuario.SenhaValida(loginModel.Senha))
                        {
                            //_sessao.CriarSessaoDoUsuario(usuario);
                            return RedirectToAction("Index", "Home");
                        }

                        TempData["MensagemErro"] = $"Senha do usuario é invalida, tente novamente";
                    }

                TempData["MensagemErro"] = $"Usuario e/ou senha invalida(s). Por favor, tente novamente";
            }

            return View("Index");
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos realizar seu login, tente novamente, detalhe do erro : {erro.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}

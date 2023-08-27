using Crud.Web.Data;
using Crud.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Crud.Web.Repositorio
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly BancoContext _bancoContext;
        public UsuarioRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }

        public UsuarioModel BuscarPorLogin(string login)
        {
            return _bancoContext.Usuarios.FirstOrDefault(x => x.Login.ToUpper() == login.ToUpper());
        }

        public UsuarioModel BuscarPorID(int id)
        {
            return _bancoContext.Usuarios.FirstOrDefault(x => x.Id == id);
        }

        public List<UsuarioModel> BuscarTodos()
        {
            return _bancoContext.Usuarios.ToList();
        }

        public UsuarioModel Adicionar(UsuarioModel usuario)
        {
            //GRAVAR NO BANCO DE DADOS
            usuario.DataCadastro = DateTime.Now;
            usuario.SetSenhaHash();
           _bancoContext.Usuarios.Add(usuario);
           _bancoContext.SaveChanges();
            return usuario;
        }

        public UsuarioModel Atualizar(UsuarioModel usuario)
        {
            UsuarioModel model = BuscarPorID(usuario.Id);

            if (model == null) throw new System.Exception("Houve um erro na atualização do advogado!");

            model.Nome = usuario.Nome;
            model.Email = usuario.Email;
            model.Login = usuario.Login;
            model.Perfil = usuario.Perfil;
            model.DataAtualizacao = DateTime.Now;

            _bancoContext.Usuarios.Update(model);
            _bancoContext.SaveChanges();

            return model;

        }

        public bool Apagar(int id)
        {
            UsuarioModel usuarioDB = BuscarPorID(id);

            if (usuarioDB == null) throw new System.Exception("Houve um erro ao deletar o advogado"); 

            _bancoContext.Usuarios.Remove(usuarioDB);
            _bancoContext.SaveChanges();

            return true;
        }
    }
}

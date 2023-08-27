﻿using Crud.Web.Enums;
using Crud.Web.Helper;
using System;
using System.ComponentModel.DataAnnotations;

namespace Crud.Web.Models
{
    public class UsuarioModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Digite o nome do usuario")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Digite o login do usuario")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Digite o e-mail do usuario")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Informe o perfil do usuário")]
        public PerfilEnum? Perfil { get; set; }

        [Required(ErrorMessage = "Digite a senha do usuario")]
        public string Senha { get; set; }

        public DateTime DataCadastro { get; set; }

        public DateTime DataAtualizacao { get; set; }

        public bool SenhaValida(string senha)
        {
            return Senha == senha;
        }

        public void SetSenhaHash()
        {
            Senha = Senha.GerarHash();
        }
    }
}

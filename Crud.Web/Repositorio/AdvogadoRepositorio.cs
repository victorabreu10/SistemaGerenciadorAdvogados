using Crud.Web.Data;
using Crud.Web.Models;
using System.Collections.Generic;
using System.Linq;

namespace Crud.Web.Repositorio
{
    public class AdvogadoRepositorio : IAdvogadoRepositorio
    {
        private readonly BancoContext _bancoContext;
        public AdvogadoRepositorio(BancoContext bancoContext )
        {
            _bancoContext = bancoContext;
        }

        public AdvogadoModel ListarPorId(int id)
        {
            return _bancoContext.Advogados.FirstOrDefault(a => a.Id == id);
        }

        public List<AdvogadoModel> BuscarTodos()
        {
            return _bancoContext.Advogados.ToList();
        }

        public AdvogadoModel Adicionar(AdvogadoModel advogado)
        {
           //GRAVAR NO BANCO DE DADOS
           _bancoContext.Advogados.Add(advogado);
           _bancoContext.SaveChanges();
            return advogado;
        }

        public AdvogadoModel Atualizar(AdvogadoModel advogado)
        {
            AdvogadoModel model = ListarPorId(advogado.Id);

            if (model == null) throw new System.Exception("Houve um erro na atualização do advogado!");

            model.Nome = advogado.Nome;
            model.Endereco = advogado.Endereco;
            model.Senioridade = advogado.Senioridade;

            _bancoContext.Advogados.Update(model);
            _bancoContext.SaveChanges();

            return model;

        }

        public bool Apagar(int id)
        {
            AdvogadoModel model = ListarPorId(id);

            if (model == null) throw new System.Exception("Houve um erro ao deletar o advogado"); 

            _bancoContext.Advogados.Remove(model);
            _bancoContext.SaveChanges();

            return true;
        }
    }
}

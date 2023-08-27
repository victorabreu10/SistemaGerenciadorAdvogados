using Crud.Web.Models;
using System.Collections.Generic;

namespace Crud.Web.Repositorio
{
    public interface IAdvogadoRepositorio
    {
        AdvogadoModel ListarPorId(int id);
        List<AdvogadoModel> BuscarTodos();
        AdvogadoModel Adicionar(AdvogadoModel advogado);
        AdvogadoModel Atualizar(AdvogadoModel advogado);
        bool Apagar(int id);
    }
}

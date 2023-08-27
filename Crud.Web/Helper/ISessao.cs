using Crud.Web.Models;

namespace Crud.Web.Helper
{
    public interface ISessao
    {
        void CriarSessaoDoUsuario(UsuarioModel usuario);

        void RemoverSessaoDoUsuario();
            
        UsuarioModel BuscarSessaoUsuario();
    }
}

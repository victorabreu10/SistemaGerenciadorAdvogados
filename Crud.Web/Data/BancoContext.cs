using Crud.Web.Models;
using Microsoft.EntityFrameworkCore;

namespace Crud.Web.Data
{
    public class BancoContext : DbContext
    {
        public BancoContext(DbContextOptions<BancoContext> options) : base(options)
        {
        }

        public DbSet<AdvogadoModel> Advogados { get; set; }
        public DbSet<UsuarioModel> Usuarios { get; set; }
    }
}

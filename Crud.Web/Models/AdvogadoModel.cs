using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Crud.Web.Models
{
    public class AdvogadoModel 
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "É obrigatorio digitar o nome do advogado")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "É obrigatorio digitar o endereço do advogado")]
        public string Endereco { get; set; }

        [Required(ErrorMessage = "É obrigatorio digitar a senioridade do advogado")]
        public string Senioridade { get; set; }

    }
}

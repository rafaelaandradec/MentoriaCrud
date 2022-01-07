using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MentoriaCrud.Models
{
    public class UsuarioModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Digite o nome do usuário")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Digite o email do usuário")]
        [EmailAddress(ErrorMessage = "Atenção, email informado não é válido!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Digite o telefone do usuário")]
        [Phone(ErrorMessage = "O número de telefone informado não é válido!")]
        public string Telefone { get; set; }
    }
}

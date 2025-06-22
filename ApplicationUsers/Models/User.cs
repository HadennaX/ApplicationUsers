using System.ComponentModel.DataAnnotations;

namespace ApplicationUsers.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Cpf { get; set; }

        public DateTime DataNascimento { get; set; }

        public char Sexo { get; set; }
    }
}

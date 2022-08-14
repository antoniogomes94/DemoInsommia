using System;

namespace DemoAPI5.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public DateTime DataCriacao { get; set; } = DateTime.Now;
        public bool? Admin { get; set; }
    }
}

using DemoAPI5.Models;
using System;

namespace DemoAPI5.ViewModels
{
    public class UsuarioViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public DateTime DataCriacao { get; set; }
        public bool? Admin { get; set; }

        public UsuarioViewModel()
        {

        }

        public UsuarioViewModel(Usuario usuario)
        {
            Id = usuario.Id;
            Nome = usuario.Nome;
            Email = usuario.Email;
            DataCriacao = usuario.DataCriacao;
            Admin = usuario.Admin;
        }
    }
}

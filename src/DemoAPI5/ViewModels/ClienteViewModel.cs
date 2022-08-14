using DemoAPI5.Models;
using System;

namespace DemoAPI5.ViewModels
{
    public class ClienteViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        private string cpf;

        public string CPF
        {
            get { return FormatCPF(cpf); }
            set { cpf = value; }
        }

        public string Email { get;  set; }

        public DateTime DataCriacao { get; set; }

        public ClienteViewModel(){}

        public ClienteViewModel(Cliente cliente)
        {
            Id = cliente.Id;
            Nome = cliente.Nome;
            CPF = cliente.CPF;
            Email = cliente.Email;
        }

        private string FormatCPF(string cpf)
        {
            return Convert.ToUInt64(cpf).ToString(@"000\.000\.000\-00");
        }
    }
}

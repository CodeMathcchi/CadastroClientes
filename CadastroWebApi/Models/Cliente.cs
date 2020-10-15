using System;
using System.ComponentModel.DataAnnotations;

namespace CadastroWebApi.Models
{
    public class Cliente
    {
        public Cliente()
        {
            
        }

        public Cliente(long ClienteId, string Nome, DateTime DataNascimento, 
                        string Sexo, string Cep, string Rua, string Numero, string Complemento, 
                        string Bairro, string Estado, string Cidade)
        {
            this.ClienteId = ClienteId;
            this.Nome = Nome;
            this.DataNascimento = DataNascimento;
            this.Sexo = Sexo;
            this.Cep = Cep;
            this.Rua = Rua;
            this.Numero = Numero;
            this.Complemento = Complemento;
            this.Bairro = Bairro;
            this.Estado = Estado;
            this.Cidade = Cidade;
        }

        public Cliente(string Nome, DateTime DataNascimento, string Sexo)
        {
            this.Nome = Nome;
            this.DataNascimento = DataNascimento;
            this.Sexo = Sexo;
        }

        public long ClienteId { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Sexo { get; set; }
        public string Cep { get; set; }
        public string Rua { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Estado { get; set; }
        public string Cidade { get; set; }  
    }
}
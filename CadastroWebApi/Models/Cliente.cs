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
                        string Sexo, string Cep, string Logradouro, string Numero, string Complemento, 
                        string Bairro, string Uf, string Localidade)
        {
            this.ClienteId = ClienteId;
            this.Nome = Nome;
            this.DataNascimento = DataNascimento;
            this.Sexo = Sexo;
            this.Cep = Cep;
            this.Logradouro = Logradouro;
            this.Numero = Numero;
            this.Complemento = Complemento;
            this.Bairro = Bairro;
            this.Uf = Uf;
            this.Localidade = Localidade;
        }

        public Cliente(string Nome, DateTime DataNascimento, string Sexo)
        {
            this.Nome = Nome;
            this.DataNascimento = DataNascimento;
            this.Sexo = Sexo;
        }

        public long ClienteId { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento {get; set;}
        public string Sexo { get; set; }
        public string Cep { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Uf { get; set; }
        public string Localidade { get; set; }  
    }
}
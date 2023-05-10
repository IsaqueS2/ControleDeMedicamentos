using ControleDeMedicamentos.ConsoleApp.Compartilhado;
using ControleDeMedicamentos.ConsoleApp.ModuloFornecedor;
using ControleDeMedicamentos.ConsoleApp.ModuloPaciente;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeMedicamentos.ConsoleApp.ModuloRemedio
{
    public class Remedio : Entidade
    {
        public string Nome;
        public decimal Quantidade;
        public string Descricao;
        public int QuantidadeLimite;
        public Fornecedor Fornecedor;

        public Remedio(int id, string nome, decimal quantidade, string descricao, int quantidadeLimite, Fornecedor fornecedor)
        {
            Id = id;
            Nome = nome;
            Quantidade = quantidade;
            Descricao = descricao;
            QuantidadeLimite = quantidadeLimite;
            Fornecedor = fornecedor;
        }
        public override void Atualizar(Entidade registroAtualizado)
        {
            Remedio remedio = (Remedio)registroAtualizado;

            Nome = remedio.Nome;
            Quantidade = remedio.Quantidade;
            Descricao = remedio.Descricao;
            QuantidadeLimite = remedio.QuantidadeLimite;
            Fornecedor = remedio.Fornecedor;
        }
        public void ValidarQuantidadeLimite()
        {
            if (Quantidade > QuantidadeLimite)
            {
                decimal quantidadeSobrando = Quantidade - QuantidadeLimite;
                Quantidade = QuantidadeLimite;
                Console.WriteLine($"Essa quantidade excederá o limite! {quantidadeSobrando} remédios não serão adicionados!");
                Console.ReadLine();
            }
        }
        public void SubtrairQuantidade(int quantidadeSubtrair)
        {
            Quantidade = Quantidade - quantidadeSubtrair;
        }
        public void AdicionarQuantidade(int quantidade)
        {
            Quantidade = Quantidade + quantidade;
        }
    }
}

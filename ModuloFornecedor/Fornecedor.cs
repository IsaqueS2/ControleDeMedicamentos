using ControleDeMedicamentos.ConsoleApp.Compartilhado;
using ControleDeMedicamentos.ConsoleApp.ModuloPaciente;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeMedicamentos.ConsoleApp.ModuloFornecedor
{
    public class Fornecedor : Entidade
    {
        public string Nome;
        public string Endereco;

        public Fornecedor(int id, string nome, string endereco)
        {
            Id = id;
            Nome = nome;
            Endereco = endereco;
        }

        public override void Atualizar(Entidade registroAtualizado)
        {
            Fornecedor fornecedor = (Fornecedor)registroAtualizado;

            Nome = fornecedor.Nome;
            Endereco = fornecedor.Endereco;
        }
    }
}

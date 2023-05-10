using ControleDeMedicamentos.ConsoleApp.Compartilhado;
using ControleDeMedicamentos.ConsoleApp.ModuloPaciente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeMedicamentos.ConsoleApp.ModuloFuncionario
{
    public class Funcionario : Entidade
    {
        public string Nome;
        public string CPF;
        public string Telefone;
        public string Endereco;

        public Funcionario(int id, string nome, string cPF, string telefone, string endereco)
        {
            Id = id;
            Nome = nome;
            CPF = cPF;
            Telefone = telefone;
            Endereco = endereco;
        }

        public override void Atualizar(Entidade registroAtualizado)
        {
            Funcionario funcionario = (Funcionario)registroAtualizado;

            Nome = funcionario.Nome;
            CPF = funcionario.CPF;
            Telefone = funcionario.Telefone;
            Endereco = funcionario.Endereco;
        }
    }
}

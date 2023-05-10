using ControleDeMedicamentos.ConsoleApp.Compartilhado;
using ControleDeMedicamentos.ConsoleApp.ModuloFornecedor;
using ControleDeMedicamentos.ConsoleApp.ModuloFuncionario;
using ControleDeMedicamentos.ConsoleApp.ModuloPaciente;
using ControleDeMedicamentos.ConsoleApp.ModuloRemedio;
using ControleDeMedicamentos.ConsoleApp.ModuloRequisição;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeMedicamentos.ConsoleApp.ModuloAquisição
{
    public class Aquisicao : Entidade
    {
        public Fornecedor Fornecedor;
        public Remedio Remedio;
        public Funcionario Funcionario;
        public string Data;
        public int QuantidadeRemedio;

        public Aquisicao(int id, Fornecedor fornecedor, Remedio remedio, Funcionario funcionario, string data, int quantidadeRemedio)
        {
            Id = id;
            Fornecedor = fornecedor;
            Remedio = remedio;
            Funcionario = funcionario;
            Data = data;
            QuantidadeRemedio = quantidadeRemedio;
        }

        public override void Atualizar(Entidade registroAtualizado)
        {
            Aquisicao aquisicao = (Aquisicao)registroAtualizado;

            Fornecedor = aquisicao.Fornecedor;
            Remedio = aquisicao.Remedio;
            Funcionario = aquisicao.Funcionario;
            Data = aquisicao.Data;
            QuantidadeRemedio = aquisicao.QuantidadeRemedio;
        }
    }
}

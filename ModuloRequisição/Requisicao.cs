using ControleDeMedicamentos.ConsoleApp.Compartilhado;
using ControleDeMedicamentos.ConsoleApp.ModuloFuncionario;
using ControleDeMedicamentos.ConsoleApp.ModuloPaciente;
using ControleDeMedicamentos.ConsoleApp.ModuloRemedio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeMedicamentos.ConsoleApp.ModuloRequisição
{
    public class Requisicao : Entidade
    {
        public Paciente Paciente;
        public Remedio Remedio;
        public Funcionario Funcionario;
        public string Data;
        public int QuantidadeRemedio;

        public Requisicao(int id, Paciente paciente, Remedio remedio, Funcionario funcionario, string data, int quantidadeRemedio)
        {
            Id = id;
            Paciente = paciente;
            Remedio = remedio;
            Funcionario = funcionario;
            Data = data;
            QuantidadeRemedio = quantidadeRemedio;
        }

        public override void Atualizar(Entidade registroAtualizado)
        {
            Requisicao requisicao = (Requisicao)registroAtualizado;

            Paciente = requisicao.Paciente;
            Remedio = requisicao.Remedio;
            Funcionario = requisicao.Funcionario;
            Data = requisicao.Data;
            QuantidadeRemedio = requisicao.QuantidadeRemedio;
        }
    }
}

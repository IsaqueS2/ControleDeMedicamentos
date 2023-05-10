using ControleDeMedicamentos.ConsoleApp.Compartilhado;
using ControleDeMedicamentos.ConsoleApp.InfraMenu;
using ControleDeMedicamentos.ConsoleApp.ModuloFuncionario;
using ControleDeMedicamentos.ConsoleApp.ModuloPaciente;
using ControleDeMedicamentos.ConsoleApp.ModuloRemedio;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeMedicamentos.ConsoleApp.ModuloRequisição
{
    public class TelaRequisicao : Tela
    {
        public RepositorioRequisicao repositorioRequisicao = null;
        public RepositorioPaciente repositorioPaciente = null;
        public RepositorioRemedio repositorioRemedio = null;
        public RepositorioFuncionario repositorioFuncionario = null;

        public string ApresentarMenu()
        {
            Console.Clear();
            while (true)
            {
                Console.Clear();
                Console.WriteLine("-------------------------------------");
                Console.WriteLine("(1) Criar Requisição");
                Console.WriteLine("(2) Editar Requisição");
                Console.WriteLine("(3) Deletar Requisição");
                Console.WriteLine("(4) Listar Requisições");
                Console.WriteLine("(S) Voltar ao Menu Principal");
                Console.WriteLine("-------------------------------------");

                string opcao = Console.ReadLine().ToUpper();

                return opcao;
            }
        }
        public void SelecionarOpcao(string opcao)
        {
            switch (opcao)
            {
                case "1": Inserir(); break;
                case "2": Editar(); break;
                case "3": Deletar(); break;
                case "4": Listar(); break;
                case "S": Menu.VoltarAoMenu(); break;
            }
        }
        public void Inserir()
        {
            Listar();
            Requisicao novoRequisicao = ObterRequisicao();

            repositorioRequisicao.Criar(novoRequisicao);

            ApresentarMensagem("Requisição criada com sucesso!", ConsoleColor.Green);
        }
        public void Editar()
        {
            Listar();
            int idSelecionado = ReceberId();
            Requisicao requisicaoAtualizada = ObterRequisicao();

            repositorioRequisicao.Editar(idSelecionado, requisicaoAtualizada);

            ApresentarMensagem("Requisição editada com sucesso!", ConsoleColor.Green);
        }
        public void Listar()
        {
            ArrayList listaRequisicoes = repositorioRequisicao.SelecionarTodos();

            Console.Clear();

            Console.WriteLine("-------------------------------------------------------------------------------------------------");
            Console.WriteLine("ID   |    PACIENTE    |   REMEDIO   |    FUNCIONARIO    |     DATA     | QUANTIDADE DE REMÉDIOS |");
            Console.WriteLine("-------------------------------------------------------------------------------------------------");

            if (listaRequisicoes.Count == 0)
            {
                ApresentarMensagem("Nenhuma requisição cadastrada!", ConsoleColor.DarkYellow);
                return;
            }

            foreach (Requisicao requisicao in listaRequisicoes)
            {
                Console.WriteLine("{0,-5}|{1,-16}|{2,-13}|{3,-19}|{4,-14}|{5,-24}|", requisicao.Id, requisicao.Paciente.Nome, requisicao.Remedio.Nome, requisicao.Funcionario.Nome, requisicao.Data, requisicao.QuantidadeRemedio);
            }
            Console.WriteLine();
            Console.ReadKey();
        }
        public void Deletar()
        {
            Listar();
            int idSelecionado = ReceberId();
            repositorioRequisicao.Deletar(idSelecionado);
            ApresentarMensagem("Requisição excluída com sucesso!", ConsoleColor.Green);
        }
        public int ReceberId()
        {
            bool idInvalido;
            int id;
            do
            {
                Console.WriteLine("Digite o id da Requisição: ");
                id = int.Parse(Console.ReadLine());

                idInvalido = repositorioRequisicao.SelecionarPorId(id) == null;

                if (idInvalido)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("id Inválido, tente novamente");
                    Console.ResetColor();
                }
            } while (idInvalido);

            return id;
        }
        public Requisicao ObterRequisicao()
        {
            Console.WriteLine("Digite o id do paciente da Requisição: ");
            int pacienteId = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o id do remédio da Requisição: ");
            int remedioId = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o id funcionario da Requisição: ");
            int funcionarioId = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a data da Requisição: ");
            string data = Console.ReadLine();

            Console.WriteLine("Digite a quantidade de remédios: ");
            int quantidadeRemedio = int.Parse(Console.ReadLine());

            Paciente paciente = (Paciente)repositorioPaciente.SelecionarPorId(pacienteId);
            Remedio remedio = (Remedio)repositorioRemedio.SelecionarPorId(remedioId);
            Funcionario funcionario = (Funcionario)repositorioFuncionario.SelecionarPorId(funcionarioId);

            Requisicao requisicao = new Requisicao(repositorioRequisicao.ContadorId, paciente, remedio, funcionario, data, quantidadeRemedio);

            remedio.SubtrairQuantidade(quantidadeRemedio);

            return requisicao;
        }
        
    }

}

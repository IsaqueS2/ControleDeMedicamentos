using ControleDeMedicamentos.ConsoleApp.Compartilhado;
using ControleDeMedicamentos.ConsoleApp.InfraMenu;
using ControleDeMedicamentos.ConsoleApp.ModuloFornecedor;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeMedicamentos.ConsoleApp.ModuloFuncionario
{
    public class TelaFuncionario :Tela
    {
        public RepositorioFuncionario repositorioFuncionario = null;
        public string ApresentarMenu()
        {
            Console.Clear();
            while (true)
            {
                Console.Clear();
                Console.WriteLine("-------------------------------------");
                Console.WriteLine("(1) Criar Funcionario");
                Console.WriteLine("(2) Editar Funcionario");
                Console.WriteLine("(3) Deletar Funcionario");
                Console.WriteLine("(4) Listar Funcionario");
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
            Funcionario novoFuncionario = ObterFuncionario();

            repositorioFuncionario.Criar(novoFuncionario);

            ApresentarMensagem("Funcionario criado com sucesso!", ConsoleColor.Green);
        }
        public void Editar()
        {
            Listar();
            int idSelecionado = ReceberId();
            Funcionario funcionarioAtualizado = ObterFuncionario();

            repositorioFuncionario.Editar(idSelecionado, funcionarioAtualizado);

            ApresentarMensagem("Funcionario editado com sucesso!", ConsoleColor.Green);
        }
        public void Listar()
        {
            ArrayList listaFuncionario = repositorioFuncionario.SelecionarTodos();

            Console.Clear();

            Console.WriteLine("-----------------------------------------------------------");
            Console.WriteLine("ID   |    NOME    |     CPF     |  TELEFONE  |  ENDEREÇO  |");
            Console.WriteLine("-----------------------------------------------------------");

            if (listaFuncionario.Count == 0)
            {
                ApresentarMensagem("Nenhum Funcionario cadastrado!", ConsoleColor.DarkYellow);
                return;
            }

            foreach (Funcionario funcionario in listaFuncionario)
            {
                Console.WriteLine("{0,-5}|{1,-12}|{2,-13}|{3,-12}|{4,-12}|", funcionario.Id, funcionario.Nome, funcionario.CPF,funcionario.Telefone, funcionario.Endereco);
            }
            Console.WriteLine();
            Console.ReadKey();
        }
        public void Deletar()
        {
            Listar();
            int idSelecionado = ReceberId();
            repositorioFuncionario.Deletar(idSelecionado);
            ApresentarMensagem("Fornecedor excluído com sucesso!", ConsoleColor.Green);
        }
        public int ReceberId()
        {
            bool idInvalido;
            int id;
            do
            {
                Console.WriteLine("Digite o id do Funcionario: ");
                id = int.Parse(Console.ReadLine());

                idInvalido = repositorioFuncionario.SelecionarPorId(id) == null;

                if (idInvalido)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("id Inválido, tente novamente");
                    Console.ResetColor();
                }
            } while (idInvalido);

            return id;
        }
        public Funcionario ObterFuncionario()
        {
            Console.WriteLine("Digite o nome do funcionario: ");
            string nome = Console.ReadLine();

            Console.WriteLine("Digite o CPF do funcionario: ");
            string cpf = Console.ReadLine();

            Console.WriteLine("Digite o Telefone do funcionario: ");
            string telefone = Console.ReadLine();

            Console.WriteLine("Digite o endereço do funcionario: ");
            string endereco = Console.ReadLine();


            //Pode criar Remédio sem ser na criação de um fornecedor?
            Funcionario funcionario = new Funcionario(repositorioFuncionario.ContadorId, nome, cpf, telefone, endereco);

            return funcionario;
        }
    }
}

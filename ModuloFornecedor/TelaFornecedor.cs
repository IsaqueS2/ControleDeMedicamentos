using ControleDeMedicamentos.ConsoleApp.Compartilhado;
using ControleDeMedicamentos.ConsoleApp.InfraMenu;
using ControleDeMedicamentos.ConsoleApp.ModuloPaciente;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeMedicamentos.ConsoleApp.ModuloFornecedor
{
    public class TelaFornecedor : Tela
    {
        public RepositorioFornecedor repositorioFornecedor = null;
        public string ApresentarMenu()
        {
            Console.Clear();
            while (true)
            {
                Console.Clear();
                Console.WriteLine("-------------------------------------");
                Console.WriteLine("(1) Criar Fornecedor");
                Console.WriteLine("(2) Editar Fornecedor");
                Console.WriteLine("(3) Deletar Fornecedor");
                Console.WriteLine("(4) Listar Fornecedor");
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
            Fornecedor novoFornecedor = ObterFornecedor();

            repositorioFornecedor.Criar(novoFornecedor);

            ApresentarMensagem("Fornecedor criado com sucesso!", ConsoleColor.Green);
        }
        public void Editar()
        {
            Listar();
            int idSelecionado = ReceberId();
            Fornecedor fornecedorAtualizado = ObterFornecedor();

            repositorioFornecedor.Editar(idSelecionado, fornecedorAtualizado);

            ApresentarMensagem("Fornecedor editado com sucesso!", ConsoleColor.Green);
        }
        public void Listar()
        {
            ArrayList listaFornecedor = repositorioFornecedor.SelecionarTodos();

            Console.Clear();

            Console.WriteLine("--------------------------------");
            Console.WriteLine("ID   |    NOME    |  ENDEREÇO  |");
            Console.WriteLine("--------------------------------");

            if (listaFornecedor.Count == 0)
            {
                ApresentarMensagem("Nenhum fornecedor cadastrado!", ConsoleColor.DarkYellow);
                return;
            }

            foreach (Fornecedor fornecedor in listaFornecedor)
            {
                Console.WriteLine("{0,-5}|{1,-12}|{2,-12}|", fornecedor.Id, fornecedor.Nome, fornecedor.Endereco);
            }
            Console.WriteLine();
            Console.ReadKey();
        }
        public void Deletar()
        {
            Listar();
            int idSelecionado = ReceberId();
            repositorioFornecedor.Deletar(idSelecionado);
            ApresentarMensagem("Fornecedor excluído com sucesso!", ConsoleColor.Green);
        }
        public int ReceberId()
        {
            bool idInvalido;
            int id;
            do
            {
                Console.WriteLine("Digite o id do Fornecedor: ");
                id = int.Parse(Console.ReadLine());

                idInvalido = repositorioFornecedor.SelecionarPorId(id) == null;

                if (idInvalido)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("id Inválido, tente novamente");
                    Console.ResetColor();
                }
            } while (idInvalido);

            return id;
        }
        public Fornecedor ObterFornecedor()
        {
            Console.WriteLine("Digite o nome do fornecedor: ");
            string nome = Console.ReadLine();

            Console.WriteLine("Digite o endereço do fornecedor: ");
            string endereco = Console.ReadLine();

            
            //Pode criar Remédio sem ser na criação de um fornecedor?
            Fornecedor fornecedor = new Fornecedor(repositorioFornecedor.ContadorId, nome, endereco);

            return fornecedor;
        }
    }
}

using ControleDeMedicamentos.ConsoleApp.Compartilhado;
using ControleDeMedicamentos.ConsoleApp.InfraMenu;
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
    public class TelaRemedio : Tela
    {
        public RepositorioRemedio repositorioRemedio = null;
        public RepositorioFornecedor repositorioFornecedor = null;
        public string ApresentarMenu()
        {
            Console.Clear();
            while (true)
            {
                Console.Clear();
                Console.WriteLine("-------------------------------------");
                Console.WriteLine("(1) Criar Remédio");
                Console.WriteLine("(2) Editar Remédio");
                Console.WriteLine("(3) Deletar Remédio");
                Console.WriteLine("(4) Listar Remédio");
                Console.WriteLine("(5) Gerenciar quantidade de Remédio");
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
                case "5": GerenciarQuantidade(); break;
                case "S": Menu.VoltarAoMenu(); break;
            }
        }
        public void Inserir()
        {
            Listar();
            Remedio novoRemedio = ObterRemedio();

            repositorioRemedio.Criar(novoRemedio);

            ApresentarMensagem("Remedio criado com sucesso!", ConsoleColor.Green);
        }
        public void Editar()
        {
            Listar();
            int idSelecionado = ReceberId();
            Remedio remedioAtualizado = ObterRemedio();

            repositorioRemedio.Editar(idSelecionado, remedioAtualizado);

            ApresentarMensagem("Remédio editado com sucesso!", ConsoleColor.Green);
        }
        public void Listar()
        {
            ArrayList listaRemedio = repositorioRemedio.SelecionarTodos();

            Console.Clear();

            Console.WriteLine("--------------------------------------------------------------------------------");
            Console.WriteLine("ID   |    NOME    | QUANTIDADE | QUANTIDADE LIMITE |  DESCRIÇÃO  |  FORNECEDOR  |");
            Console.WriteLine("--------------------------------------------------------------------------------");

            if (listaRemedio.Count == 0)
            {
                ApresentarMensagem("Nenhum remédio cadastrado!", ConsoleColor.DarkYellow);
                return;
            }

            foreach (Remedio remedio in listaRemedio)
            {
                Console.WriteLine("{0,-5}|{1,-12}|{2,-12}|{3,-19}|{4,-13}|{5,-14}|", remedio.Id, remedio.Nome, remedio.Quantidade, remedio.QuantidadeLimite, remedio.Descricao, remedio.Fornecedor.Nome);
            }
            Console.WriteLine();
            Console.ReadKey();
        }
        public void Deletar()
        {
            Listar();
            int idSelecionado = ReceberId();
            repositorioRemedio.Deletar(idSelecionado);
            ApresentarMensagem("Remedio excluído com sucesso!", ConsoleColor.Green);
        }
        public int ReceberId()
        {
            bool idInvalido;
            int id;
            do
            {
                Console.WriteLine("Digite o id do remédio: ");
                id = int.Parse(Console.ReadLine());

                idInvalido = repositorioRemedio.SelecionarPorId(id) == null;

                if (idInvalido)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("id Inválido, tente novamente");
                    Console.ResetColor();
                }
            } while (idInvalido);

            return id;
        }
        public Remedio ObterRemedio()
        {
            Console.WriteLine("Digite o nome do remédio: ");
            string nome = Console.ReadLine();

            Console.WriteLine("Digite a quantidade do remédio: ");
            int quantidade = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a descricao do remédio: ");
            string descricao = Console.ReadLine();

            Console.WriteLine("Digite a quantidade limite do remédio: ");
            int qtdLimite = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o id do fornecedor: ");
            int idFornecedor = int.Parse(Console.ReadLine());

            Fornecedor fornecedor = null;
            foreach (Fornecedor f in repositorioFornecedor.Cadastros)
            {
                if (idFornecedor == f.Id)
                {
                    fornecedor = f;
                    break;
                }
            }

            Remedio remedio = new Remedio(repositorioRemedio.ContadorId, nome, quantidade, descricao, qtdLimite, fornecedor);

            remedio.AdicionarQuantidade(quantidade);
            remedio.ValidarQuantidadeLimite();

            return remedio;
        }

        private void GerenciarQuantidade()
        {
            Listar();
            int idSelecionado = ReceberId();
            while (true)
            {
                Console.Clear();
                Console.WriteLine("-------------------------------------");
                Console.WriteLine("(1) Adicionar Remédio");
                Console.WriteLine("(2) Remover Remédio");
                Console.WriteLine("(S) Voltar ao Menu");
                Console.WriteLine("-------------------------------------");
                string opcao = Console.ReadLine().ToUpper();

                switch (opcao)
                {
                    case "1": AdicionarQuantidadeRemedio(idSelecionado); break;
                    case "2": SubtrairQuantidadeRemedio(idSelecionado); break;
                    case "S": Menu.VoltarAoMenu(); return;
                }
            }
        }
        public void SubtrairQuantidadeRemedio(int idSelecionado)
        {
            Console.WriteLine("Digite a quantidade de rémédios para subtrair");
            int quantidadeSubtrair = int.Parse(Console.ReadLine());
            repositorioRemedio.SubtrairRemedio(idSelecionado, quantidadeSubtrair);
        }
        public void AdicionarQuantidadeRemedio(int idSelecionado)
        {
            Console.WriteLine("Digite a quantidade de rémédios a adicionar");
            int quantidade = int.Parse(Console.ReadLine());
            repositorioRemedio.AdicionarRemedio(idSelecionado, quantidade);
        }
        public void ListarRemédiosEmFalta()
        {
            ArrayList listaRemedio = repositorioRemedio.SelecionarTodos();

            Console.Clear();
            Console.WriteLine("REMÉDIOS EM FALTA: \n");
            Console.WriteLine("--------------------------------");
            Console.WriteLine("ID   |    NOME    | QUANTIDADE |");
            Console.WriteLine("--------------------------------");

            if (listaRemedio.Count == 0)
            {
                ApresentarMensagem("Nenhum remédio em cadastrado!", ConsoleColor.DarkYellow);
                return;
            }
            foreach (Remedio remedio in listaRemedio)
            {
                if (remedio.Quantidade < 15)
                {
                    Console.WriteLine("{0,-5}|{1,-12}|{2,-12}|", remedio.Id, remedio.Nome, remedio.Quantidade);
                }
            }

            Console.WriteLine();
            Console.ReadKey();
        }
    }
}

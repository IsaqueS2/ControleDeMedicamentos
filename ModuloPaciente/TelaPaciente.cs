using ControleDeMedicamentos.ConsoleApp.Compartilhado;
using ControleDeMedicamentos.ConsoleApp.InfraMenu;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeMedicamentos.ConsoleApp.ModuloPaciente
{
    public class TelaPaciente : Tela
    {
        public RepositorioPaciente repositorioPaciente = null;

        public string ApresentarMenu()
        {
            Console.Clear();
            while (true)
            {
                Console.Clear();
                Console.WriteLine("-------------------------------------");
                Console.WriteLine("(1) Criar Paciente");
                Console.WriteLine("(2) Editar Paciente");
                Console.WriteLine("(3) Deletar Paciente");
                Console.WriteLine("(4) Listar Paciente");
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
            Paciente novoPaciente = ObterPaciente();

            repositorioPaciente.Criar(novoPaciente);

            ApresentarMensagem("Paciente criado com sucesso!", ConsoleColor.Green);
        }
        public void Editar()
        {
            Listar();
            int idSelecionado = ReceberId();
            Paciente pacienteAtualizado = ObterPaciente();

            repositorioPaciente.Editar(idSelecionado, pacienteAtualizado);

            ApresentarMensagem("Paciente editado com sucesso!", ConsoleColor.Green);
        }
        public void Listar()
        {
            ArrayList listaPacientes = repositorioPaciente.SelecionarTodos();

            Console.Clear();

            Console.WriteLine("----------------------------------------------------------------------------------");
            Console.WriteLine("ID   |    NOME    |   TELEFONE   |      CPF      |    ENDEREÇO    |  CARTÃO SUS  |");
            Console.WriteLine("----------------------------------------------------------------------------------");

            if (listaPacientes.Count == 0)
            {
                ApresentarMensagem("Nenhum paciente cadastrado!", ConsoleColor.DarkYellow);
                return;
            }

            foreach (Paciente paciente in listaPacientes)
            {
                Console.WriteLine("{0,-5}|{1,-12}|{2,-14}|{3,-15}|{4,-16}|{5,-14}|", paciente.Id, paciente.Nome, paciente.Telefone, paciente.CPF, paciente.Endereco, paciente.CartaoSus);
            }
            Console.WriteLine();
            Console.ReadKey();
        }
        public void Deletar()
        {
            Listar();
            int idSelecionado = ReceberId();
            repositorioPaciente.Deletar(idSelecionado);
            ApresentarMensagem("Paciente excluído com sucesso!", ConsoleColor.Green);
        }
        public int ReceberId()
        {
            bool idInvalido;
            int id;
            do
            {
                Console.WriteLine("Digite o id do Paciente: ");
                id = int.Parse(Console.ReadLine());

                idInvalido = repositorioPaciente.SelecionarPorId(id) == null;

                if (idInvalido)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("id Inválido, tente novamente");
                    Console.ResetColor();
                }
            } while (idInvalido);

            return id;
        }
        public Paciente ObterPaciente()
        {
            Console.WriteLine("Digite o nome do paciente: ");
            string nome = Console.ReadLine();

            Console.WriteLine("Digite o número do telefone do paciente: ");
            string telefone = Console.ReadLine();

            Console.WriteLine("Digite o CPF do paciente: ");
            string CPF = Console.ReadLine();

            Console.WriteLine("Digite o endereço do paciente: ");
            string endereço = Console.ReadLine();

            Console.WriteLine("Digite o número do cartão do Sus: ");
            string cartaoSus = Console.ReadLine();


            Paciente paciente = new Paciente(repositorioPaciente.ContadorId, nome, telefone, CPF, endereço, cartaoSus);

            return paciente;
        }

    }
}

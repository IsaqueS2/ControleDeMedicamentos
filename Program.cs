using ControleDeMedicamentos.ConsoleApp.Compartilhado;
using ControleDeMedicamentos.ConsoleApp.InfraMenu;
using ControleDeMedicamentos.ConsoleApp.ModuloAquisição;
using ControleDeMedicamentos.ConsoleApp.ModuloFornecedor;
using ControleDeMedicamentos.ConsoleApp.ModuloFuncionario;
using ControleDeMedicamentos.ConsoleApp.ModuloPaciente;
using ControleDeMedicamentos.ConsoleApp.ModuloRemedio;
using ControleDeMedicamentos.ConsoleApp.ModuloRequisição;

namespace ControleDeMedicamentos.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Menu menu = new Menu();

            TelaPaciente telaPaciente = new TelaPaciente();
            TelaFornecedor telaFornecedor = new TelaFornecedor();
            TelaRemedio telaRemedio = new TelaRemedio();
            TelaRequisicao telaRequisicao = new TelaRequisicao();
            TelaFuncionario telaFuncionario = new TelaFuncionario();
            TelaAquisicao telaAquisicao = new TelaAquisicao();

            RepositorioPaciente repositorioPaciente = new RepositorioPaciente();
            RepositorioFornecedor repositorioFornecedor = new RepositorioFornecedor();
            RepositorioRemedio repositorioRemedio = new RepositorioRemedio();
            RepositorioRequisicao repositorioRequisicao = new RepositorioRequisicao();
            RepositorioFuncionario repositorioFuncionario = new RepositorioFuncionario();
            RepositorioAquisicao repositorioAquisicao = new RepositorioAquisicao();

            menu.telaPaciente = telaPaciente;
            menu.telaRemedio = telaRemedio;
            menu.telaFornecedor = telaFornecedor;
            menu.telaFuncionario = telaFuncionario;
            menu.telaRequisicao = telaRequisicao;
            menu.telaAquisicao = telaAquisicao;

            telaPaciente.repositorioPaciente = repositorioPaciente;
            telaFornecedor.repositorioFornecedor = repositorioFornecedor;
            telaRemedio.repositorioRemedio = repositorioRemedio;
            telaRemedio.repositorioFornecedor = repositorioFornecedor;
            telaFuncionario.repositorioFuncionario = repositorioFuncionario;
            telaRequisicao.repositorioRequisicao = repositorioRequisicao;
            telaRequisicao.repositorioPaciente = repositorioPaciente;
            telaRequisicao.repositorioFuncionario = repositorioFuncionario;
            telaRequisicao.repositorioRemedio = repositorioRemedio;
            telaAquisicao.repositorioFuncionario = repositorioFuncionario;
            telaAquisicao.repositorioRemedio = repositorioRemedio;
            telaAquisicao.repositorioFornecedor = repositorioFornecedor;
            telaAquisicao.repositorioAquisicao = repositorioAquisicao;

            //CRIANDO FORNECEDORES
            //-------------------------------------------------------------------------------------------------------------
            Fornecedor fornecedor0 = new Fornecedor(0, "Eurofarma", "88525190");
            Fornecedor fornecedor1 = new Fornecedor(1, "Aché", "88535170");
            Fornecedor fornecedor2 = new Fornecedor(2, "LIBS", "88618140");
            Fornecedor fornecedor3 = new Fornecedor(3, "Midfarma", "88321321");
            repositorioFornecedor.Criar(fornecedor0);
            repositorioFornecedor.Criar(fornecedor1);
            repositorioFornecedor.Criar(fornecedor2);
            repositorioFornecedor.Criar(fornecedor3);
            //-------------------------------------------------------------------------------------------------------------
            //CRIANDO REMÉDIOS
            //-------------------------------------------------------------------------------------------------------------
            Remedio remedio0 = new Remedio(0, "Paracetamol", 47, "Analgésico", 100, fornecedor0);
            Remedio remedio1 = new Remedio(1, "atamol", 42, "Analgésico", 100, fornecedor1);
            Remedio remedio2 = new Remedio(2, "cimegripe", 44, "Gripe", 100, fornecedor2);
            Remedio remedio3 = new Remedio(3, "Buscopa", 8, "Analgésico", 100, fornecedor3);
            repositorioRemedio.Criar(remedio0);
            repositorioRemedio.Criar(remedio1);
            repositorioRemedio.Criar(remedio2);
            repositorioRemedio.Criar(remedio3);
            //-------------------------------------------------------------------------------------------------------------
            //CRIANDO FUNCIONARIOS
            //-------------------------------------------------------------------------------------------------------------
            Funcionario funcionario0 = new Funcionario(0, "Jailson", "88234723", "415678567", "2354546283");
            Funcionario funcionario1 = new Funcionario(1, "João", "212567723", "62354234", "908756283");
            Funcionario funcionario2 = new Funcionario(2, "Maria", "32234723", "59879789", "23653453890");
            Funcionario funcionario3 = new Funcionario(3, "Mario", "4123450543", "254724123", "89089234");
            repositorioFuncionario.Criar(funcionario0);
            repositorioFuncionario.Criar(funcionario1);
            repositorioFuncionario.Criar(funcionario2);
            repositorioFuncionario.Criar(funcionario3);
            //-------------------------------------------------------------------------------------------------------------
            //CRIAR PACIENTE
            //-------------------------------------------------------------------------------------------------------------
            Paciente paciente0 = new Paciente(0, "Kleberson", "829237", "9789789", "24938247", "1111111");
            Paciente paciente1 = new Paciente(1, "José", "21343424", "87235566", "68854654", "2223333");
            Paciente paciente2 = new Paciente(2, "John", "123213", "3333333", "77777", "4414444");
            Paciente paciente3 = new Paciente(3, "Jack", "23545345", "4444444", "888899", "12121211");
            repositorioPaciente.Criar(paciente0);
            repositorioPaciente.Criar(paciente1);
            repositorioPaciente.Criar(paciente2);
            repositorioPaciente.Criar(paciente3);
            //-------------------------------------------------------------------------------------------------------------
            //CRIAR REQUISIÇÕES
            //-------------------------------------------------------------------------------------------------------------
            Requisicao requisicao0 = new Requisicao(0, paciente0, remedio0, funcionario0, "12/12/2000", 2);
            Requisicao requisicao1 = new Requisicao(1, paciente1, remedio1, funcionario1, "12/12/2000", 3);
            Requisicao requisicao2 = new Requisicao(2, paciente2, remedio2, funcionario2, "12/12/2000", 1);
            Requisicao requisicao3 = new Requisicao(3, paciente3, remedio3, funcionario3, "12/12/2000", 4);
            repositorioRequisicao.Criar(requisicao0);
            repositorioRequisicao.Criar(requisicao1);
            repositorioRequisicao.Criar(requisicao2);
            repositorioRequisicao.Criar(requisicao3);
            //-------------------------------------------------------------------------------------------------------------
            //CRIAR AQISIÇÕES
            //-------------------------------------------------------------------------------------------------------------
            Aquisicao aquisicao0 = new Aquisicao(0, fornecedor0, remedio0, funcionario0, "05/04/2023", 10);
            Aquisicao aquisicao1 = new Aquisicao(1, fornecedor1, remedio1, funcionario1, "05/04/2023", 5);
            Aquisicao aquisicao2 = new Aquisicao(2, fornecedor2, remedio2, funcionario2, "05/04/2023", 15);
            Aquisicao aquisicao3 = new Aquisicao(3, fornecedor3, remedio3, funcionario3, "05/04/2023", 12);
            repositorioAquisicao.Criar(aquisicao0);
            repositorioAquisicao.Criar(aquisicao1);
            repositorioAquisicao.Criar(aquisicao2);
            repositorioAquisicao.Criar(aquisicao3);
            //-------------------------------------------------------------------------------------------------------------

            menu.ExecutarMenuPrincipal();
        }
    }
}
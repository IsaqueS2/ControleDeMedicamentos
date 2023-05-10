using ControleDeMedicamentos.ConsoleApp.Compartilhado;

namespace ControleDeMedicamentos.ConsoleApp.ModuloRemedio
{
    public class RepositorioRemedio : Repositorio
    {
        public void AdicionarRemedio(int idSelecionado, int quantidade)
        {
            Remedio remedio = (Remedio)SelecionarPorId(idSelecionado);
            remedio.AdicionarQuantidade(quantidade);
            remedio.ValidarQuantidadeLimite();
        }
        public void SubtrairRemedio(int idSelecionado, int quantidadeSubtrair)
        {
            Remedio remedio = (Remedio)SelecionarPorId(idSelecionado);
            remedio.SubtrairQuantidade(quantidadeSubtrair);
        }
    }
}

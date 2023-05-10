using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeMedicamentos.ConsoleApp.Compartilhado
{
    public class Entidade
    {
        public int Id;

        public virtual void Atualizar(Entidade registroAtualizado)
        {
            Id = registroAtualizado.Id;
        }

    }
}

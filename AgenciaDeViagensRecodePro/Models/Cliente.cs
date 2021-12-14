using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace AgenciaDeViagensRecodePro.Models
{
    public partial class Cliente
    {
        public Cliente()
        {
            Pacote = new HashSet<Pacote>();
        }

        public int IdCliente { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Telefone { get; set; }

        public virtual ICollection<Pacote> Pacote { get; set; }
    }
}

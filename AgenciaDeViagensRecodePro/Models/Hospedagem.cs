using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace AgenciaDeViagensRecodePro.Models
{
    public partial class Hospedagem
    {
        public Hospedagem()
        {
            Pacote = new HashSet<Pacote>();
        }

        public int IdHospedagem { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string Telefone { get; set; }
        public int? Diarias { get; set; }
        public double? ValorDiaria { get; set; }

        public virtual ICollection<Pacote> Pacote { get; set; }
    }
}

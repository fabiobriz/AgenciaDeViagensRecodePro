using System;
using System.Collections.Generic;
using System.ComponentModel;

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
        [DisplayName("Endereço")]
        public string Endereco { get; set; }
        public string Telefone { get; set; }
        [DisplayName("Diárias")]
        public int? Diarias { get; set; }
        [DisplayName("Valor da diária")]
        public double? ValorDiaria { get; set; }

        public virtual ICollection<Pacote> Pacote { get; set; }
    }
}

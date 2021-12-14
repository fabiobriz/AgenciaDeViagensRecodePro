using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace AgenciaDeViagensRecodePro.Models
{
    public partial class Passagem
    {
        public Passagem()
        {
            Pacote = new HashSet<Pacote>();
        }

        public int IdPassagem { get; set; }
        public DateTime? DataPartida { get; set; }
        public DateTime? DataChegada { get; set; }
        public string LocalPartida { get; set; }
        public string LocalChegada { get; set; }
        public double? Valor { get; set; }

        public virtual ICollection<Pacote> Pacote { get; set; }
    }
}

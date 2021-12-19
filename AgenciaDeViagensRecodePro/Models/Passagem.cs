using System;
using System.Collections.Generic;
using System.ComponentModel;

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
        [DisplayName("Data de partida")]
        public DateTime? DataPartida { get; set; }
        [DisplayName("Data de chegada")]
        public DateTime? DataChegada { get; set; }
        [DisplayName("Local de partida")]
        public string LocalPartida { get; set; }
        [DisplayName("Local de chegada")]
        public string LocalChegada { get; set; }
        public double? Valor { get; set; }

        public virtual ICollection<Pacote> Pacote { get; set; }
    }
}

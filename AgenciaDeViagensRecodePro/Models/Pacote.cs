using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace AgenciaDeViagensRecodePro.Models
{
    public partial class Pacote
    {
        public int IdPacote { get; set; }
        public string Tipo { get; set; }
        public int? FkClienteIdCliente { get; set; }
        public int? FkPassagemIdPassagem { get; set; }
        public int? FkHospedagemIdHospedagem { get; set; }

        public virtual Cliente FkClienteIdClienteNavigation { get; set; }
        public virtual Hospedagem FkHospedagemIdHospedagemNavigation { get; set; }
        public virtual Passagem FkPassagemIdPassagemNavigation { get; set; }
    }
}

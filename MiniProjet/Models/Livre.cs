using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace MiniProjet.Models
{
    public partial class Livre
    {
        public Livre()
        {
            Empreint = new HashSet<Empreint>();
        }

        public int IdLivre { get; set; }
        public string Titre { get; set; }
        public string Isbm { get; set; }
        public int AnneeEdition { get; set; }
        public string Resume { get; set; }
        public int Nombre { get; set; }
        public string Image { get; set; }

        public virtual ICollection<Empreint> Empreint { get; set; }
    }
}

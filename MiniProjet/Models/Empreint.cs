using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace MiniProjet.Models
{
    public partial class Empreint
    {
        public int IdEmpreinte { get; set; }
        public int IdLivre { get; set; }
        public int IdEtudiant { get; set; }
        public DateTime? Du { get; set; }
        public DateTime? Au { get; set; }

        public virtual Etudiant IdEtudiantNavigation { get; set; }
        public virtual Livre IdLivreNavigation { get; set; }
    }
}

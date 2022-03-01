using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace MiniProjet.Models
{
    public partial class Etudiant
    {
        public Etudiant()
        {
            Empreint = new HashSet<Empreint>();
        }

        public int IdEtudiant { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Classe { get; set; }

        public virtual ICollection<Empreint> Empreint { get; set; }
    }
}

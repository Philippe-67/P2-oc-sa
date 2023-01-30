using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace P2FixAnAppDotNetCode.Models
{
    public class Commande
    {
        [BindNever]
        public int IdCommande { get; set; }
        [BindNever]
        // BeFr - Remplace : public ICollection<LignePanier> Lignes { get; set; }
        //             par : public ICollection<LignePanier>? Lignes { get; set; }
        public ICollection<LignePanier>? Lignes { get; set; }
        [Required(ErrorMessage = "ErrorMissingName")]
        public string Nom { get; set; }

        [Required(ErrorMessage = "ErrorMissingAddress")]
        public string Adresse { get; set; }

        [Required(ErrorMessage = "ErrorMissingCity")]
        public string Ville { get; set; }
        [Required(ErrorMessage = "ErrorMissingZip")]
        public string CodePostal { get; set; }

        [Required(ErrorMessage = "ErrorMissingCountry")]
        public string Pays { get; set; }

        [BindNever]
        public DateTime Date { get; set; }
    }
}

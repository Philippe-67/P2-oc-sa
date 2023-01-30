using System.Collections.Generic;
using System.Linq;

namespace P2FixAnAppDotNetCode.Models
{
    /// <summary>
    /// La classe Panier
    /// </summary>
    public class Panier : IPanier
    {
        /// <summary>
        /// Propriété en lecture seule pour affichage seulement
        /// </summary>
        //public IEnumerable<LignePanier> Lignes => GetListeDesLignesDuPanier();
        private List<LignePanier> lignesPanier = new List<LignePanier>(); 
        public IEnumerable<LignePanier> Lignes => lignesPanier;
        /// <summary>
        /// Retour la liste des lignes du panier
        /// </summary>
        /// <returns></returns>
        private List<LignePanier> GetListeDesLignesDuPanier()
        {
            // BeFr - Remplace : return new List<LignePanier>();
            //             par : return lignesPanier;
            return lignesPanier;
        }

        /// <summary>
        /// Ajoute un produit dans le panier ou incrémente sa quantité dans le panier si déjà présent
        /// </summary>//
        public void AjouterElement(Produit produit, int quantite)
        {
            // TODO implementer la méthode
            //BeFr - Ajouter un élément (cf.
            if (lignesPanier.Exists(p => p.Produit.Id == produit.Id))
            {
                foreach (LignePanier ligne in lignesPanier)
                {
                    if (ligne.Produit.Id == produit.Id)
                    {
                        ligne.Quantite += quantite;
                    }
                }
            }
            else
            {
                lignesPanier.Add(new LignePanier()
                {
                    Produit = produit,
                    Quantite = quantite,
                });
            }
        }

        /// <summary>
        /// Supprimer un produit du panier
        /// </summary>
        public void SupprimerLigne(Produit produit) =>
            GetListeDesLignesDuPanier().RemoveAll(l => l.Produit.Id == produit.Id);

        /// <summary>
        /// Récupère la valeur totale du panier
        /// </summary>
        public double GetValeurTotale()
        {
            // TODO implementer la méthode
            //BeFr - Ajout Calcul Total Panier
            double somme = 0.0;
            foreach (LignePanier lignes in lignesPanier)
            {
                somme += (lignes.Quantite * lignes.Produit.Prix);
            }
            return somme;
        }

        /// <summary>
        /// Récupère la valeur moyenne du panier
        /// </summary>
        public double GetValeurMoyenne()
        {
            // TODO implementer la méthode
            //BeFr - Ajout Calcul Valeur Moyenne
            double moyenne = 0.0;
            double quantiteTotale = 0.0;
            foreach (var lignes in lignesPanier)
            {
                moyenne += (lignes.Quantite * lignes.Produit.Prix);
                quantiteTotale += lignes.Quantite;
            }
            return moyenne / quantiteTotale;
        }

        /// <summary>
        /// Cherche un produit donné dans le panier et le retourne si trouvé
        /// </summary>
        public Produit TrouveProduitDansLesLignesDuPanier(int idProduit)
        {
            // TODO implementer la méthode
            //BeFr
            Produit trouveProduit = null;
            foreach (var ligne in lignesPanier)
            {
                if (ligne.Produit.Id == idProduit)
                    trouveProduit = ligne.Produit;
            }
            return trouveProduit;
        }

        /// <summary>
        /// Retourne une ligne de panier à partir de son indice
        /// </summary>
        public LignePanier GetLignePanierParIndice(int indice)
        {
            return Lignes.ToArray()[indice];
        }

        /// <summary>
        /// Vide un panier de tous ses produits
        /// </summary>
        public void Vider()
        {
            List<LignePanier> lignePaniers = GetListeDesLignesDuPanier();
            lignePaniers.Clear();
        }
    }

    public class LignePanier
    {
        public int CommandeLigneId { get; set; }
        public Produit Produit { get; set; }
        public int Quantite { get; set; }
    }
}

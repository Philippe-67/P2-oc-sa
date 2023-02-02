namespace P2FixAnAppDotNetCode.Models.Repositories
{
    public interface IProduitRepository
    {
        // PCh - Remplace : public Produit[] GetTousLesProduits()
        //             par : public List<Produit> GetTousLesProduits()
        public List<Produit> GetTousLesProduits();

        void MetAJourLaQuantiteDunProduit(int idProduit, int quantiteASupprimer);
    }
}

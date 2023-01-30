namespace P2FixAnAppDotNetCode.Models.Services
{
    public interface IProduitService
    {
        // BeFr - Remplace : Produit[] GetTousLesProduits();
        //             par : List<Produit> GetTousLesProduits();
        List<Produit> GetTousLesProduits();
        Produit GetProduitParId(int id);
        void MetAJourLesQuantitesDuPanier(Panier panier);
    }
}


namespace P2FixAnAppDotNetCode.Models
{
    public interface ICart
    {
        void AddItem(Product product, int quantity);

        void RemoveLine(Product product);

        void Clear();

        /// <summary>
        /// Obtient le prix de tous les articles
        /// </summary>
        /// <returns></returns>
        double GetTotalValue();

        /// <summary>
        /// Obtient la moyenne du prix du panier
        /// </summary>
        /// <returns></returns>
        double GetAverageValue();
    }
}
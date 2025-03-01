using System.Collections.Generic;
using System.Linq;

namespace P2FixAnAppDotNetCode.Models
{
    /// <summary>
    /// The Cart class
    /// </summary>
    public class Cart : ICart
    {
        /// <summary>
        /// Liste actuelle des paniers
        /// </summary>
        private readonly List<CartLine> _cartLinesList = new List<CartLine>();
        
        /// <summary>
        /// Read-only property for dispaly only
        /// </summary>
        public IEnumerable<CartLine> Lines => _cartLinesList;
        

        /// <summary>
        /// Adds a product in the cart or increment its quantity in the cart if already added
        /// </summary>//
        public void AddItem(Product product, int quantity)
        {
            if (quantity <= 0)
                return;
            
            var cartLine = _cartLinesList.FirstOrDefault(f => f.Product.Id == product.Id);
            if (cartLine == null)
            {
                cartLine = new CartLine()
                {
                    Product = product,
                    Quantity = quantity
                };
                
                _cartLinesList.Add(cartLine);
            }
            else
            {
                cartLine.Quantity += quantity;
            }
        }

        /// <summary>
        /// Removes a product form the cart
        /// </summary>
        public void RemoveLine(Product product) =>
            _cartLinesList.RemoveAll(l => l.Product.Id == product.Id);

        /// <summary>
        /// Get total value of a cart
        /// </summary>
        public double GetTotalValue() => _cartLinesList.Select(s => s.Product.Price).Sum();

        /// <summary>
        /// Get average value of a cart
        /// </summary>
        public double GetAverageValue() => _cartLinesList.Select(s => s.Product.Price).Average();

        /// <summary>
        /// Looks after a given product in the cart and returns if it finds it
        /// </summary>
        public Product FindProductInCartLines(int productId)
        {
            return _cartLinesList.FirstOrDefault(l => l.Product.Id == productId)?.Product;
        }

        /// <summary>
        /// Get a specifid cartline by its index
        /// </summary>
        public CartLine GetCartLineByIndex(int index)
        {
            return index < 0 || index > _cartLinesList.Count - 1
                ? null
                : _cartLinesList[index];
        }

        /// <summary>
        /// Clears a the cart of all added products
        /// </summary>
        public void Clear()
        {
            _cartLinesList.Clear();
        }
    }

    public class CartLine
    {
        public int OrderLineId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}

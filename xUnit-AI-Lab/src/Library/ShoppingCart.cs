namespace Library;

/// <summary>
/// Represents a shopping cart for an e-commerce application.
/// </summary>
public class ShoppingCart
{
    private readonly List<CartItem> _items;
    private readonly Dictionary<string, decimal> _discountCodes;

    public IReadOnlyList<CartItem> Items => _items.AsReadOnly();
    public int ItemCount => _items.Sum(item => item.Quantity);
    public bool IsEmpty => _items.Count == 0;

    public ShoppingCart()
    {
        _items = new List<CartItem>();
        _discountCodes = new Dictionary<string, decimal>
        {
            { "SAVE10", 0.10m },
            { "SAVE20", 0.20m },
            { "FIRSTTIME", 0.15m }
        };
    }

    /// <summary>
    /// Adds an item to the cart.
    /// </summary>
    /// <param name="product">Product to add</param>
    /// <param name="quantity">Quantity to add</param>
    /// <exception cref="ArgumentNullException">Thrown when product is null</exception>
    /// <exception cref="ArgumentException">Thrown when quantity is not positive</exception>
    public void AddItem(Product product, int quantity = 1)
    {
        if (product == null)
            throw new ArgumentNullException(nameof(product));
        
        if (quantity <= 0)
            throw new ArgumentException("Quantity must be positive", nameof(quantity));

        var existingItem = _items.FirstOrDefault(item => item.Product.Id == product.Id);
        
        if (existingItem != null)
        {
            existingItem.Quantity += quantity;
        }
        else
        {
            _items.Add(new CartItem(product, quantity));
        }
    }

    /// <summary>
    /// Removes an item from the cart.
    /// </summary>
    /// <param name="productId">ID of the product to remove</param>
    /// <param name="quantity">Quantity to remove (if not specified, removes all)</param>
    /// <returns>True if item was removed, false if not found</returns>
    public bool RemoveItem(string productId, int? quantity = null)
    {
        var item = _items.FirstOrDefault(i => i.Product.Id == productId);
        if (item == null)
            return false;

        if (quantity.HasValue && quantity.Value > 0 && quantity.Value < item.Quantity)
        {
            item.Quantity -= quantity.Value;
        }
        else
        {
            _items.Remove(item);
        }

        return true;
    }

    /// <summary>
    /// Clears all items from the cart.
    /// </summary>
    public void Clear()
    {
        _items.Clear();
    }

    /// <summary>
    /// Calculates the subtotal before discounts and taxes.
    /// </summary>
    /// <returns>Subtotal amount</returns>
    public decimal GetSubtotal()
    {
        return _items.Sum(item => item.Product.Price * item.Quantity);
    }

    /// <summary>
    /// Applies a discount code to the cart.
    /// </summary>
    /// <param name="discountCode">Discount code to apply</param>
    /// <returns>Discount amount applied</returns>
    /// <exception cref="ArgumentException">Thrown when discount code is invalid</exception>
    public decimal ApplyDiscount(string discountCode)
    {
        if (string.IsNullOrWhiteSpace(discountCode))
            throw new ArgumentException("Discount code cannot be empty", nameof(discountCode));

        if (!_discountCodes.TryGetValue(discountCode.ToUpper(), out var discountPercentage))
            throw new ArgumentException("Invalid discount code", nameof(discountCode));

        return GetSubtotal() * discountPercentage;
    }

    /// <summary>
    /// Calculates the total amount including discounts and tax.
    /// </summary>
    /// <param name="discountCode">Optional discount code</param>
    /// <param name="taxRate">Tax rate (default 0.08 = 8%)</param>
    /// <returns>Total amount</returns>
    public decimal GetTotal(string? discountCode = null, decimal taxRate = 0.08m)
    {
        var subtotal = GetSubtotal();
        var discount = 0m;

        if (!string.IsNullOrWhiteSpace(discountCode))
        {
            try
            {
                discount = ApplyDiscount(discountCode);
            }
            catch (ArgumentException)
            {
                // Invalid discount code, ignore
            }
        }

        var afterDiscount = subtotal - discount;
        var tax = afterDiscount * taxRate;
        
        return afterDiscount + tax;
    }

    /// <summary>
    /// Gets cart summary information.
    /// </summary>
    /// <returns>Cart summary</returns>
    public CartSummary GetSummary()
    {
        var subtotal = GetSubtotal();
        return new CartSummary(
            ItemCount,
            subtotal,
            GetTotal(),
            _items.GroupBy(i => i.Product.Category)
                  .ToDictionary(g => g.Key, g => g.Sum(i => i.Quantity))
        );
    }
}

public class CartItem
{
    public Product Product { get; }
    public int Quantity { get; set; }

    public CartItem(Product product, int quantity)
    {
        Product = product ?? throw new ArgumentNullException(nameof(product));
        Quantity = quantity > 0 ? quantity : throw new ArgumentException("Quantity must be positive");
    }
}

public class Product
{
    public string Id { get; }
    public string Name { get; }
    public decimal Price { get; }
    public string Category { get; }

    public Product(string id, string name, decimal price, string category)
    {
        Id = string.IsNullOrWhiteSpace(id) ? throw new ArgumentException("Id cannot be empty") : id;
        Name = string.IsNullOrWhiteSpace(name) ? throw new ArgumentException("Name cannot be empty") : name;
        Price = price >= 0 ? price : throw new ArgumentException("Price cannot be negative");
        Category = category ?? "General";
    }
}

public record CartSummary(
    int TotalItems,
    decimal Subtotal,
    decimal Total,
    Dictionary<string, int> ItemsByCategory
);

using Library;

namespace Library.Tests;

/// <summary>
/// Test class for ShoppingCart functionality.
/// Students will implement all tests using AI assistance.
/// This class serves as a comprehensive exercise in test-driven development.
/// </summary>
public class ShoppingCartTests
{
    // TODO: Students should implement all tests for the ShoppingCart class using AI assistance.
    // Use the following structure as a guide:

    // Setup and Helper Methods:
    // - Create helper methods to generate test products
    // - Consider using fixtures or shared test data

    // Constructor and Basic Properties Tests:
    // - ShoppingCart_WhenCreated_IsEmpty
    // - ShoppingCart_WhenCreated_HasZeroItemCount
    // - ShoppingCart_EmptyCart_IsEmptyReturnsTrue

    // Add Item Tests:
    // - AddItem_WithValidProduct_AddsToCart
    // - AddItem_WithNullProduct_ThrowsArgumentNullException
    // - AddItem_WithZeroQuantity_ThrowsArgumentException
    // - AddItem_WithNegativeQuantity_ThrowsArgumentException
    // - AddItem_ExistingProduct_IncreasesQuantity
    // - AddItem_MultipleProducts_UpdatesItemCount

    // Remove Item Tests:
    // - RemoveItem_ExistingProduct_RemovesFromCart
    // - RemoveItem_NonExistentProduct_ReturnsFalse
    // - RemoveItem_PartialQuantity_ReducesQuantity
    // - RemoveItem_FullQuantity_RemovesCompletely
    // - RemoveItem_ExceedingQuantity_RemovesAll

    // Clear Tests:
    // - Clear_WithItems_RemovesAllItems
    // - Clear_EmptyCart_RemainsEmpty

    // Subtotal Calculation Tests:
    // - GetSubtotal_EmptyCart_ReturnsZero
    // - GetSubtotal_SingleItem_ReturnsCorrectAmount
    // - GetSubtotal_MultipleItems_ReturnsCorrectSum
    // - GetSubtotal_WithQuantities_CalculatesCorrectly

    // Discount Tests:
    // - ApplyDiscount_ValidCode_ReturnsDiscountAmount
    // - ApplyDiscount_InvalidCode_ThrowsArgumentException
    // - ApplyDiscount_EmptyCode_ThrowsArgumentException
    // - ApplyDiscount_CaseInsensitive_WorksCorrectly

    // Total Calculation Tests:
    // - GetTotal_EmptyCart_ReturnsZero
    // - GetTotal_WithoutDiscount_IncludesTax
    // - GetTotal_WithValidDiscount_AppliesDiscount
    // - GetTotal_WithInvalidDiscount_IgnoresDiscount
    // - GetTotal_CustomTaxRate_UsesCorrectRate

    // Summary Tests:
    // - GetSummary_EmptyCart_ReturnsCorrectSummary
    // - GetSummary_WithItems_ReturnsCorrectCounts
    // - GetSummary_GroupsByCategory_CorrectlyCategorizes

    // Integration Tests:
    // - CompleteShoppingScenario_AddRemoveCalculate_WorksCorrectly
    // - MultipleDiscountCodes_OnlyFirstValidApplies
    // - LargeCart_Performance_CompletesQuickly

    // Parameterized Tests:
    // - Use [Theory] and [InlineData] for testing multiple discount codes
    // - Use [Theory] for testing various tax rates
    // - Use [Theory] for testing different product combinations

    // Edge Case Tests:
    // - Products with zero price
    // - Very large quantities
    // - Decimal precision in calculations
    // - Products with same ID but different properties

    // Example test to get students started:
    [Fact]
    public void ShoppingCart_WhenCreated_IsEmpty()
    {
        // Arrange & Act
        var cart = new ShoppingCart();

        // Assert
        Assert.True(cart.IsEmpty);
        Assert.Equal(0, cart.ItemCount);
        Assert.Empty(cart.Items);
    }

    // Helper method example:
    private static Product CreateTestProduct(
        string id = "TEST001", 
        string name = "Test Product", 
        decimal price = 10.99m, 
        string category = "Electronics")
    {
        return new Product(id, name, price, category);
    }

    // Students should implement all other tests following the AAA pattern
    // and using appropriate xUnit attributes and assertions.
}

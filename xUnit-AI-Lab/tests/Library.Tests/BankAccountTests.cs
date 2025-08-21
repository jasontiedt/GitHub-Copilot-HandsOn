using Library;

namespace Library.Tests;

/// <summary>
/// Partial tests for BankAccount class.
/// Students will complete the missing tests using AI assistance.
/// </summary>
public class BankAccountTests
{
    [Fact]
    public void Constructor_WithValidParameters_CreatesAccount()
    {
        // Arrange
        string accountNumber = "123456789";
        string accountHolder = "John Doe";
        decimal initialBalance = 100m;

        // Act
        var account = new BankAccount(accountNumber, accountHolder, initialBalance);

        // Assert
        Assert.Equal(accountNumber, account.AccountNumber);
        Assert.Equal(accountHolder, account.AccountHolder);
        Assert.Equal(initialBalance, account.Balance);
        Assert.Single(account.Transactions);
        Assert.Equal(TransactionType.Deposit, account.Transactions[0].Type);
    }

    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData(null)]
    public void Constructor_WithInvalidAccountNumber_ThrowsArgumentException(string accountNumber)
    {
        // Arrange
        string accountHolder = "John Doe";

        // Act & Assert
        Assert.Throws<ArgumentException>(() => new BankAccount(accountNumber, accountHolder));
    }

    [Fact]
    public void Deposit_WithValidAmount_IncreasesBalance()
    {
        // Arrange
        var account = new BankAccount("123", "John Doe", 100m);
        decimal depositAmount = 50m;
        decimal expectedBalance = 150m;

        // Act
        account.Deposit(depositAmount);

        // Assert
        Assert.Equal(expectedBalance, account.Balance);
        Assert.Equal(2, account.Transactions.Count);
        Assert.Equal(TransactionType.Deposit, account.Transactions.Last().Type);
        Assert.Equal(depositAmount, account.Transactions.Last().Amount);
    }

    // TODO: Students should implement the following tests using AI assistance:

    // Constructor tests:
    // - Constructor_WithInvalidAccountHolder_ThrowsArgumentException
    // - Constructor_WithNegativeInitialBalance_ThrowsArgumentException
    // - Constructor_WithZeroInitialBalance_CreatesAccountWithNoTransactions

    // Deposit tests:
    // - Deposit_WithZeroAmount_ThrowsArgumentException
    // - Deposit_WithNegativeAmount_ThrowsArgumentException
    // - Deposit_WithLargeAmount_HandlesCorrectly
    // - Deposit_WithCustomDescription_UsesDescription

    // Withdrawal tests:
    // - Withdraw_WithValidAmount_DecreasesBalance
    // - Withdraw_WithInsufficientFunds_ThrowsInvalidOperationException
    // - Withdraw_WithZeroAmount_ThrowsArgumentException
    // - Withdraw_WithNegativeAmount_ThrowsArgumentException
    // - Withdraw_WithOverdraftAllowed_AllowsNegativeBalance
    // - Withdraw_ExceedingOverdraftLimit_ThrowsInvalidOperationException

    // Transfer tests:
    // - Transfer_BetweenAccounts_UpdatesBothBalances
    // - Transfer_ToNullAccount_ThrowsArgumentNullException
    // - Transfer_WithInsufficientFunds_ThrowsInvalidOperationException
    // - Transfer_CreatesCorrectTransactionDescriptions

    // Statement tests:
    // - GetStatement_WithDateRange_ReturnsCorrectTransactions
    // - GetStatement_WithNoTransactionsInRange_ReturnsEmptyCollection
    // - GetStatement_WithInvalidDateRange_HandlesCorrectly

    // Overdraft tests:
    // - OverdraftSettings_WhenChanged_AffectWithdrawalLimits
    // - Account_WithOverdraftDisabled_PreventsNegativeBalance
}

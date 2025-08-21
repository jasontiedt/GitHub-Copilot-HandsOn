namespace Library;

/// <summary>
/// Represents a bank account with basic operations.
/// </summary>
public class BankAccount
{
    private decimal _balance;
    private readonly List<Transaction> _transactions;
    
    public string AccountNumber { get; }
    public string AccountHolder { get; }
    public decimal Balance => _balance;
    public IReadOnlyList<Transaction> Transactions => _transactions.AsReadOnly();
    public bool IsOverdraftAllowed { get; set; }
    public decimal OverdraftLimit { get; set; } = 0;

    public BankAccount(string accountNumber, string accountHolder, decimal initialBalance = 0)
    {
        if (string.IsNullOrWhiteSpace(accountNumber))
            throw new ArgumentException("Account number cannot be empty", nameof(accountNumber));
        
        if (string.IsNullOrWhiteSpace(accountHolder))
            throw new ArgumentException("Account holder name cannot be empty", nameof(accountHolder));
        
        if (initialBalance < 0)
            throw new ArgumentException("Initial balance cannot be negative", nameof(initialBalance));

        AccountNumber = accountNumber;
        AccountHolder = accountHolder;
        _balance = initialBalance;
        _transactions = new List<Transaction>();
        
        if (initialBalance > 0)
        {
            _transactions.Add(new Transaction(
                DateTime.UtcNow, 
                TransactionType.Deposit, 
                initialBalance, 
                "Initial deposit"
            ));
        }
    }

    /// <summary>
    /// Deposits money into the account.
    /// </summary>
    /// <param name="amount">Amount to deposit</param>
    /// <param name="description">Optional description</param>
    /// <exception cref="ArgumentException">Thrown when amount is not positive</exception>
    public void Deposit(decimal amount, string description = "Deposit")
    {
        if (amount <= 0)
            throw new ArgumentException("Deposit amount must be positive", nameof(amount));

        _balance += amount;
        _transactions.Add(new Transaction(DateTime.UtcNow, TransactionType.Deposit, amount, description));
    }

    /// <summary>
    /// Withdraws money from the account.
    /// </summary>
    /// <param name="amount">Amount to withdraw</param>
    /// <param name="description">Optional description</param>
    /// <exception cref="ArgumentException">Thrown when amount is not positive</exception>
    /// <exception cref="InvalidOperationException">Thrown when insufficient funds</exception>
    public void Withdraw(decimal amount, string description = "Withdrawal")
    {
        if (amount <= 0)
            throw new ArgumentException("Withdrawal amount must be positive", nameof(amount));

        var availableBalance = _balance + (IsOverdraftAllowed ? OverdraftLimit : 0);
        
        if (amount > availableBalance)
            throw new InvalidOperationException("Insufficient funds for withdrawal");

        _balance -= amount;
        _transactions.Add(new Transaction(DateTime.UtcNow, TransactionType.Withdrawal, amount, description));
    }

    /// <summary>
    /// Transfers money to another account.
    /// </summary>
    /// <param name="targetAccount">Account to transfer to</param>
    /// <param name="amount">Amount to transfer</param>
    /// <param name="description">Optional description</param>
    public void Transfer(BankAccount targetAccount, decimal amount, string description = "Transfer")
    {
        if (targetAccount == null)
            throw new ArgumentNullException(nameof(targetAccount));

        Withdraw(amount, $"{description} to {targetAccount.AccountNumber}");
        targetAccount.Deposit(amount, $"{description} from {AccountNumber}");
    }

    /// <summary>
    /// Gets account statement for a date range.
    /// </summary>
    /// <param name="fromDate">Start date</param>
    /// <param name="toDate">End date</param>
    /// <returns>Transactions in the date range</returns>
    public IEnumerable<Transaction> GetStatement(DateTime fromDate, DateTime toDate)
    {
        return _transactions.Where(t => t.Date >= fromDate && t.Date <= toDate);
    }
}

public record Transaction(DateTime Date, TransactionType Type, decimal Amount, string Description);

public enum TransactionType
{
    Deposit,
    Withdrawal
}

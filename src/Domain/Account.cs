using System.Text;
using static Domain.Money;

namespace Domain;

public class Account
{
    private Money _balance;
    private readonly List<UserTransaction> _transactions;

    public Account()
    {
        _balance = None;
        _transactions = new List<UserTransaction>();
    }

    public void Deposit(int amount)
    {
        if (amount <= 0)
            throw new InvalidOperationException();

        var transaction = new Transaction(new Money(amount));

        if (!CanDeposit(transaction))
            return;
        
        Execute(transaction);
    }

    private bool CanDeposit(Transaction transaction)
    {
        return transaction.CanExecute();
    }

    private void Execute(Transaction transaction)
    {
        transaction.Execute();
        if (transaction.IsCompleted()) 
            UpdateBalance(transaction);
        
        var record = new UserTransaction(this, transaction, _balance);
        _transactions.Add(record);
    }

    private void UpdateBalance(Transaction transaction) => _balance += transaction.Amount;

    public string PrintStatement()
    {
        var statement = new StringBuilder();

        var header = "Date".PadRight(12) + "Amount".PadRight(8) + "Balance".PadRight(7);
        statement.Append(header);

        foreach (var transaction in _transactions)
        {
            statement.Append('\n');
            statement.Append(transaction.AsString());
        }

        return statement.ToString();
    }
}
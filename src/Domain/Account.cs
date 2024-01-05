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

    private bool CanDeposit(int amount) => amount > 0;

    public void Deposit(int amount)
    {
        if (!CanDeposit(amount))
            throw new InvalidOperationException();

        var transaction = new Transaction(new Money(amount));
        if (!transaction.CanExecute())
            return;
        
        transaction.Execute();
        if (transaction.IsCompleted())
            DepositAmount(transaction.Amount);
        
        var record = new UserTransaction(this, transaction, _balance);
        _transactions.Add(record);
    }

    private void DepositAmount(Money amount) => _balance += amount;

    private bool CanWithdraw(int amount)
    {
        if (amount <= 0)
            return false;

        if (_balance < amount)
            return false;

        return true;
    }

    public void Withdraw(int amount)
    {
        if (!CanWithdraw(amount))
            throw new InvalidOperationException();
        
        
    }

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
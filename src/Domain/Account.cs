using System.Text;
using Domain.Transactions;
using static Domain.Money;

namespace Domain;

public class Account
{
    private Money _balance = None;
    private readonly UserTransactions _userTransactions = new();

    private bool CanDeposit(int amount) => amount > 0;

    public void Deposit(int amount)
    {
        if (!CanDeposit(amount))
            throw new InvalidOperationException();

        var deposit = new Deposit(new Money(amount));
        if (!deposit.CanExecute(_balance))
            return;
        
        var oldBalance = new Money(_balance);
        var newBalance = deposit.Execute(_balance);
        
        if (deposit.IsCompleted())
            UpdateBalance(newBalance);
        
        var record = new UserTransaction(this, deposit, oldBalance, newBalance);
        _userTransactions.Add(record);
    }

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
        
        var withdraw = new Withdraw(new Money(amount));
        if (!withdraw.CanExecute(_balance))
            return;
        
        var oldBalance = new Money(_balance);
        var newBalance = withdraw.Execute(_balance);
        
        if (withdraw.IsCompleted())
            UpdateBalance(newBalance);
        
        var record = new UserTransaction(this, withdraw, oldBalance, newBalance);
        _userTransactions.Add(record);
    }
    
    private void UpdateBalance(Money balance) => _balance = balance;

    public string PrintStatement()
    {
        var statement = new StringBuilder();

        var header = "Date".PadRight(12) + "Amount".PadRight(8) + "Balance".PadRight(7);
        statement.Append(header);

        foreach (var transaction in _userTransactions.AsReadOnly)
        {
            statement.Append('\n');
            statement.Append(transaction.AsString());
        }

        return statement.ToString();
    }
}
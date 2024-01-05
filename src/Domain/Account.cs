using System.Text;
using Domain.Transactions;
using static Domain.Money;

namespace Domain;

public class Account
{
    private Money _balance = None;
    private readonly UserTransactions _userUserTransactions = new();

    private bool CanDeposit(int amount) => amount > 0;

    public void Deposit(int amount)
    {
        if (!CanDeposit(amount))
            throw new InvalidOperationException();

        var deposit = new Deposit(new Money(amount));
        var startBalance = new Money(_balance);
        
        if (!deposit.CanExecute())
            return;
        
        deposit.Execute();
        if (deposit.IsCompleted())
            DepositAmount(deposit.Amount);
        
        var record = new UserTransaction(this, deposit, startBalance, _balance);
        _userUserTransactions.Add(record);
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
        
        var withdraw = new Withdraw(new Money(amount));
        var startBalance = new Money(_balance);
        
        if (!withdraw.CanExecute())
            return;
        
        withdraw.Execute();
        if (withdraw.IsCompleted())
            WithdrawAmount(withdraw.Amount);
        
        var record = new UserTransaction(this, withdraw, startBalance, _balance);
        _userUserTransactions.Add(record);
    }
    
    private void WithdrawAmount(Money amount) => _balance -= amount;

    public string PrintStatement()
    {
        var statement = new StringBuilder();

        var header = "Date".PadRight(12) + "Amount".PadRight(8) + "Balance".PadRight(7);
        statement.Append(header);

        foreach (var transaction in _userUserTransactions.AsReadOnly)
        {
            statement.Append('\n');
            statement.Append(transaction.AsString());
        }

        return statement.ToString();
    }
}
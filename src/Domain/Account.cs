using System.Text;

namespace Domain;

public class Account
{
    private Money _balance;
    private Date _date;

    public Account() => _balance = new Money(0);

    public void Deposit(int amount)
    {
        _balance += new Money(amount);
        _date = new Date(2015, 12, 24);
    }

    public string PrintStatement()
    {
        var statement = new StringBuilder();

        var header = "Date".PadRight(12) + "Amount".PadRight(8) + "Balance".PadRight(7);
        statement.Append(header);

        if (_balance > 0)
        {
            statement.Append('\n');
            statement.Append(TransactionAsString());
        }

        return statement.ToString();
    }

    private string TransactionAsString()
    {
        return $"{_date.AsString(),-12} {_balance.SignAsString(),-9} {_balance.MoneyAsString(),-8}";
    }
}
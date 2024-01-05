using System.Text;

namespace Domain;

public class Account
{
    private int _balance;
    private DateOnly _date;
    
    public void Deposit(int amount)
    {
        _balance = amount;
        _date = new DateOnly(2015, 12, 24);
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
        return $"{DateAsString(_date), -12} {MoneySignAsString(_balance), -9} {MoneyAsString(_balance), -8}";
    }
    
    private string DateAsString(DateOnly date)
    {
        return $"{date.Day}.{date.Month}.{date.Year}";
    }

    private string MoneySignAsString(int money) => $"+{money}";

    private string MoneyAsString(int money) => $"{money}";
}
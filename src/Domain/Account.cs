using System.Text;

namespace Domain;

public class Account
{
    public string PrintStatement()
    {
        var statement = new StringBuilder();
        
        var header = "Date        Amount  Balance";
        statement.Append(header);
        
        return statement.ToString();
    }
}
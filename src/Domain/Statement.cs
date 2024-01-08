using System.Text;
using Domain.Transactions;

namespace Domain;

public class Statement
{
    private readonly StringBuilder _content;
    
    private Statement() => _content = new StringBuilder();

    private void AddNewLine() => _content.Append('\n');
    private void AddLine(string line) => _content.Append(line);

    public string AsString() => _content.ToString();
    
    public class Builder
    {
        private readonly Statement _statement = new();

        public Builder WithHeader()
        {
            var header = "Date".PadRight(12) + "Amount".PadRight(8) + "Balance".PadRight(7);
            _statement.AddLine(header);

            return this;
        }

        public Builder WithTransactions(UserTransactions transactions)
        {
            foreach (var transaction in transactions.AsReadOnly)
            {
                _statement.AddNewLine();
                _statement.AddLine(transaction.AsString());
            }
        
            return this;
        }

        public Statement Build() => _statement;
    }
}


using Domain;

var account = new Account();

account.Deposit(500);
account.Withdraw(500);

account.Deposit(500);
account.Withdraw(100);

account.Deposit(5000);
account.Withdraw(90);

account.Deposit(3000);
account.Deposit(5600);
account.Deposit(2100);

var statement = account.PrintStatement();
Console.WriteLine(statement);
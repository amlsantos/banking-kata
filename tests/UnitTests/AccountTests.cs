using Domain;
using FluentAssertions;
using Xunit;

namespace UnitTests;

public class AccountTests
{
    [Fact]
    public void PrintStatement_On0Transactions_ReturnsEmptyStatement()
    {
        // arrange
        var account = new Account();

        // act
        var result = account.PrintStatement();

        // assert
        result.Should().Be("Date        Amount  Balance");
    }

    [Fact]
    public void PrintStatement_On1Deposit_ReturnsStatementWith1Transaction()
    {
        // arrange
        var account = new Account();
        account.Deposit(500);

        // act
        var result = account.PrintStatement();

        // assert
        result.TrimEnd().Should().Be("Date        Amount  Balance\n24.12.2015   +500      500".TrimEnd());
    }

    [Fact]
    public void PrintStatement_On2Deposits_ReturnsStatementWith2Transactions()
    {
        // arrange
        var account = new Account();
        account.Deposit(500);
        account.Deposit(100);

        // act
        var result = account.PrintStatement();
        
        // assert
        result.TrimEnd().Should().Be("Date        Amount  Balance\n24.12.2015   +500      500\n24.12.2015   +100      600".TrimEnd());
    }
}
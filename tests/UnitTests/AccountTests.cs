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

    [Theory]
    [InlineData(0)]
    [InlineData(-100)]
    public void PrintStatement_On1InvalidDeposit_ReturnsException(int invalidAmount)
    {
        // arrange
        var account = new Account();

        // act
        var exception = () => account.Deposit(invalidAmount);

        // assert
        exception.Should().Throw<InvalidOperationException>();
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
        result.TrimEnd().Should().Be("Date        Amount  Balance\n24.12.2015   +500      500");
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
        result.Should().Be("Date        Amount  Balance\n24.12.2015   +500      500\n24.12.2015   +100      600");
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-100)]
    public void PrintStatement_OnInvalidWithdraw_ReturnsException(int invalidAmount)
    {
        // arrange
        var account = new Account();

        // act
        var exception = () => account.Withdraw(invalidAmount);

        // assert
        exception.Should().Throw<InvalidOperationException>();
    }
    
    [Fact]
    public void PrintStatement_On2Transactions_ReturnsStatementWith0Balance()
    {
        // arrange
        var account = new Account();
        account.Deposit(500);
        account.Withdraw(500);

        // act
        var result = account.PrintStatement();

        // assert
        result.Should().Be("Date        Amount  Balance\n24.12.2015   +500      500\n24.12.2015   -500        0");
    }
}
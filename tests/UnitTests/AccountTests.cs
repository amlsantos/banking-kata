using Domain;
using FluentAssertions;
using Xunit;

namespace UnitTests;

public class AccountTests
{
    private readonly Account _account = new();

    [Fact]
    public void PrintStatement_On0Transactions_ReturnsEmptyStatement()
    {
        // act
        var result = _account.PrintStatement();

        // assert
        result.Should().Be("Date        Amount  Balance");
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-100)]
    public void PrintStatement_On1InvalidDeposit_ReturnsException(int invalidAmount)
    {
        // act
        var exception = () => _account.Deposit(invalidAmount);

        // assert
        exception.Should().Throw<InvalidOperationException>();
    }

    [Fact]
    public void PrintStatement_On1Deposit_ReturnsStatementWith1Transaction()
    {
        // arrange
        _account.Deposit(500);

        // act
        var result = _account.PrintStatement().TrimEnd();

        // assert
        result.Should().Be("Date        Amount  Balance\n24.12.2015   +500      500");
    }

    [Fact]
    public void PrintStatement_On2Deposits_ReturnsStatementWith2Transactions()
    {
        // arrange
        _account.Deposit(500);
        _account.Deposit(100);

        // act
        var result = _account.PrintStatement();

        // assert
        result.Should().Be("Date        Amount  Balance\n24.12.2015   +500      500\n24.12.2015   +100      600");
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-100)]
    public void PrintStatement_OnInvalidWithdraw_ReturnsException(int invalidAmount)
    {
        // act
        var exception = () => _account.Withdraw(invalidAmount);

        // assert
        exception.Should().Throw<InvalidOperationException>();
    }
    
    [Fact]
    public void PrintStatement_On2Transactions_ReturnsStatementWith0Balance()
    {
        // arrange
        _account.Deposit(500);
        _account.Withdraw(500);

        // act
        var result = _account.PrintStatement();

        // assert
        result.Should().Be("Date        Amount  Balance\n24.12.2015   +500      500\n24.12.2015   -500      0");
    }
    
    [Fact]
    public void PrintStatement_OnWithdrawHigherThanDeposit_ReturnsException()
    {
        // arrange
        _account.Deposit(500);
        
        // act
        var exception = () => _account.Withdraw(600);
        
        // assert
        exception.Should().Throw<InvalidOperationException>();
    }
}
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
}
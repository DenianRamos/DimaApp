using Dima.Core.Enums;
using Dima.Core.Extensions;
using Dima.Core.Models;
using Xunit;

namespace Dima.Tests;

public class TransactionExtensionsTests
{
    [Fact]
    public void IsDeposit_ShouldReturnTrue_WhenTransactionTypeIsDeposit()
    {
        var transaction = new Transaction
        {
            Type = ETransactionType.Deposit,
            Amount = 150m
        };

        Assert.True(transaction.IsDeposit());
    }

    [Fact]
    public void IsDeposit_ShouldReturnFalse_WhenTransactionTypeIsWithdraw()
    {
        var transaction = new Transaction
        {
            Type = ETransactionType.Withdraw,
            Amount = 150m
        };

        Assert.False(transaction.IsDeposit());
    }

    [Fact]
    public void IsWithdraw_ShouldReturnTrue_WhenTransactionTypeIsWithdraw()
    {
        var transaction = new Transaction
        {
            Type = ETransactionType.Withdraw,
            Amount = 80m
        };

        Assert.True(transaction.IsWithdraw());
    }

    [Fact]
    public void GetSignedAmount_ShouldReturnPositiveValue_ForDeposits()
    {
        var transaction = new Transaction
        {
            Type = ETransactionType.Deposit,
            Amount = 320.45m
        };

        Assert.Equal(320.45m, transaction.GetSignedAmount());
    }

    [Fact]
    public void GetSignedAmount_ShouldReturnNegativeValue_ForWithdrawals()
    {
        var transaction = new Transaction
        {
            Type = ETransactionType.Withdraw,
            Amount = 320.45m
        };

        Assert.Equal(-320.45m, transaction.GetSignedAmount());
    }

    [Fact]
    public void IsFuturePayment_ShouldReturnTrue_WhenPaymentDateIsAfterReferenceDate()
    {
        var referenceDate = new DateTime(2026, 04, 26, 10, 0, 0, DateTimeKind.Utc);
        var transaction = new Transaction
        {
            PaidOrReceivedAt = referenceDate.AddDays(1)
        };

        Assert.True(transaction.IsFuturePayment(referenceDate));
    }
}

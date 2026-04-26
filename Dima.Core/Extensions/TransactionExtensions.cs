using Dima.Core.Enums;
using Dima.Core.Models;

namespace Dima.Core.Extensions;

public static class TransactionExtensions
{
    public static bool IsDeposit(this Transaction transaction)
        => transaction.Type == ETransactionType.Deposit;

    public static bool IsWithdraw(this Transaction transaction)
        => transaction.Type == ETransactionType.Withdraw;

    public static decimal GetSignedAmount(this Transaction transaction)
        => transaction.IsDeposit() ? transaction.Amount : -transaction.Amount;

    public static bool IsFuturePayment(this Transaction transaction, DateTime referenceDate)
        => transaction.PaidOrReceivedAt > referenceDate;
}

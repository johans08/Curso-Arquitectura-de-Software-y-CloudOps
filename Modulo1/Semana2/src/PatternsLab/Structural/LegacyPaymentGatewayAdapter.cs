using PatternsLab.Domain;

namespace PatternsLab.Structural;

public interface IPaymentProcessor
{
    void Pay(PaymentRequest request);
}

public sealed class LegacyPaymentGateway
{
    public void MakePayment(decimal value, string isoCurrency)
    {
        Console.WriteLine($"Legacy gateway paid {value} {isoCurrency}");
    }
}

public sealed class LegacyPaymentGatewayAdapter(LegacyPaymentGateway gateway) : IPaymentProcessor
{
    public void Pay(PaymentRequest request)
    {
        gateway.MakePayment(request.Amount, request.Currency);
    }
}

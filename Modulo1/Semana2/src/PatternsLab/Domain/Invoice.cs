namespace PatternsLab.Domain;

public sealed record InvoiceItem(string Description, int Quantity, decimal UnitPrice)
{
    public decimal Subtotal => Quantity * UnitPrice;
}

public sealed record Invoice(string CustomerName, IReadOnlyList<InvoiceItem> Items)
{
    public decimal Total => Items.Sum(i => i.Subtotal);
}

public sealed record PaymentRequest(decimal Amount, string Currency);

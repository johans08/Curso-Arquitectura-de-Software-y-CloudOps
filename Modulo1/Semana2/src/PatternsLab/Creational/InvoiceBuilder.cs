using PatternsLab.Domain;

namespace PatternsLab.Creational;

public sealed class InvoiceBuilder
{
    private string _customerName = "Unknown";
    private readonly List<InvoiceItem> _items = [];

    public InvoiceBuilder ForCustomer(string customerName)
    {
        _customerName = customerName;
        return this;
    }

    public InvoiceBuilder AddItem(string description, int quantity, decimal unitPrice)
    {
        _items.Add(new InvoiceItem(description, quantity, unitPrice));
        return this;
    }

    public Invoice Build()
    {
        if (_items.Count == 0)
            throw new InvalidOperationException("Invoice must have at least one item");

        return new Invoice(_customerName, _items);
    }
}

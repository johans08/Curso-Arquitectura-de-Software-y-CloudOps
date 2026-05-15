using PatternsLab.Creational;
using PatternsLab.Structural;
using PatternsLab.Decorators;
using PatternsLab.Domain;

Console.WriteLine("=== PatternsLab ===");

var factory = new NotificationFactory();
INotificationSender emailSender = factory.Create("email");
INotificationSender auditedSender = new AuditNotificationDecorator(emailSender);
auditedSender.Send("Welcome to the architecture course");

var invoice = new InvoiceBuilder()
    .ForCustomer("ACME Corp")
    .AddItem("Architecture workshop", 2, 150m)
    .AddItem("Cloud Ops workshop", 1, 200m)
    .Build();

Console.WriteLine($"Invoice for {invoice.CustomerName}: {invoice.Total:C}");

var externalGateway = new LegacyPaymentGateway();
var paymentProcessor = new LegacyPaymentGatewayAdapter(externalGateway);
paymentProcessor.Pay(new PaymentRequest(invoice.Total, "USD"));

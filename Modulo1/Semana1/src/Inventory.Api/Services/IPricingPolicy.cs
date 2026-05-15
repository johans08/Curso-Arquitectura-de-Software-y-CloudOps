using Inventory.Api.Models;

namespace Inventory.Api.Services;

public interface IPricingPolicy
{
    ProductPriceResponse Calculate(Product product);
}

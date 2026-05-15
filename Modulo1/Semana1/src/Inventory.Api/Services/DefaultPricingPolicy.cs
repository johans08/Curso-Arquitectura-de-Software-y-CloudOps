using Inventory.Api.Models;

namespace Inventory.Api.Services;

public sealed class DefaultPricingPolicy : IPricingPolicy
{
    public ProductPriceResponse Calculate(Product product)
    {
        var discount = product.IsPremium ? product.BasePrice * 0.10m : 0m;
        var finalPrice = product.BasePrice - discount;

        return new ProductPriceResponse(product.Id, product.BasePrice, discount, finalPrice);
    }
}

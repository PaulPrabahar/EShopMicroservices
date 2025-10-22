
namespace Basket.Api.Basket.GetBasket;

public record GetBasketQuery(string UserName):IQuery<GetBasketResult>;
public record GetBasketResult(ShoppingCart cart);

public class GetBasketHandler : IQueryHandler<GetBasketQuery, GetBasketResult>
{
    public Task<GetBasketResult> Handle(GetBasketQuery query, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}

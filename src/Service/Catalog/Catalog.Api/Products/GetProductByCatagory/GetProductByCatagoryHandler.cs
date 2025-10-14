using Marten.Linq.QueryHandlers;
using Microsoft.Extensions.Logging;

namespace Catalog.Api.Products.GetProductByCatagory;

public record GetProductByCatagoryQuery(string catagory):IQuery<GetProductByCatagoryResult>;
public record GetProductByCatagoryResult(IEnumerable<Product> Products);

public class GetProductByCatagoryQueryHandler(IDocumentSession session) : IQueryHandler<GetProductByCatagoryQuery, GetProductByCatagoryResult>
{
    public async Task<GetProductByCatagoryResult> Handle(GetProductByCatagoryQuery query, CancellationToken cancellationToken)
    {

        var product = await session
            .Query<Product>()
            .Where(p => p.Category
            .Contains(query.catagory))
            .ToListAsync();

        return new GetProductByCatagoryResult(product);
    }
}

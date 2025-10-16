
namespace Catalog.Api.Products.GetProducts;

public record GetProductsRequest(int? pageNumber = 1, int?pageSize = 10);
public record GetProductsResponce(IEnumerable<Product> Products);

public class GetProductsEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/product", async ([AsParameters] GetProductsRequest request, ISender sender) =>
        {
            var query = request.Adapt<GetProductsQuery>();
            var result = await sender.Send(query);
            var responce = result.Adapt<GetProductsResponce>();
            return Results.Ok(responce);
        })
            .WithName("Get Products")
            .Produces<GetProductsResponce>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Get Products")
            .WithDescription("Get Products");
    }
}

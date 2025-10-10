
using Catalog.Api.Products.GetProducts;

namespace Catalog.Api.Products.GetProductById;

//public record GetProductByIdRequest(Guid Id);
public record GetProductByIdResponse(Product Product);

public class GetProductByIdEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/product/{id}",async (Guid id, ISender sender) =>
        {
            var result = await sender.Send(new GetProductByIdQuery(id));
            var responce = result.Adapt<GetProductByIdResponse>();
            return Results.Ok(responce);
        })
            .WithName("GetProductsById")
            .Produces<GetProductsResponce>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Get Products By Id")
            .WithDescription("Get Products By Id");
    }
}

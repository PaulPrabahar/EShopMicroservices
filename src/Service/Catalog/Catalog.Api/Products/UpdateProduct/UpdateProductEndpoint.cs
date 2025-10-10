
using Catalog.Api.Products.GetProducts;

namespace Catalog.Api.Products.UpdateProduct;

public record UpdateProductRequest(Guid Id, string Name, List<string> Category, string Description, string ImageFile, decimal Price);
public record UpdateProductResponce(bool isSuccess);

public class UpdateProductEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPut("/product", async (UpdateProductRequest request, ISender sender) =>
        {
            var command = request.Adapt<UpdateProductCommand>();
            var result = await sender.Send(command);
            var responce = result.Adapt<UpdateProductResponce>();
            return Results.Ok(responce);
        })
            .WithName("UpdateProduct")
            .Produces<UpdateProductResponce>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("UpdateProduct")
            .WithDescription("UpdateProduct");
    }
}

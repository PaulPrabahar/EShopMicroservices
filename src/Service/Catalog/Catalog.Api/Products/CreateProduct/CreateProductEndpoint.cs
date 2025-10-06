using BuildingBlocks.CQRS;
namespace Catalog.Api.Products.CreateProduct;

public record CreateProductRequest(string Name, List<string> Category, string Description, string ImageFile, decimal Price);

public record CreateProductResponce(Guid Id);

public class CreateProductCommandEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/product", async (CreateProductRequest request, ISender sender) =>
        {
            var command = request.Adapt<CreateProductCommand>();
            var result = await sender.Send(command);
            var responce = result.Adapt<CreateProductResponce>();
            return Results.Created($"/product/{responce.Id}", responce);
        });
    }
}

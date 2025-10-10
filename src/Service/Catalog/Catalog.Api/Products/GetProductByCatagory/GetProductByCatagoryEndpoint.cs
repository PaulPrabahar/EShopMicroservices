
using Catalog.Api.Products.GetProducts;

namespace Catalog.Api.Products.GetProductByCatagory;

//public record GetProductByCatagoryRequest();
public record GetProductByCatagoryResponce(IEnumerable<Product> Products);

public class GetProductByCatagoryEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/product/catagory/{catagory}", async (string catagory, ISender sender) =>
        {
            var result = await sender.Send(new GetProductByCatagoryQuery(catagory));
            var responce = result.Adapt<GetProductByCatagoryResponce>();
            return Results.Ok(responce);
        })
            .WithName("GetProductsByCatagory")
            .Produces<GetProductsResponce>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Get Products By Catagory")
            .WithDescription("Get Products By Catagory");
    }
}

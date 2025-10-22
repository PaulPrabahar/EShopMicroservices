
namespace Basket.Api.Basket.DeleteBasket;

//public record DeleteBasketRequest();
public record DeleteBasketResponse();

public class DeleteBasketEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapDelete("/basket/{userName}", async (string userName,ISender sender) =>
        {
            var result = await sender.Send(new DeleteBasketCommand(userName));
            var responce = result.Adapt<DeleteBasketResponse>();
            return Results.Ok(responce);
        }).WithName("DeleteBasket")
            .Produces<DeleteBasketResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Delete Basket")
            .WithDescription("Delete Basket");
    }
}

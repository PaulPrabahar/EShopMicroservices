
using FluentValidation;

namespace Basket.Api.Basket.StoreBasket;
public record StoreBasketCommand(ShoppingCart Cart):ICommand<StoreBasketResult>;
public record StoreBasketResult(string userName);

public class StoreBasketCommandValidators : AbstractValidator<StoreBasketCommand>
{
    public StoreBasketCommandValidators()
    {
        RuleFor(x => x.Cart).NotNull().WithMessage("Cart can not be null");
        RuleFor(x => x.Cart.UserName).NotEmpty().WithMessage("UserName is required");
    }
}

public class StoreBasketHandler : ICommandHandler<StoreBasketCommand, StoreBasketResult>
{
    public Task<StoreBasketResult> Handle(StoreBasketCommand command, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}

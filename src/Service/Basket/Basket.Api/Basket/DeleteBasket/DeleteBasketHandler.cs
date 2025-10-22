
using FluentValidation;

namespace Basket.Api.Basket.DeleteBasket;

public record DeleteBasketCommand(string userName):ICommand<DeleteBasketResult>;
public record DeleteBasketResult(bool Success);

public class DeleteBasketCommandValidator : AbstractValidator<DeleteBasketCommand>
{
    public DeleteBasketCommandValidator()
    {
        RuleFor(x => x.userName).NotEmpty().WithMessage("Username is required");
    }
}
public class DeleteBasketHandler : ICommandHandler<DeleteBasketCommand, DeleteBasketResult>
{
    public Task<DeleteBasketResult> Handle(DeleteBasketCommand command, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}

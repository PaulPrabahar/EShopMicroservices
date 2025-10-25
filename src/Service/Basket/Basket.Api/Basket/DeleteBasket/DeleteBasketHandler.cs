
using Basket.Api.Data;
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
public class DeleteBasketHandler(IBasketRepository repository) : ICommandHandler<DeleteBasketCommand, DeleteBasketResult>
{
    public async Task<DeleteBasketResult> Handle(DeleteBasketCommand command, CancellationToken cancellationToken)
    {
        await repository.DeleteBasket(command.userName);
        return new DeleteBasketResult(true);
    }
}

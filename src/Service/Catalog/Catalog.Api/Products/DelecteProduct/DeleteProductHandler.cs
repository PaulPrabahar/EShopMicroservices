
using Catalog.Api.Products.UpdateProduct;
using FluentValidation;

namespace Catalog.Api.Products.DelecteProduct;

public record DeleteProductCommand(Guid Id):ICommand<DeleteProductResult>;
public record DeleteProductResult(bool isSuccess);

public class DeleteProductCommandValidator : AbstractValidator<DeleteProductCommand>
{
    public DeleteProductCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required");
    }
}

public class DeleteProductCommandHandler(IDocumentSession session, ILogger<DeleteProductCommandHandler> logger) : ICommandHandler<DeleteProductCommand, DeleteProductResult>
{
    public async Task<DeleteProductResult> Handle(DeleteProductCommand command, CancellationToken cancellationToken)
    {
        logger.LogInformation("DeleteProductCommand.Handle called with {@Command}", command);

        var product = await session.LoadAsync<Product>(command.Id);

        if (product is null)
            throw new ProductNotFoundException(command.Id);

        session.Delete<Product>(product);
        await session.SaveChangesAsync();

        return new DeleteProductResult(true);
    }
}

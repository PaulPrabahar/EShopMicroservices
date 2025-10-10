
using Catalog.Api.Products.CreateProduct;
using FluentValidation;

namespace Catalog.Api.Products.UpdateProduct;

public record UpdateProductCommand(Guid Id,string Name, List<string> Category, string Description, string ImageFile, decimal Price) :ICommand<UpdateProductResult>;
public record UpdateProductResult(bool isSuccess);

public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
{
    public UpdateProductCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required");
        RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");
        RuleFor(x => x.Price).GreaterThan(0).WithMessage("Price should be greater than 0");
    }
}

public class UpdateProductCommandHandler(IDocumentSession session, ILogger<UpdateProductCommandHandler> logger) : ICommandHandler<UpdateProductCommand, UpdateProductResult>
{
    public async Task<UpdateProductResult> Handle(UpdateProductCommand command, CancellationToken cancellationToken)
    {
        logger.LogInformation("GetProductsQueryHandler.Handle called with {@Command}", command);

        var product = await session.LoadAsync<Product>(command.Id, cancellationToken);

        if (product is null)
            throw new ProductNotFoundException();

        product.Name = command.Name;
        product.Category = command.Category;
        product.Description = command.Description;
        product.ImageFile = command.ImageFile;
        product.Price = command.Price;
        product.ImageFile = command.ImageFile;
        product.Price = command.Price;

        session.Update(product);
        await session.SaveChangesAsync();

        return new UpdateProductResult(true);
    }
}

using FluentValidation;

namespace Product.Api.ProductOperations.DeleteProduct
{
    public class DeleteProductCommandValidator : AbstractValidator<DeleteProductCommand>
    {
        public DeleteProductCommandValidator()
        {
            RuleFor(command => command.ProductId).GreaterThan(0);
        }
    }
}

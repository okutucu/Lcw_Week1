using FluentValidation;

namespace Product.Api.ProductOperations.UpdateProduct
{
    public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
    {
        public UpdateProductCommandValidator()
        {
            RuleFor(command => command.ProductId).GreaterThan(0);
            RuleFor(command => command.Model.CategoryId).GreaterThan(0);
            RuleFor(command => command.Model.ProductName).NotEmpty().MinimumLength(4);
        }
    }
}

using System;
using FluentValidation;

namespace Product.Api.ProductOperations.CreateProduct
{
    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator()
        {
            RuleFor(command => command.Model.CategoryId).GreaterThan(0);
            RuleFor(command => command.Model.Stock).GreaterThan(0);
            RuleFor(command => command.Model.CreatedDate.Date).NotEmpty().LessThan(DateTime.Now.Date);
            RuleFor(command => command.Model.ProductName).NotEmpty().MinimumLength(4);
        }
    }
}
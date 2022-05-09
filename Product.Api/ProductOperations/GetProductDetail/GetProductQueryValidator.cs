using FluentValidation;

namespace Product.Api.ProductOperations.GetProductDetail
{
    public class GetProductQueryValidator : AbstractValidator<GetProductDetailQuery>
    {
        public GetProductQueryValidator()
        {
            RuleFor(query => query.ProductId).GreaterThan(0);
        }
    }
}

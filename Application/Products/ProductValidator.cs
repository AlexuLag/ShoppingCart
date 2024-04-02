using Domain;
using FluentValidation;

namespace Application;

public class ProductValidator: AbstractValidator<Product>
{
    public ProductValidator()
    {
           RuleFor(x=>x.Name).NotEmpty();
    }
}

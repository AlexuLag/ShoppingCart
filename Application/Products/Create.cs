using Domain;
using FluentValidation;
using MediatR;
using Persistence;

namespace Application.Products;

public class Create
{
    public class Command : IRequest<Result <Unit>>
    {
        public Product Product  { get; set; }
    }

    public class CommandValidator : AbstractValidator <Command>
    {
        public CommandValidator()
        {
            RuleFor(x=> x.Product).SetValidator(new ProductValidator());
        }
    }

    public class Handler : IRequestHandler<Command, Result<Unit>>
    {
         public Handler(DataContext context)
        {
            _context = context;
        }

        private readonly DataContext _context;

        public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
        {            
            _context.Products.Add( request.Product);
            var Result  = await _context.SaveChangesAsync() >0;

            if(!Result) return Result<Unit>.Failure("Failed to create the product ");
            return  Result<Unit>.Success(Unit.Value);
          
        }
    }

}

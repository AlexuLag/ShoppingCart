using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Product;

public class Select 
{
        public class Query : IRequest <Result<List<Domain.Product>>>
        {

        }

    public class Handler : IRequestHandler<Query, Result<List<Domain.Product>>>
    {
        private readonly DataContext _context;

        public Handler(DataContext context)
        {
            _context = context;
        }
        public async Task<Result<List<Domain.Product>>> Handle(Query request, CancellationToken cancellationToken)
        {
            return  Result<List<Domain.Product>>.Success( await _context.Products.ToListAsync(cancellationToken));
        }
    }
}

using Domain;
using MediatR;
using Persistence;

namespace Application;

public class Create
{
    public class Command : IRequest<Result <Unit>>
    {
        public Product Product  { get; set; }
    }

    public class Handler : IRequestHandler<Command, Result<Unit>>
    {
         public Handler(DataContext context)
        {
            _context = context;
        }

        private readonly DataContext _context;

        public Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
        {            
            throw new NotImplementedException();
        }
    }

}

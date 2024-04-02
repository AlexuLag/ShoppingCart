using MediatR;
using Persistence;

namespace Application;

public class Delete
{
    public class  Command: IRequest<Result<Unit>>
    {
                public int Id {get; set;}
    }

    public class Handler : IRequestHandler<Command, Result<Unit>>
    {
         private readonly DataContext _Context ;
        public Handler(DataContext context)
        {
            _Context = context;
        }

        public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
        {
           var product = await _Context.Products.FindAsync(request.Id);
            if(product==null) return null;

            _Context.Remove(product);
            var result  = await _Context.SaveChangesAsync()>0;

            if(!result) return Result<Unit>.Failure("Fail to delete the product ");
            return Result<Unit>.Success(Unit.Value);
        }
    }


}

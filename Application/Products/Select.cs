using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Products;

public class Select
{
    public class Query : IRequest<Result<PagedList<ProductDto>>>
    {
        public PagingParams Params { get; set; }
    }

    public class Handler : IRequestHandler<Query, Result<PagedList<ProductDto>>>
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        

        public Handler(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<Result<PagedList<ProductDto>>> Handle(Query request, CancellationToken cancellationToken)
        {         
            var query  =  _context.Products
                    .ProjectTo<ProductDto>(_mapper.ConfigurationProvider).Where(p=>p.stock>0)
                    .AsQueryable();

            return Result<PagedList<ProductDto>>.Success(
                    await PagedList<ProductDto>.CreateAsync(query,
                                                            request.Params.pageNumber,
                                                            request.Params.PageSize)
            );
        }
    }
}

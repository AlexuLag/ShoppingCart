using System.Security.Cryptography.X509Certificates;
using Application.Orders;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application;

public class Select
{
    public class Query : IRequest<Result<List<OrderDto>>>
    {
        public int UserId { get; set; }
    }

    public class Handler : IRequestHandler<Query, Result<List<OrderDto>>>
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;


        public Handler(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }



        public async Task<Result<List<OrderDto>>> Handle(Query request, CancellationToken cancellationToken)
        {

            //TODO:  add a mapping profile to use a projection from the entities to the dtos
            var orders = await _context.Orders
                        .Where(or => or.Customer.Id == request.UserId)
                        .Include(p => p.OrderDetails)
                        .ThenInclude(p => p.Product)
                        .Include(p => p.Customer).ToListAsync();

            var orderDto = new List<OrderDto>();

            foreach (var item in orders)
            {
                var itemDto = new OrderDto();
                itemDto.id = item.Id;
                itemDto.UserId = item.Customer.Id;                
                itemDto.Items = new List<OrderDetailDto>();

                foreach (var det in item.OrderDetails)
                {
                    itemDto.Items.Add(new OrderDetailDto
                    {
                        Product = new ProductDto { Description = det.Product.Description, Code = det.Product.Code, UnitPrice= det.Product.UnitPrice },
                        Quantity = det.Quantity
                    });
                }
                orderDto.Add(itemDto);


            }


            return Result<List<OrderDto>>.Success(orderDto);


        }
    }
}

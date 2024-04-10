using AutoMapper;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Orders;

public class Create
{
    public class Command : IRequest<Result<Unit>>
    {
        public OrderDto Order { get; set; }
    }
    public class Handler : IRequestHandler<Command, Result<Unit>>
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public Handler(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        //TODO
        //  add a profile to mapp order dto vs orders in entities, to simplify code
        public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
        {

            //load order settings 
            var order = new Order
            {
                Customer = _context.Customers.Find(request.Order.UserId),
                Date = DateTime.Now,
                OrderDetails = new List<OrderDetail>()
            };



            request.Order.Items.ForEach(x =>
            {

                order.OrderDetails.Add(new OrderDetail
                {
                    Order = order,
                    Quantity = x.Quantity,
                    TotalPrice = x.Product.UnitPrice * x.Quantity,
                    Product = _context.Products.Find(x.Product.Id)
                });
                //updates stock status for each product on the order
                var productsWithStock = _context.ProductStock.Where(p => p.ProductId == x.Product.Id &&
                                                                         p.Status.Equals("S"))
                                                             .Take(Convert.ToInt32(x.Quantity));
                foreach (var item in productsWithStock)
                {
                    item.Status = "O";
                }
            });


            _context.Orders.Add(order);

            var Result = await _context.SaveChangesAsync() > 0;
            if (!Result) return Result<Unit>.Failure("Failed to create the Order ");
            return Result<Unit>.Success(Unit.Value);


        }
    }

}
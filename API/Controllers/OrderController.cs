using API.Controllers;
using Application;
using Application.Orders;
using Microsoft.AspNetCore.Mvc;
using Persistence;

namespace API;

public class OrderController:BaseApiController
{
    
    private readonly DataContext _context;

    public OrderController(DataContext context)
    {
        _context = context;
    }

     [HttpPost]
    public async Task<IActionResult>  CreateOrder( OrderDto order)
    {
        return HandleResult(await Mediator.Send(new Create.Command { Order= order }));     
    }

    
     [HttpGet("{id}")]
    public async Task<IActionResult>  Getorders( int id)
    {
      return HandleResult(await Mediator.Send(new Select.Query { UserId= id }));     
    }


}

using API.Controllers;
using Application;
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
    public async Task<IActionResult>  CreateOrder(List<CartDto> order){
        return Ok();
    }


}

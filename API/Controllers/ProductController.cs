using Application;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace API.Controllers;

public class ProductController: BaseApiController
{
    private readonly DataContext _context;

    public ProductController(DataContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<List<Product>>>  GetProducts()
    {
            return HandleResult(await Mediator.Send(new Application.Product.Select.Query()));
    }

}

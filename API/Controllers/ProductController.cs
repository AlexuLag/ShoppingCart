using Application;
using Application.Products;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Persistence;

namespace API.Controllers;

//base api controller allow to use common abstractions on each controller
public class ProductController: BaseApiController
{
    private readonly DataContext _context;

    public ProductController(DataContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<List<Product>>>  GetProducts([FromQuery] PagingParams param )
    {
            return HandlePageResult(await Mediator.Send(new Select.Query{Params = param} ));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Product>>  GetProduct(int id)
    {
             return HandleResult(await Mediator.Send(new Details.Query{ Id=id }));  
    }

    [HttpPost]
    public async Task<IActionResult>  CreateProduct(Product product)
    {
             return HandleResult(await Mediator.Send(new Create.Command { Product=product }));  
    }

      [HttpPut("{id}")]
    public async Task<IActionResult> EditProduct(int id,Product product)
    {
        product.Id = id;      
        return  HandleResult(  await Mediator.Send(new Edit.Command{Product  = product}));
    }

          [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProduct(int id)
    {       
        return   HandleResult( await Mediator.Send( new Delete.Command{ Id= id}));
    }



}

using System.Diagnostics;
using kiem_tra.Data;
using Microsoft.AspNetCore.Mvc;
using kiem_tra.Models;

namespace kiem_tra.Controllers;

public class ProductController : Controller
{
    private readonly ILogger<ProductController> _logger;

    public ProductController(ILogger<ProductController> logger)
    {
        _logger = logger;
    }

    public IActionResult All()
    {            
        var ProductList = LocalDataService.GetSanPhams();
        return View(ProductList);
    }
    
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    public IActionResult Search()
    {
        throw new NotImplementedException();
    }
}

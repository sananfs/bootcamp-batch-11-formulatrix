using Microsoft.AspNetCore.Mvc;

namespace MyWebAPI.Controllers;

public class ProductController : ControllerBase, IController<string>
{
    public IActionResult Create(string data)
    {
        throw new NotImplementedException();
    }

    public IActionResult Delete(int id)
    {
        throw new NotImplementedException();
    }

    public IActionResult GetAll()
    {
        throw new NotImplementedException();
    }

    public IActionResult GetById(int id)
    {
        throw new NotImplementedException();
    }

    public IActionResult Update(int id, string data)
    {
        throw new NotImplementedException();
    }

}

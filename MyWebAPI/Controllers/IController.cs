using Microsoft.AspNetCore.Mvc;

namespace MyWebAPI.Controllers;

public interface IController<T>
{
	IActionResult GetAll();
	IActionResult GetById(int id);
	IActionResult Create(T data);
	IActionResult Update(int id, T data);
	IActionResult Delete(int id);
}

using MyWebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using MyWebAPI.Databases;
using AutoMapper;
using MyWebAPI.DTOs;

namespace MyWebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoryController : ControllerBase, IController<CategoryDTO>
{	
	private IMapper _map;
	private DataContext _db;
	public CategoryController(DataContext db, IMapper map)
	{
		_db = db;
		_map = map;
	}
	[HttpPost]
	public IActionResult Create(CategoryDTO data)
	{
		Category category = _map.Map<Category>(data);
		_db.Categories.Add(category);
		_db.SaveChanges();
		return Ok();
	}
	[HttpGet]
	public IActionResult GetAll()
	{
		List<Category> categories = _db.Categories.ToList();
		List<CategoryDTO> categoriesDto = _map.Map<List<CategoryDTO>>(categories);
		return Ok(categories);
	}
	[HttpGet("{id}")]
	public IActionResult GetById(int id)
	{
		Category? category = _db.Categories.Find(id);
		if(category == null)
		{
			return NotFound();
		}
		return Ok(category);
	}
	[HttpPut]
	[Route("{id}")]
	public IActionResult Update(int id, CategoryDTO data)
	{
		Category? category = _db.Categories.Find(id);
		if(category == null)
		{
			return NotFound("Eweuh");
		}
		category.CategoryName = data.CategoryName;
		category.Description = data.Description;
		_db.Categories.Update(category);
		_db.SaveChanges();
		return Ok();
	}
	[HttpDelete("{id}")]
	public IActionResult Delete(int id)
	{
		Category? category = _db.Categories.Find(id);
		if(category is null)
		{
			return NotFound();
		}
		_db.Categories.Remove(category);
		_db.SaveChanges();
		return Ok();
	}
	// private static readonly	List<string> _myCategories = new() {"Sword", "Magic"};
	
	// [HttpGet]
	// public IActionResult Get()
	// {
	// 	return Ok(_myCategories);
	// }
	// [Route("{id}")]
	// [HttpGet]
	// public IActionResult Get(int id)
	// {
	// 	if(id > _myCategories.Count)
	// 	{
	// 		return NotFound("Eweuh");
	// 	}
	// 	return Ok(_myCategories[id]);
	// }
	// [HttpPost]
	// public IActionResult Creat(string data)
	// {
	// 	_myCategories.Add(data);
	// 	return Ok(_myCategories);
	// }
	// [Route("{id}")]
	// [HttpDelete]
	// public IActionResult Delete(int id)
	// {
	// 	if(id > _myCategories.Count)
	// 	{
	// 		return NotFound("Ora ono");
	// 	}
	// 	_myCategories.RemoveAt(id);
	// 	return Ok(_myCategories);
	// }
	// [HttpPut("{id}")]
	// public IActionResult Update(int id, string data)
	// {
	// 	if(id > _myCategories.Count)
	// 	{
	// 		return NotFound("Ora ono");
	// 	}
	// 	_myCategories[id] = data ;
	// 	return Ok(_myCategories);
	// }
}

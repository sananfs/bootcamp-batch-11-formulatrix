using Microsoft.AspNetCore.Mvc;
using MVC.Models;
using MVC.Databases;
namespace MVC.Controllers;

public class GenreController : Controller
{
	private readonly DataContext _db;
	public GenreController(DataContext db)
	{
		_db = db;
	}
	public IActionResult index()
	{
		List<Genre> genres = _db.Genres.ToList();
		
		return View(genres);
	}
	public IActionResult Create()
	{
		return View();
	}
	[HttpPost]
	public IActionResult Create(Genre genre)
	{
		bool status = _db.Genres.Any(gen => gen.GenreName == genre.GenreName);
		if (status)
		{
			TempData["CreateError"] = "Genre already exist";
			return RedirectToAction("index");
		}
		_db.Genres.Add(genre);
		_db.SaveChanges();
		TempData["CreateSuccess"] = "Create Genre success";
		return RedirectToAction("index");
	}
	public IActionResult Update(int? id)
	{
		if(id is null)
		{
			return NotFound();
		}
		Genre genre = _db.Genres.Find(id);
		if(genre is null)
		{
			return NotFound();
		}
		return View(genre);
	}
	[HttpPost]
	public IActionResult Update(Genre genre)
	{
		_db.Genres.Update(genre);
		_db.SaveChanges();
		TempData["UpdateSuccess"] = "Update Genre success";
		return RedirectToAction("index");
	}
	public IActionResult Delete(int? id)
	{
		if(id is null)
		{
			return NotFound();
		}
		Genre genre = _db.Genres.Find(id);
		if(genre is null)
		{
			return NotFound();
		}
		return View(genre);
	}
	[HttpPost]
	public IActionResult Delete(Genre genre)
	{
		_db.Genres.Remove(genre);
		_db.SaveChanges();
		return RedirectToAction("index");
	}
}

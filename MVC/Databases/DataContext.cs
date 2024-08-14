using Microsoft.EntityFrameworkCore;
using MVC.Models;
namespace MVC.Databases;

public class DataContext : DbContext
{
	public DataContext(DbContextOptions options) : base(options)
	{
		
	}
	
	public DbSet<Genre> Genres { get; set;}
	public DbSet<Game> Games { get; set;}
}

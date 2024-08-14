using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeFirst;

public class Product
{
	public int ProductId { get; set; }
	[MaxLength(20)]
	// [Column(TypeName = "nvarchar")]
	public string ProductName { get; set; }
	public string Description { get; set; }
	public int CategoryId { get; set; }
	public Category Category { get; set; }
	[DefaultValue(7000)]
	[Column(TypeName = "money")]
	public int UnitPrice { get; set; }
	// [Column(TypeName = "datetime")]
	public DateTime CreateTime { get; set; }
}

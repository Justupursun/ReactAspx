using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReactAspx.Models
{
	//FoodItem table
	public class ArtItem
	{
		[Key]
		public int Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public string Picture { get; set; }
		public decimal Price { get; set; }

		// [NotMapped]
		// public int Quantity { get; set; }

		public bool InStock	{ get; set; }

		[NotMapped]
		public DateTime HireFrom { get; set; }
		[NotMapped]
		public DateTime HireTill { get; set; }

		[NotMapped]
		public string Comment { get; set; }
	}

}
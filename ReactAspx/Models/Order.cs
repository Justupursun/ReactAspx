using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReactAspx.Models
{


	//Order table
	public class Order
	{
		[Key]
		public int Id { get; set; }
		public int StudentId { get; set; }
		public decimal TotalPaid { get; set; }
		public DateTime OrderDate { get; set; }
		
		public DateTime HireFrom { get; set; }
		public DateTime HireTill { get; set; }	
		
		public int Status { get; set; }
		public string Comment { get; set; }
	}
	 
}
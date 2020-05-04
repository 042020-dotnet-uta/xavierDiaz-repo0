using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlTypes;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace ProjectZero
{
	public class Product
	{
		private int _ProductID;// --- key
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int ProductID
		{
			get
			{
				return _ProductID;
			}
			set
			{
				_ProductID = value;
			}
		}
		private string _PName;// --- Product name
		[Required]
		public string PName
		{
			get
			{
				return _PName;
			}
			set
			{
				_PName = value;
			}
		}
		private float _PCost;// --- unit cost
		[Required]
		public float PCost
		{
			get
			{
				return _PCost;
			}
			set
			{
				_PCost = value;
			}
		}
		public Product()
		{
		}

		public void ShowAllProducts()
		{
			using (var db = new Pzero_DbContextClass())
			{
				var prods = db.Products
					.FromSqlRaw("SELECT * FROM Products")
					.ToList();
				foreach (var p in prods)
				{
					Console.WriteLine($"ProductID ({p.ProductID}) | Item Name ({p.PName}) | Unit Cost ({p.PCost})");
				}
			}
		}
	}
}

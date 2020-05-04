using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlTypes;
using System.Linq;
using System.Data.SqlTypes;
using Microsoft.EntityFrameworkCore;

namespace ProjectZero
{
	public class Order
	{
		private int _OrderID;// --- order key
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int OrderID
		{
			get
			{
				return _OrderID;
			}
			set
			{
				_OrderID = value;
			}
		}
		private int _StoreID;// --- store record
		[Required]
		public int StoreID
		{
			get
			{
				return _StoreID;
			}
			set
			{
				_StoreID = value;
			}
		}
		private int _CustomerID;// --- customer record
		[Required]
		public int CustomerID
		{
			get
			{
				return _CustomerID;
			}
			set
			{
				_CustomerID = value;
			}
		}
		private DateTime _SellTime;// --- time order was made
		[Required]
		public DateTime SellTime
		{
			get
			{
				return _SellTime;
			}
			set
			{
				_SellTime = value;
			}
		}
		private string _SoldItems;// --- string rep of what they bought
		[Required]
		public string SoldItems
		{
			get
			{
				return _SoldItems;
			}
			set
			{
				_SoldItems = value;
			}
		}
		public Order()
		{
		}

		public void ShowCustomerOrders()
		{
			using (var db = new Pzero_DbContextClass())
			{
				Console.Write("Enter CustomerID >> ");
				int TargetID = Convert.ToInt32(Console.ReadLine());
				var ords = db.Orders
					.FromSqlInterpolated($"SELECT * FROM Orders WHERE CustomerID = {TargetID}")
					.ToList();
				if (ords.Count() >= 1)
				{
					foreach (var O in ords)
					{
						Console.WriteLine($"StoreID ({O.StoreID}) | CustomerID ({O.CustomerID}) | SellTime ({O.SellTime}) | Sold Items ({O.SoldItems})");
					}
				}
				else
				{
					Console.WriteLine("Sorry couldn't find orders for that Customer");
				}
			}
		}
		public void ShowStoreOrders()
		{
			using (var db = new Pzero_DbContextClass())
			{
				Console.Write("Enter StoreID >> ");
				int TargetID = Convert.ToInt32(Console.ReadLine());
				var ords = db.Orders
					.FromSqlInterpolated($"SELECT * FROM Orders WHERE StoreID = {TargetID}")
					.ToList();
				if (ords.Count() >= 1)
				{
					foreach (var O in ords)
					{
						Console.WriteLine($"StoreID ({O.StoreID}) | CustomerID ({O.CustomerID}) | SellTime ({O.SellTime}) | Sold Items ({O.SoldItems})");
					}
				}
				else
				{
					Console.WriteLine("Sorry couldn't find orders for that store");
				}
			}
		}

		public void ShowSpecificOrder()
		{
			using (var db = new Pzero_DbContextClass())
			{
				Console.Write("Enter OrderID >> ");
				int TargetID = Convert.ToInt32(Console.ReadLine());
				var ords = db.Orders
					.FromSqlInterpolated($"SELECT * FROM Orders WHERE OrderID = {TargetID}")
					.ToList();
				if (ords.Count() >= 1)
				{
					foreach (var O in ords)
					{
						Console.WriteLine($"StoreID ({O.StoreID}) | CustomerID ({O.CustomerID}) | SellTime ({O.SellTime}) | Sold Items ({O.SoldItems})");
					}
				}
				else
				{
					Console.WriteLine("Sorry couldn't find that order");
				}
			}
		}
	}
}

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlTypes;
using System.Collections.Generic;
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
		/// <summary>
		/// Most complex method: used to create and place an order
		/// </summary>
		public void MakeOder()
		{
			//verify customer input and validity ----------------------------
			int cust;
			while (true)
			{
				Console.Write("Enter your customer ID >> ");
				string InP = Console.ReadLine();
				if (IsInt(InP) != -1)
					cust = IsInt(InP);
				else
					continue;
				Customer c = new Customer();
				if (c.IsValidCustomer(cust))
					break;
				else
				{
					Console.WriteLine("invalid customer ID try again");
					continue;
				}
			}
			//verify storeID input and validity ------------------------------
			int store;
			while (true)
			{
				Console.Write("Enter store ID to order from>> ");
				string InP = Console.ReadLine();
				if (IsInt(InP) != -1)
					store = IsInt(InP);
				else
					continue;
				Location l = new Location();
				if (l.IsValidLocation(store))
					break;
				else
				{
					Console.WriteLine("invalid store ID try again");
					continue;
				}
			}
			List<int[]> orders = new List<int[]>();
			//loop go get order ids and quantities
			while (true)
			{
				int PID;
				int quantity;
				Console.Write("Enter an item ID you want to order>> ");
				string InP = Console.ReadLine();
				int temp = IsInt(InP);
				if (temp != -1)
				{
					Product p = new Product();
					if(p.IsValidProduct(temp))
						PID = IsInt(InP);
					else
						continue;
				}
				else
					continue;
				bool repeat = false;// make sure it's not already in orders - otherwise updating may go past 0
				foreach(var ord in orders)
				{
					if (PID == ord[0])
						repeat = true;
				}
				if (repeat)
				{
					Console.Write("You already ordered that, want to add a different item? (y/n) >> ");
					int still = YesNo(Console.ReadLine());
					if (still == 1)
						continue;
					else
						break;
				}
				HowMany:
				Console.Write("How many do you want >> ");
				InP = Console.ReadLine();
				temp = IsInt(InP);
				if (temp != -1)
				{
					Location l = new Location();
					int max = l.MaxAvailable(PID, store);
					if (temp <= max && temp > 0)
						quantity = temp;
					else
					{
						if (temp <= 0)
						{
							Console.WriteLine($"you need to add more than 0 of the item");
							goto HowMany;
						}
						else
						{
							Console.WriteLine($"Sorry thats more than the store has, choose {max} or less");
							goto HowMany;
						}
					}
				}
				else
					goto HowMany;
				orders.Add(new int[] { PID, quantity });
				Console.Write("Want to add another item? (y/n) >> ");
				int ans = YesNo(Console.ReadLine());
				if (ans == 1)
					continue;
				else
					break;
			}
			foreach (var ord in orders)
			{
				Console.WriteLine($"Ordering {ord[1]} of item {ord[0]}");
			}
			// use variables cust, store and orders to place the order
			Console.WriteLine("now just add them");
			// insert orders
			foreach (var ord in orders)
			{
				int OID = (OrderSize() + 1);
				Product p = new Product();
				string prod = p.GetPName(ord[0]);
				using(var db = new Pzero_DbContextClass())
				{
					try
					{
						var PlaceOrds = db.Orders
							.FromSqlInterpolated($"INSERT INTO ORDERS VALUES({OID},{store},{cust},DATE('now'),{prod})")
							.ToList();
					}
					catch { }
				}
				Location l = new Location();// --- update inventory
				l.UpdateInventory(ord[0],ord[1]);				
			}
			Console.WriteLine("All done");
		}

		/// <summary>
		/// mini method for generating new key value
		/// </summary>
		public int OrderSize()
		{
			using (var db = new Pzero_DbContextClass())
			{
				var ords = db.Orders
					.FromSqlRaw("SELECT * FROM Orders")
					.ToList();
				return ords.Count;
			}
		}
		/// <summary>
		/// mini method to validate yes or no input
		/// </summary>
		public int YesNo(string ans)
		{
			while (true)
			{
				if (ans == "y")
					return 1;
				else if (ans == "n")
					return 2;
				else
				{
					Console.WriteLine("please enter y or n");
					continue;
				}
			}
		}
		/// <summary>
		/// input validation: make sure what's entered is an int
		/// exception handeling
		/// </summary>
		public int IsInt(string InP) 
		{
			int ID;
			try
			{
				ID = Convert.ToInt32(InP);
			}
			catch
			{
				Console.WriteLine("Not an integer try again");
				return -1;
			}
			return ID;

		}
		/// <summary>
		/// used to get order based by customer id 
		/// </summary>
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
		/// <summary>
		/// used to show orders by store id
		/// </summary>
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
		/// <summary>
		/// used to show details of a specific order
		/// </summary>
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

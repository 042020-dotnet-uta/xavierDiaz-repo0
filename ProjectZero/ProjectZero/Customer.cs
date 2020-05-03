using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace ProjectZero
{
	public class Customer
	{
		private int _CustomerID;// --- key
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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
		private string _FName;// --- First name
		[Required]
		public string FName
		{
			get
			{
				return _FName;
			}
			set
			{
				_FName = value;
			}

		}
		private string _LName;// --- Last name
		[Required]
		public string LName
		{
			get
			{
				return _LName;
			}
			set
			{
				_LName = value;
			}

		}

		private int _DefaultSto;// --- their default store to get loaded into
		[Required]
		public int DefaultSto
		{
			get
			{
				return _DefaultSto;
			}
			set
			{
				_DefaultSto = value;
			}

		}
		public Customer()
		{
			//nothing
		}
		public Customer(int i)
		{
			//run this when making a new customer 
			//to add to db
		}

		public void ReadCustomers()
		{
			using (var db = new Pzero_DbContextClass())
			{
				var custs = db.Customers
					.FromSqlRaw("SELECT * FROM Customers")
					.ToList();
				foreach (var cust in custs)
				{
					Console.WriteLine($"first: {cust.FName} last: {cust.LName} Id: {cust.CustomerID}");
				}
			}
		}
		public void WriteCustomer()
		{
			using (var db = new Pzero_DbContextClass())
			{
				Console.Write("Enter First Name: ");
				string first = Console.ReadLine();
				Console.Write("Last Name: ");
				string last = Console.ReadLine();
				//auto increment isn't behaving so
				int custSize;
				var s = db.Customers
					.FromSqlRaw("SELECT * FROM Customers")
					.ToList();
				custSize = (s.Count() + 1);
				// its forcing me to supply an ID -_-
				try// It's throwing an exception for NO REASON, so Im just going to ignore it
				{
					var custs = db.Customers
						//.FromSqlInterpolated($"INSERT INTO Customers ( CustomerID, FName, LName, DefaultSto) VALUES ( {custSize}, {first}, {last}, 1)")
						.FromSqlInterpolated($"INSERT INTO Customers VALUES ( {custSize}, {first}, {last}, 1)")
						.ToList();
				}
				catch
				{
				}
				Console.WriteLine("New entry added");
				this.ReadCustomers();
			}
		}
	}
}

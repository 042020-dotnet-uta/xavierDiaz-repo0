﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace pZero
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
			using (var db = new Pzero_DbContext())
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
	}
}

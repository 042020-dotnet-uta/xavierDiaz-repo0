using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlTypes;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace ProjectZero
{
	//Ideally this class would have things like address, hours, manager ID
	//But for now it basically only holds and adjusts inventory
	public class Location
	{
		private int _InventoryID;// --- key
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int InventoryID
		{
			get
			{
				return _InventoryID;
			}
			set
			{
				_InventoryID = value;
			}
		}
		private int _StoreID;// --- key
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
		private int _ItemID;// --- key
		[Required]
		public int ItemID
		{
			get
			{
				return _ItemID;
			}
			set
			{
				_ItemID = value;
			}
		}
		private int _Quantity;// --- key
		[Required]
		public int Quantity
		{
			get
			{
				return _Quantity;
			}
			set
			{
				_Quantity = value;
			}
		}
		public Location()
		{
		}

		public void UpdateInventory(int ID, int Q)
		{
			using (var db = new Pzero_DbContextClass())
			{
				try
				{
					var locs = db.Locations
						.FromSqlInterpolated($"UPDATE Locations SET Quantity = Quantity - {Q} WHERE InventoryID = {ID}")
						.ToList();
				}
				catch { }
			}
		}
		public void ShowInventory()
		{
			using (var db = new Pzero_DbContextClass())
			{
				var locs = db.Locations
					.FromSqlRaw("SELECT * FROM Locations")
					.ToList();
				foreach (var l in locs)
				{
					Console.WriteLine($"InventoryID {l.InventoryID} | StoreID {l.StoreID} | ItemID {l.ItemID} | Quantity Available {l.Quantity}");
				}
			}
		}
		public bool IsValidLocation(int i)//will stop order if the store doesn't exist
		{
			using (var db = new Pzero_DbContextClass())
			{
				var locs = db.Locations
					.FromSqlInterpolated($"SELECT * FROM Locations WHERE StoreID = {i}")
					.ToList();
				if (locs.Count > 0)
					return true;
				else
					return false;
			}
		}

		public int MaxAvailable(int ItemID, int StoreID)//returns how many of an Item there is to reject oversized orders
		{
			using (var db = new Pzero_DbContextClass())
			{
				var locs = db.Locations
					.FromSqlInterpolated($"SELECT * FROM Locations WHERE ItemID = {ItemID} AND Quantity >= 1 AND StoreID = {StoreID}")
					.ToList();
				if (locs.Count > 0)
				{
					foreach (var l in locs)//since using SUM there should only be one
						return l.Quantity;
				}
				else
					return -1;
			}
			return -1;
		}
	}
}

using Microsoft.EntityFrameworkCore;
using ProjectZero;
using System;
using System.Linq;
using Xunit;

namespace XUnitTestProjectZero
{
    public class UnitTestPZ
    {
        //private readonly Customer _sut;
        private readonly Product _sut;
        //private readonly Order _sut;
        //private readonly Location;
        public UnitTestPZ()
        {
            //_sut = new Product();
        }

        [Fact]
        public void NewProductTest()
        { 
            var options = new DbContextOptionsBuilder<Pzero_DbContextClass>()
                .UseInMemoryDatabase(databaseName: "test1")
                .Options;
            using (var db = new Pzero_DbContextClass(options))
            {
                db.Products.Add(new Product { ProductID = 10, PName = "mega stuffed", PCost = 4 });
                db.SaveChanges();
            }
            using (var db = new Pzero_DbContextClass(options))
            {
                Assert.Equal(1, db.Products.Count());
            }
        }

        [Fact]
        public void NewLocationTest()
        {
            var options = new DbContextOptionsBuilder<Pzero_DbContextClass>()
                .UseInMemoryDatabase(databaseName: "test2")
                .Options;
            using (var db = new Pzero_DbContextClass(options))
            {
                db.Locations.Add(new Location { InventoryID = 1, StoreID = 1, ItemID = 1, Quantity = 100});
                db.SaveChanges();
            }
            using (var db = new Pzero_DbContextClass(options))
            {
                Assert.Equal(1, db.Locations.Count());
            }
        }
        [Fact]
        public void NewOrderTest()
        {
            var options = new DbContextOptionsBuilder<Pzero_DbContextClass>()
                .UseInMemoryDatabase(databaseName: "test3")
                .Options;
            using (var db = new Pzero_DbContextClass(options))
            {
                db.Orders.Add(new Order { OrderID = 1, CustomerID = 1, StoreID = 1, SellTime = DateTime.Now ,SoldItems = "stuff"  });
                db.SaveChanges();
            }
            using (var db = new Pzero_DbContextClass(options))
            {
                Assert.Equal(1, db.Orders.Count());
            }
        }
        [Fact]
        public void NewCustomerTest()
        {
            var options = new DbContextOptionsBuilder<Pzero_DbContextClass>()
                .UseInMemoryDatabase(databaseName: "test4")
                .Options;
            using (var db = new Pzero_DbContextClass(options))
            {
                db.Customers.Add(new Customer { CustomerID = 1, DefaultSto = 1, FName = "Bob", LName = "Bobberson"});
                db.SaveChanges();
            }
            using (var db = new Pzero_DbContextClass(options))
            {
                Assert.Equal(1, db.Customers.Count());
            }
        }
        [Fact]
        public void GetAllCustomersTest()
        {
            var options = new DbContextOptionsBuilder<Pzero_DbContextClass>()
                .UseInMemoryDatabase(databaseName: "test5")
                .Options;
            using (var db = new Pzero_DbContextClass(options))
            {
                db.Customers.Add(new Customer { CustomerID = 1, DefaultSto = 1, FName = "Bob", LName = "Bobberson" });
                db.Customers.Add(new Customer { CustomerID = 2, DefaultSto = 1, FName = "Bill", LName = "Bobberson" });
                db.SaveChanges();
                var custs = db.Customers
                    .ToList();
                foreach (var c in custs)
                    Console.WriteLine($" {c.FName}{c.LName}");
            }
        }
        [Fact]
        public void GetAllProductTest()
        {
            var options = new DbContextOptionsBuilder<Pzero_DbContextClass>()
                .UseInMemoryDatabase(databaseName: "test6")
                .Options;
            using (var db = new Pzero_DbContextClass(options))
            {
                db.Products.Add(new Product { ProductID = 1, PCost = 1, PName = "foods" });
                db.Products.Add(new Product { ProductID = 2, PCost = 1, PName = "drinks" });
                db.SaveChanges();
                var prods = db.Products
                    .ToList();
                foreach (var p in prods)
                    Console.WriteLine($" {p.ProductID}{p.PCost}{p.PName}");
            }
        }
        [Fact]
        public void GetAllLocationTest()
        {
            var options = new DbContextOptionsBuilder<Pzero_DbContextClass>()
                .UseInMemoryDatabase(databaseName: "test7")
                .Options;
            using (var db = new Pzero_DbContextClass(options))
            {
                db.Locations.Add(new Location { StoreID = 1, InventoryID = 1, ItemID = 1, Quantity = 100 });
                db.Locations.Add(new Location { StoreID = 1, InventoryID = 2, ItemID = 1, Quantity = 100 });
                db.SaveChanges();
                var locs = db.Locations
                    .ToList();
                foreach (var l in locs)
                    Console.WriteLine($" {l.StoreID}{l.InventoryID}{l.ItemID}{l.Quantity}");
            }
        }
        [Fact]
        public void GetAllOrdersTest()
        {
            var options = new DbContextOptionsBuilder<Pzero_DbContextClass>()
                .UseInMemoryDatabase(databaseName: "test8")
                .Options;
            using (var db = new Pzero_DbContextClass(options))
            {
                db.Orders.Add(new Order { OrderID = 1, CustomerID = 1, StoreID = 1, SoldItems = "everything", SellTime = DateTime.Now});
                db.Orders.Add(new Order { OrderID = 2, CustomerID = 1, StoreID = 1, SoldItems = "Nothing", SellTime = DateTime.Now });
                db.SaveChanges();
                var ords = db.Orders
                    .ToList();
                foreach (var o in ords)
                    Console.WriteLine($" {o.OrderID}");
            }
        }
        [Fact]
        public void DeleteProductTest()
        {
            var options = new DbContextOptionsBuilder<Pzero_DbContextClass>()
                .UseInMemoryDatabase(databaseName: "test9")
                .Options;
            using (var db = new Pzero_DbContextClass(options))
            {
                db.Products.Add(new Product { ProductID = 10, PName = "mega stuffed", PCost = 4 });
                db.Products.Add(new Product { ProductID = 11, PName = "mega ultra stuffed", PCost = 5 });
                db.SaveChanges();
            }
            using (var db = new Pzero_DbContextClass(options))
            {
                db.Products.Remove(new Product { ProductID = 10, PName = "mega stuffed", PCost = 4 });
                db.SaveChanges();
                Assert.Equal(1, db.Products.Count());
            }
        }
        [Fact]
        public void DeleteCustomerTest()
        {
            var options = new DbContextOptionsBuilder<Pzero_DbContextClass>()
                .UseInMemoryDatabase(databaseName: "test10")
                .Options;
            using (var db = new Pzero_DbContextClass(options))
            {
                db.Customers.Add(new Customer { CustomerID = 1, FName = "test", LName = "testington", DefaultSto = 1 });
                db.Customers.Add(new Customer { CustomerID = 2, FName = "toast", LName = "toatington", DefaultSto = 1 });
                db.SaveChanges();
            }
            using (var db = new Pzero_DbContextClass(options))
            {
                db.Customers.Remove(new Customer { CustomerID = 1, FName = "test", LName = "testington", DefaultSto = 1 });
                db.SaveChanges();
                Assert.Equal(1, db.Customers.Count());
            }
        }
    }
}

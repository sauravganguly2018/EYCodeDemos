using EFDemoApp.DataAccess;
using EFDemoApp.Entities;
using Microsoft.EntityFrameworkCore;

namespace EFDemoApp.Presentation
{
    internal class Program
    {
        private static object exit;

        static void Main(string[] args)
        {

            NewMethod5();
            
        }

        public static void NewMethod5()
        {
            // add new product, new category and new supplier
            ProductsDbContext db = new ProductsDbContext();
            Category c = new Category { Name = "Laptop" };
            Product p = new Product { Name = "Macbook Air M2", Brand = "Apple", Price = 150000, Category = c };
            Supplier s = new Supplier { Name = "Saurav Ganguly", City = "Delhi", Address = "Bihar", Email = "saurav.ganguly@in.ey.com", Mobile = "8349398274" };
            db.Products.Add(p);
            db.Suppliers.Add(s);
            db.SaveChanges();
        }

        public static void NewMethod4()
        {
            // get all products and display pname and cname
            ProductsDbContext db = new ProductsDbContext();
            // egar loading - include
            // var allProducts = db.Products.Include(p=>p.Category).ToList();
            var allProducts = db.Products.ToList();
            // display

            foreach (var item in allProducts)
            {
                Console.WriteLine($"{item.Name}\t{item.Category.Name}");
            }
        }

        public static void NewMethod3()
        {
            // Add new product into existing category
            ProductsDbContext db = new ProductsDbContext();
            Category c = db.Categories.Find(1);
            Product p = new Product { Name = "IPhone X", Brand = "Apple", Price = 99000, Category=c};
            db.Products.Add(p);
            // db.Categories.Add(c)
            db.SaveChanges();
        }

        public static void NewMethod2()
        {
            // Add new product into new category
            ProductsDbContext db = new ProductsDbContext();
            Category c = new Category { Name = "Mobiles" };
            Product p = new Product { Name = "IPhone X", Brand = "Apple", Price = 90000, Category = c };
            db.Products.Add(p);
            // db.Categories.Add(c)
            db.SaveChanges();
        }

        public static void NewMethod1()
        {
            // Menu();

            // update brand with Samsung for pid 6
            ProductsDbContext db = new ProductsDbContext();
            var productToEdit = db.Products.Find(6);
            productToEdit.Brand = "Samsung";
            db.SaveChanges();
        }

        public static void Menu()
        {
            // accept product name and price and save into database
            while (true)
            {
                Console.WriteLine("Product Management System");
                Console.WriteLine("==========================");
                Console.WriteLine("1. Add New Product");
                Console.WriteLine("2. Display all Products");
                Console.WriteLine("3. Search Product");
                Console.WriteLine("4. Delete Product");
                Console.WriteLine("5. Edit Product");
                Console.WriteLine("6. Exit Application");

                Console.WriteLine("---------------------");
                Console.WriteLine("Enter your option [1-6] :");
                int choice;
                choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1: Add(); break;
                    case 2: DisplayAll(); break;
                    case 3: Search(); break;
                    case 4: Delete(); break;
                    case 5: Edit(); break;
                    case 6: break;
                    default:
                        Console.WriteLine("Invalid Option");
                        break;
                }
            }
        }

        private static void Edit()
        {
            ProductsDbContext db = new ProductsDbContext();
            Console.WriteLine("Enter ProductId to Edit:");
            int id = int.Parse(Console.ReadLine());
            var productToEdit = db.Products.Find(id);
            Console.WriteLine("--------------");
            Console.WriteLine(productToEdit.Name);
            Console.WriteLine(productToEdit.Price);
            Console.WriteLine("1. Enter new Price: "); ;
            int newprice = int.Parse(Console.ReadLine());
            productToEdit.Price = newprice;
            db.SaveChanges();
            Console.WriteLine("Modified...");
        }

        private static void Delete()
        {
            ProductsDbContext db = new ProductsDbContext();
            Console.WriteLine("Enter ProductId to delete:");
            int id= int.Parse(Console.ReadLine());
            var productToDel = db.Products.Find(id);
            db.Products.Remove(productToDel);
            db.SaveChanges();
            Console.WriteLine("Deleted");
        }

        private static void Search()
        {
            ProductsDbContext db= new ProductsDbContext();
            Console.WriteLine("Enter ProductId to search:");
            int id= int.Parse(Console.ReadLine());
            //var product = (from p in db.Products
            //              where p.ProductID == id
            //              select p).FirstOrDefault();

            var product = db.Products.Find(id);

            if(product == null)
            {
                Console.WriteLine("Product not found");
            }
            else
            {
                Console.WriteLine("Product ID\tName\tPrice");
                Console.WriteLine($"{product.ProductID}\t{product.Name}\t{product.Price}");
            }
        }

        private static void DisplayAll()
        {
            ProductsDbContext db = new ProductsDbContext();
            Console.WriteLine("Product ID\tName\tPrice");
            foreach(var item in db.Products)
            {
                Console.WriteLine($"{item.ProductID}\t{item.Name}\t{item.Price}");
            }
        }

        public static void Add()
        {
            Product p = new Product();
            Console.WriteLine("Enter Product Name :");
            p.Name = Console.ReadLine();
            Console.WriteLine("Enter Price :");
            p.Price = int.Parse(Console.ReadLine());
            ProductsDbContext db = new ProductsDbContext();
            db.Products.Add(p);
            db.SaveChanges();
        }

        private static void Save()
        {
            // Create new product and save into db - write pure oo code
            Product p1 = new Product { Name = "IPhone X", Price = 56000 };
            ProductsDbContext db = new ProductsDbContext();
            db.Products.Add(p1);
            db.SaveChanges();
            Console.WriteLine("done");
        }
    }

    
 }
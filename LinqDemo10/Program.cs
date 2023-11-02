using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LinqDemo10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 1. List all the products whose price is between 50k to 60 k
            var prodsBet56 = from p in ProductsDB.GetProducts()
                             where p.Price >= 50000 && p.Price <= 80000
                             select new
                             {
                                 PName = p.Name
                             };
            Console.WriteLine("1. products whose price is between 50k to 60k\n");
            foreach (var item in prodsBet56)
            {
                Console.WriteLine(item.PName);
            }

            // 2. Extract all products belongs to Laptops catagory
            var prodsLap=from p in ProductsDB.GetProducts()
                         where p.Catagory.Name=="Laptops"
                         select new
                         {
                             PName = p.Name
                         };
            Console.WriteLine("\n2. all products belongs to Laptops catagory\n");
            foreach (var item in prodsLap)
            {
                Console.WriteLine(item.PName);
            }

            // 3. Extract/Show Product Name and Category Name Only
            var prodsCatName = from p in ProductsDB.GetProducts()
                           select new
                           {
                               PName = p.Name,
                               PCategory=p.Catagory.Name
                           };
            Console.WriteLine("\n3. Show Product Name and Category Name Only\n");
            foreach (var item in prodsCatName)
            {
                Console.WriteLine(item.PName + " " + item.PCategory);
            }

            // 4. Show the costliest product name
            var prodCostliest =( from p in ProductsDB.GetProducts()
                                orderby p.Price descending
                               select p).First();
            Console.WriteLine("\n4. the costliest product name\n");
            Console.WriteLine(prodCostliest.Name);

            // 5. Show the cheepest product name and its price

            var prodCheapest = (from p in ProductsDB.GetProducts()
                                 orderby p.Price
                                 select p).First();
            Console.WriteLine("\n5. the cheapest product name with price\n");
            Console.WriteLine(prodCheapest.Name +" "+ prodCheapest.Price);

            // 6. Show the 2nd and 3rd product details
            var prods23 = (from p in ProductsDB.GetProducts()
                           select p).Skip(1).Take(2);
            Console.WriteLine("\n6. the 2nd and 3rd product details\n");
            foreach(var item in prods23)
            {
                Console.WriteLine(item.Name);
            }

            // 7. List all products in ascending order of their price
            var prodsDesc =from p in ProductsDB.GetProducts()
                           orderby p.Price
                           select p;
            Console.WriteLine("\n7. all products in ascending order of their price\n");
            foreach (var item in prodsDesc)
            {
                Console.WriteLine(item.Name);
            }

            // 8. Count the no. of products belong to Tablets
            var prodsTab = (from p in ProductsDB.GetProducts()
                           where p.Catagory.Name == "Tablets"
                           select p).Count();
            Console.WriteLine("\n8. total no. of products belong to Tablets\n");
            Console.WriteLine(prodsTab);

            // 9. Show which category has costly product
            var prodCatCostly = (from p in ProductsDB.GetProducts()
                            orderby p.Price descending
                            select p).First();
            Console.WriteLine("\n9. Catagory having costly product\n");
            Console.WriteLine(prodCatCostly.Catagory.Name);

            // 10. Show which catagory has less products
            var catLessProds = (from p in ProductsDB.GetProducts()
                               group p by p.Catagory.Name into grouped
                               orderby grouped.Count()
                               select grouped.Key).FirstOrDefault();
                               
                                
            Console.WriteLine("\n10. Catagory having less products\n");
            Console.WriteLine(catLessProds);

            // 11. Extract the Product Details based on the category and show as below 
            // Laptops

            //    Dell XPS 13
            //    HP 430
            // Mobiles
            //    IPhone 6
            //    Galaxy S6
            //Tablets
            //    IPad Pro



            var catWithProds = from p in ProductsDB.GetProducts()
                               group p by p.Catagory.Name into grouped
                               select new
                               {
                                   Catagory = grouped.Key,
                                   Products = grouped.ToList()
                               };
            Console.WriteLine("\n11. Product Details based on the catagory\n");
            foreach (var catagory in catWithProds)
            { 
                Console.WriteLine(catagory.Catagory);
                foreach (var item in catagory.Products)
                {
                    Console.WriteLine($"    {item.Name}");
                }
            }

            // 12. Extract the Product count based on the catagory and show as below
            // Laptops : 2
            // Mobiles : 2`
            // Tablets : 1

            var catCountProds = from p in ProductsDB.GetProducts()
                                group p by p.Catagory.Name into grouped
                                select new
                                {
                                    Catagory=grouped.Key,
                                    Count=grouped.Count()
                                };
            Console.WriteLine("\n12. Product count based on the catagory\n");
            foreach (var item in catCountProds)
            {
                Console.WriteLine(item.Catagory + " : " + item.Count);
            }
        }

        class ProductsDB
        {
            public static List<Product> GetProducts()
            {
                Catagory cat1 = new Catagory { CatagoryID = 101, Name = "Laptops" };
                Catagory cat2 = new Catagory { CatagoryID = 201, Name = "Mobiles" };
                Catagory cat3 = new Catagory { CatagoryID = 301, Name = "Tablets" };

                Product p1 = new Product { ProductID = 1, Name = "Dell XPS 13", Catagory = cat1, Price = 90000 };
                Product p2 = new Product { ProductID = 2, Name = "HP 430", Catagory = cat1, Price = 50000 };
                Product p3 = new Product { ProductID = 3, Name = "IPhone 6", Catagory = cat2, Price = 80000 };
                Product p4 = new Product { ProductID = 4, Name = "Galaxy S6", Catagory = cat2, Price = 74000 };
                Product p5 = new Product { ProductID = 5, Name = "IPad Pro", Catagory = cat3, Price = 44000 };

                cat1.Products.Add(p1);
                cat1.Products.Add(p2);
                cat2.Products.Add(p3);
                cat2.Products.Add(p4);
                cat3.Products.Add(p5);

                List<Product> products = new List<Product>();
                products.Add(p1);
                products.Add(p2);
                products.Add(p3);
                products.Add(p4);
                products.Add(p5);

                return products;
            }
        }
        class Product
        {
            public int ProductID { get; set; }
            public string Name { get; set; }
            public int Price { get; set; }
            public Catagory Catagory { get; set; }
        }
        class Catagory
        {
            public int CatagoryID { get; set; }
            public string Name { get; set; }
            public List<Product> Products = new List<Product>();
        }
    }
}
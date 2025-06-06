using System;
using DALLayer;
using DALLayer.Models;

namespace ConsoleApp
{
    public class Program
    {
        static QuickStartDbContext quickStartDbContext;
        static QuickStartRepository quickStartRepository;
        static Program()
        {
            quickStartDbContext = new QuickStartDbContext();
            quickStartRepository = new QuickStartRepository(quickStartDbContext);
        }
        static void Main(string[] args)
        {
            //var categories = quickStartRepository.GetAllCategories();
            //foreach (var category in categories)
            //{
            //    Console.WriteLine("{0}\t\t{1}",category.CategoryId,category.CategoryName);
            //}

            //var products = quickStartRepository.GetProductsOnCategoryId(2);
            //var products = quickStartRepository.FilterProductsUsingLike("S");
            //foreach (var product in products)
            //{
            //    Console.WriteLine("{0}\t\t{1}\t\t{2}", product.ProductId,product.ProductName,product.Price);
            //}

            //var users = quickStartRepository.GetAllUsers();
            //foreach (var user in users)
            //{
            //    Console.WriteLine("{0}\t\t{1}\t\t{2}", user.EmailId, user.Gender, user.Address);
            //}

            //bool status = quickStartRepository.AddCategory("Sports");
            //Console.WriteLine(status);

            //bool status = quickStartRepository.UpdateCategory(17, "Books");
            //Console.WriteLine(status);

            //bool status = quickStartRepository.UpdateProduct("P016", 800);
            //Console.WriteLine(status);

            //bool status = quickStartRepository.DeleteCategory(17);
            //Console.WriteLine(status);

            //Product product = new Product
            //{
            //    ProductName = "Basketball",
            //    CategoryId = 6,
            //    Price = 1500,
            //    QuantityAvailable = 10
            //};

            //int returnValue = quickStartRepository.AddProductUsingStoredProcedure(product,out string ProductId);
            //if (returnValue > 0)
            //{
            //    Console.WriteLine("Product added successfully with ID: " + ProductId);
            //}
            //else
            //{
            //    Console.WriteLine("Failed to add product.");
            //}

            //string ProductId = quickStartRepository.GetProductIdUsingSVF();
            //if (!string.IsNullOrEmpty(ProductId))
            //{
            //    Console.WriteLine("Product ID: " + ProductId);
            //}
            //else
            //{
            //    Console.WriteLine("Failed to retrieve Product ID.");
            //}
        }
    }
}



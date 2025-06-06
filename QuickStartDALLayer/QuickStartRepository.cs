using QuickStartDALLayer.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickStartDALLayer
{
    public class QuickStartRepository
    {
        private QuickStartDbContext QuickStartDbContext;
        public QuickStartRepository(QuickStartDbContext quickStartDbContext)
        {
            QuickStartDbContext = quickStartDbContext;
        }

        public List<Category> GetAllCategories()
        {
            List<Category> categories = new List<Category>();
            try
            {
                categories = QuickStartDbContext.Categories.OrderBy(c => c.CategoryId).ToList();
            }
            catch (Exception ex)
            {
                categories = null;
            }

            return categories;
        }

        public List<Product> GetAllProducts()
        {
            List<Product> products = new List<Product>();
            try
            {
                products = QuickStartDbContext.Products.ToList();
            }
            catch (Exception ex)
            {
                products = null;
            }
            return products;
        }

        public List<Product> GetProductsOnCategoryId(int categoryId)
        {
            List<Product> products = new List<Product>();

            try
            {
                products = QuickStartDbContext.Products.Where(p => p.CategoryId == categoryId).ToList();
            }
            catch (Exception ex)
            {
                products = null;
            }

            return products;
        }

        public Product GetProductByProductId(string productId)
        {
            Product product = new Product();

            try
            {
                product = QuickStartDbContext.Products.Where(p => p.ProductId == productId).FirstOrDefault();
            }
            catch(Exception ex)
            {
                product = null;
            }

            return product;
        }

        public List<Product> FilterProductsUsingLike(string searchString)
        {
            List<Product> products = new List<Product>();
            try
            {
                products = QuickStartDbContext.Products.Where(p => p.ProductName.Contains(searchString)).ToList();
            }
            catch (Exception ex)
            {
                products = null;
            }
            return products;
        }

        public List<User> GetAllUsers()
        {
            List<User> users = new List<User>();
            try
            {
                users = QuickStartDbContext.Users.ToList();
            }
            catch (Exception ex)
            {
                users = null;
            }
            return users;
        }

        public bool AddCategory(string categoryName)
        {
            bool status = false;
            Category category = new Category();
            category.CategoryName = categoryName;
            try
            {
                QuickStartDbContext.Categories.Add(category);
                QuickStartDbContext.SaveChanges();
                status = true;
            }
            catch (Exception ex)
            {
                status = false;
            }
            return status;
        }

        public bool UpdateCategory(int categoryId, string categoryName)
        {
            bool status = false;
            try
            {
                var category = QuickStartDbContext.Categories.Find(categoryId);
                if (category != null)
                {
                    category.CategoryName = categoryName;
                    QuickStartDbContext.SaveChanges();
                    status = true;
                }
                else
                {
                    status = false;
                }
            }
            catch (Exception ex)
            {
                status = false;
            }
            return status;
        }

        public bool UpdateProduct(string productId, decimal price)
        {
            bool status = false;
            try
            {
                var product = QuickStartDbContext.Products.Find(productId);
                if (product != null)
                {
                    product.Price = price;
                    QuickStartDbContext.SaveChanges();
                    status = true;
                }
                else
                {
                    status = false;
                }
            }
            catch (Exception ex)
            {
                status = false;
            }
            return status;
        }

        public bool DeleteCategory(int categoryId)
        {
            bool status = false;
            try
            {
                var category = QuickStartDbContext.Categories.Find(categoryId);
                if (category != null)
                {
                    QuickStartDbContext.Categories.Remove(category);
                    QuickStartDbContext.SaveChanges();
                    status = true;
                }
                else
                {
                    status = false;
                }

            }
            catch (Exception ex)
            {
                status = false;
            }
            return status;
        }

        public int AddProductUsingStoredProcedure(Product product, out string ProductId)
        {
            int returnResult = 0;
            int noOfRowsAffected = 0;

            product.ProductId = GetProductIdUsingSVF();
            
            SqlParameter prmProductId = new SqlParameter("@ProductId", product.ProductId);
            SqlParameter prmProductName = new SqlParameter("@ProductName", product.ProductName);
            SqlParameter prmCategoryId = new SqlParameter("@CategoryId", product.CategoryId);
            SqlParameter prmPrice = new SqlParameter("@Price", product.Price);
            SqlParameter prmQuantityAvailable = new SqlParameter("@QuantityAvailable", product.QuantityAvailable);
            SqlParameter prmReturnValue = new SqlParameter("@ReturnValue", System.Data.SqlDbType.Int);
            prmReturnValue.Direction = System.Data.ParameterDirection.Output;

            try
            {
                noOfRowsAffected = QuickStartDbContext.Database.ExecuteSqlRaw("EXEC @ReturnValue = usp_AddProduct @ProductId, @ProductName, @CategoryId, @Price, @QuantityAvailable",
                    prmReturnValue, prmProductId, prmProductName, prmCategoryId, prmPrice, prmQuantityAvailable);
                
                returnResult = Convert.ToInt32(prmReturnValue.Value);
                ProductId = prmProductId.Value.ToString();
            }
            catch (Exception ex)
            {
                returnResult = -99;
                noOfRowsAffected = 0;
                ProductId = null;
            }
            return returnResult;
        }

        public string GetProductIdUsingSVF()
        {
            string ProductId = string.Empty;
            try
            {
                ProductId = (from s in QuickStartDbContext.Products
                             select QuickStartDbContext.ufn_GenerateProductId()).FirstOrDefault() ;
            }
            catch (Exception ex)
            {
                ProductId = string.Empty;
            }
            return ProductId;
        }

    }
}

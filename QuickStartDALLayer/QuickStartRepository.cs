﻿using QuickStartDALLayer.Models;
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

        public List<User> GetAllUsers()
        {
            List<User> users = new List<User>();
            try
            {
                users = QuickStartDbContext.Users.OrderBy(c => c.EmailId).ToList();
                foreach(var user in users)
                {
                    user.UserPassword = "";
                }
            }
            catch (Exception ex)
            {
                users = null;
            }
            return users;
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

        public List<PurchaseDetail> GetAllPurchaseDetails()
        {
            List<PurchaseDetail> purchaseDetails = new List<PurchaseDetail>();
            try
            {
                purchaseDetails = QuickStartDbContext.PurchaseDetails.ToList();
            }
            catch (Exception ex)
            {
                purchaseDetails = null;
            }
            return purchaseDetails;
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

        public Product GetProductByProductId(string productId)
        {
            Product product = new Product();

            try
            {
                product = QuickStartDbContext.Products.Where(p => p.ProductId == productId).FirstOrDefault();
            }
            catch (Exception ex)
            {
                product = null;
            }

            return product;
        }

        public User GetUserByEmailId(string emailId)
        {
            User user = new User();
            try
            {
                user = QuickStartDbContext.Users.Where(u => u.EmailId == emailId).FirstOrDefault();
                user.UserPassword = Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(user.UserPassword)); //Encoding
                //user.UserPassword = Encoding.UTF8.GetString(Convert.FromBase64String(user.UserPassword)); //Decoding
            }
            catch (Exception ex)
            {
                user = null;
            }
            return user;
        }

        public Category GetCategoryByCategoryId(int categoryId)
        {
            Category category = new Category();
            try
            {
                category = QuickStartDbContext.Categories.Where(c => c.CategoryId == categoryId).FirstOrDefault();
            }
            catch (Exception ex)
            {
                category = null;
            }
            return category;
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

        public int RegisterUserUsingStoredProcedure(User user) { 
            int returnResult = 0;
            int noOfRowsAffected = 0;
            SqlParameter prmEmailId = new SqlParameter("@EmailId", user.EmailId);
            SqlParameter prmUserPassword = new SqlParameter("@UserPassword", user.UserPassword);
            SqlParameter prmGender = new SqlParameter("@Gender", user.Gender);
            SqlParameter prmDateOfBirth = new SqlParameter("@DateOfBirth",user.DateOfBirth);
            SqlParameter prmAddress = new SqlParameter("@Address", user.Address);
            SqlParameter prmReturnValue = new SqlParameter("@ReturnValue", System.Data.SqlDbType.Int);
            prmReturnValue.Direction = System.Data.ParameterDirection.Output;

            try
            {
                noOfRowsAffected = QuickStartDbContext.Database.ExecuteSqlRaw("EXEC @ReturnValue = usp_RegisterUser @EmailId, @UserPassword, @Gender, @DateOfBirth, @Address",
                    prmReturnValue, prmEmailId, prmUserPassword, prmGender, prmDateOfBirth, prmAddress);

                returnResult = Convert.ToInt32(prmReturnValue.Value);
            }
            catch (Exception ex)
            {
                returnResult = -99;
                noOfRowsAffected = 0;
            }
            return returnResult;
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

        public bool UpdateUser(string emailId, string address)
        {
            bool status = false;
            try
            {
                var user = QuickStartDbContext.Users.Find(emailId);
                if (user != null)
                {
                    user.Address = address;
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

        public bool DeleteProduct(string productId)
        {
            bool status = false;
            try
            {
                var product = QuickStartDbContext.Products.Find(productId);
                if (product != null)
                {
                    QuickStartDbContext.Products.Remove(product);
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

        public bool DeleteUser(string emailId)
        {
            bool status = false;
            try
            {
                var user = QuickStartDbContext.Users.Find(emailId);
                if (user != null)
                {
                    QuickStartDbContext.Users.Remove(user);
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

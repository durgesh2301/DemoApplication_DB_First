using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuickStartDALLayer;
using QuickStartDALLayer.Models;

namespace QuickStartServiceLayer.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : Controller
    {
        QuickStartRepository _quickStartRepository;
        private readonly IMapper _mapper;
        public ProductController(QuickStartRepository quickStartRepository, IMapper mapper)
        {
            _quickStartRepository = quickStartRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public JsonResult GetAllCategories()
        {
            List<Category> categories = new List<Category>();
            try
            {
                categories = _quickStartRepository.GetAllCategories();
            }
            catch (Exception ex)
            {
                categories = null;
            }
            return Json(categories);
        }

        [HttpGet]
        public JsonResult GetAllUsers()
        {
            List<User> users = new List<User>();
            try
            {
                users = _quickStartRepository.GetAllUsers();
            }
            catch (Exception ex)
            {
                users = null;
            }
            return Json(users);
        }

        [HttpGet]
        public JsonResult GetAllProducts()
        {
            List<Product> products = new List<Product>();
            try
            {
                products = _quickStartRepository.GetAllProducts();
            }
            catch (Exception ex)
            {
                products = null;
            }
            return Json(products);
        }

        //[HttpGet("GetProductsOnCategoryId/{categoryId}")]
        [HttpGet]
        public JsonResult GetProductsOnCategoryId(int categoryId)
        {
            List<Product> products = new List<Product>();
            try
            {
                products = _quickStartRepository.GetProductsOnCategoryId(categoryId);
            }
            catch (Exception ex)
            {
                products = null;
            }
            return Json(products);
        }

        [HttpGet]
        public JsonResult FilterProductsUsingLike(string searchString)
        {
            List<Product> products = new List<Product>();
            try
            {
                products = _quickStartRepository.FilterProductsUsingLike(searchString);
            }
            catch (Exception ex)
            {
                products = null;
            }
            return Json(products);
        }

        [HttpGet]
        public JsonResult GetProductByProductId(string productId)
        {
            Product product = new Product();
            try
            {
                product = _quickStartRepository.GetProductByProductId(productId);
            }
            catch (Exception ex)
            {
                product = null;
            }
            return Json(product);
        }

        [HttpGet]
        public JsonResult GetUserByEmailId(string emailId)
        {
            User user = new User();
            try
            {
                user = _quickStartRepository.GetUserByEmailId(emailId);
            }
            catch (Exception ex)
            {
                user = null;
            }
            return Json(user);
        }

        [HttpGet]
        public JsonResult GetCategoryByCategoryId(int categoryId)
        {
            Category category = new Category();
            try
            {
                category = _quickStartRepository.GetCategoryByCategoryId(categoryId);
            }
            catch (Exception ex)
            {
                category = null;
            }
            return Json(category);
        }

        [HttpPost]
        public JsonResult AddCategory(string categoryName)
        {
            bool isAdded = false;
            try
            {
                isAdded = _quickStartRepository.AddCategory(categoryName);
            }
            catch (Exception ex)
            {
                isAdded = false;
            }
            return Json(isAdded);
        }

        [HttpPost]
        public JsonResult AddProductUsingStoredProcedure(Models.Product product)
        {
            string ProductId = string.Empty;
            int returnResult = 0;

            Product newProduct = _mapper.Map<Product>(product);

            if (ModelState.IsValid)
            {
                try
                {
                    returnResult = _quickStartRepository.AddProductUsingStoredProcedure(newProduct, out ProductId);
                }
                catch (Exception ex)
                {
                    returnResult = 0;
                    ProductId = string.Empty;
                }
            }
            return Json(new { Result = returnResult, ProductId });
        }

        [HttpPost]
        public JsonResult RegisterUserUsingStoredProcedure(Models.User user)
        {
            int returnResult = 0;
            User newUser = _mapper.Map<User>(user);
            if (ModelState.IsValid)
            {
                try
                {
                    returnResult = _quickStartRepository.RegisterUserUsingStoredProcedure(newUser);
                }
                catch (Exception ex)
                {
                    returnResult = 0;
                }
            }
            return Json(returnResult);
        }

        [HttpPut]
        public JsonResult UpdateCategory(int categoryId, string categoryName)
        {
            bool isUpdated = false;
            try
            {
                isUpdated = _quickStartRepository.UpdateCategory(categoryId, categoryName);
            }
            catch (Exception ex)
            {
                isUpdated = false;
            }
            return Json(isUpdated);
        }

        [HttpPut]
        public JsonResult UpdateProduct(string productId, decimal price)
        {
            bool isUpdated = false;
            try
            {
                isUpdated = _quickStartRepository.UpdateProduct(productId, price);
            }
            catch (Exception ex)
            {
                isUpdated = false;
            }
            return Json(isUpdated);
        }

        [HttpPatch]
        public JsonResult UpdateUser(string emailId, string address)
        {
            bool isUpdated = false;
            try
            {
                isUpdated = _quickStartRepository.UpdateUser(emailId, address);
            }
            catch (Exception ex)
            {
                isUpdated = false;
            }
            return Json(isUpdated);
        }

        [HttpDelete]
        public JsonResult DeleteCategory(int categoryId)
        {
            bool isDeleted = false;
            try
            {
                isDeleted = _quickStartRepository.DeleteCategory(categoryId);
            }
            catch (Exception ex)
            {
                isDeleted = false;
            }
            return Json(isDeleted);
        }
    }
}

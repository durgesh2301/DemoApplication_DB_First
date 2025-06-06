using QuickStartDALLayer;
using QuickStartDALLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace QuickStartServiceLayer.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : Controller
    {
        QuickStartRepository _quickStartRepository;
        public ProductController(QuickStartRepository quickStartRepository)
        {
            _quickStartRepository = quickStartRepository;
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
    }
}

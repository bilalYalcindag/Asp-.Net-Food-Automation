using CoreFood.Repository;
using Microsoft.AspNetCore.Mvc;
using CoreFood.Data.Models;

namespace CoreFood.Controllers
{
    public class CategoryController : Controller
    {
        CategoryRepository categoryRepository = new CategoryRepository();
        public IActionResult Index()
        {
           
            return View(categoryRepository.TList());
        }
        [HttpGet]
        public IActionResult CategoryAdd() 
        { 
            return View();
        }
        [HttpPost]
        public IActionResult CategoryAdd(Category category)
        {
            if (!ModelState.IsValid) 
            {
                return View("CategoryAdd");
            }
            categoryRepository.TAdd(category);
            return RedirectToAction("Index");
              
        }

        public IActionResult GetCategory(int id)
        {
            var x = categoryRepository.GetT(id);
            Category category = new Category()
            {
                categoryName = x.categoryName,
                categoryDescription = x.categoryDescription,
                categoryID = x.categoryID
            };
            return View();
        }
        [HttpPost]
        public IActionResult CategoryUpdate(Category category) 
        {
            var x = categoryRepository.GetT(category.categoryID);
            x.categoryName = category.categoryName;
            x.categoryDescription = category.categoryDescription;
            x.status = true;
            categoryRepository.TUpdate(x);
            return RedirectToAction("Index");

        }

        public IActionResult CategoryDelete(int id)
        {
            var x = categoryRepository.GetT(id);
            x.status = false;
            categoryRepository.TUpdate(x);
            return RedirectToAction("Index");
        }

    }
}

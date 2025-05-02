using CoreFood.Repository;
using Microsoft.AspNetCore.Mvc;
using CoreFood.Data.Models;
using X.PagedList.Extensions;
using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;

namespace CoreFood.Controllers
{
    public class CategoryController : Controller
    {
        CategoryRepository categoryRepository = new CategoryRepository();
        
        public IActionResult Index(int page = 1)
        {
            var values = categoryRepository.TList().ToPagedList(page, 10); // 10: her sayfadaki eleman sayısı
            return View(values); // Artık model IPagedList<Category> döner
        }
        [HttpGet]
        public IActionResult CategoryAdd() 
        { 
            return View();
        }
        [HttpPost]
        public IActionResult CategoryAdd(Category category)
        {
            if (ModelState.IsValid) 
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

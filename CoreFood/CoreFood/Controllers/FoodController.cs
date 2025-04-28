using CoreFood.Data.Models;
using CoreFood.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace CoreFood.Controllers
{
    public class FoodController : Controller
    {
        FoodRepository foodRepository = new FoodRepository();
        Context c = new Context();
        public IActionResult Index()
        {
            

            return View(foodRepository.TList("Category"));
        }
        [HttpGet]
        public IActionResult AddFood() 
        {
            List<SelectListItem> values = (from x in c.Categories.ToList()
                                           select new SelectListItem
                                           {
                                            Text = x.categoryName,
                                            Value = x.categoryID.ToString()
                                           }).ToList();
            ViewBag.v1 = values;
            return View();
        }
        [HttpPost]
        public IActionResult AddFood(Food food)
        {
            foodRepository.TAdd(food);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteFood(int id)
        {
            foodRepository.TRemove(new Food { foodID = id});
            return RedirectToAction("Index");
        }


        
    }
}

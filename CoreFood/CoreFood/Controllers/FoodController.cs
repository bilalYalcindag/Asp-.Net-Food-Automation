using CoreFood.Data.Models;
using CoreFood.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using X.PagedList.Extensions;


namespace CoreFood.Controllers
{
    public class FoodController : Controller
    {
        FoodRepository foodRepository = new FoodRepository();
        Context c = new Context();
        public IActionResult Index(int page = 1)
        {


            return View(foodRepository.TList("Category").ToPagedList(page, 3));
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

        public IActionResult GetFood(int id)
        {
            var x = foodRepository.GetT(id);

            List<SelectListItem> values = (from y in c.Categories.ToList()
                                           select new SelectListItem
                                           {
                                               Text = y.categoryName,
                                               Value = x.categoryID.ToString()
                                           }).ToList();
            ViewBag.v1 = values;

            Food f = new Food()
            {
                foodID = x.foodID,
                categoryID = x.categoryID,
                name = x.name,
                price = x.price,
                stock = x.stock,
                description = x.description,
                imageURL = x.imageURL
            };
            return View(f);
        }

        public ActionResult FoodUpdate (Food food) 
        {
            var x = foodRepository.GetT(food.foodID);
            x.name = food.name;
            x.stock = food.stock;
            x.price = food.price;
            x.imageURL = food.imageURL;
            x.description = food.description;
            x.categoryID = food.categoryID;
            foodRepository.TUpdate(x);
            return RedirectToAction("Index");
        }
        
    }
}

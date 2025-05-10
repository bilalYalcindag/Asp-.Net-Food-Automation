using CoreFood.Repository;
using Microsoft.AspNetCore.Mvc;

namespace CoreFood.ViewComponents
{
    public class FoodListByCategory:ViewComponent
    {
        public IViewComponentResult Invoke(int id)
        {
          
            FoodRepository foodRepository = new FoodRepository();
            var footList = foodRepository.List(x=>x.categoryID == id);
            return View(footList);
        }
    }
}

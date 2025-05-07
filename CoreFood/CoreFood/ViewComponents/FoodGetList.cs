using CoreFood.Repository;
using Microsoft.AspNetCore.Mvc;

namespace CoreFood.ViewComponents
{
    public class FoodGetList : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            FoodRepository foodRepository = new FoodRepository();
            var footList = foodRepository.TList();
            return View(footList);
        }
    }
}

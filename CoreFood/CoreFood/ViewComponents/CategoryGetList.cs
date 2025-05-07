using CoreFood.Data.Models;
using CoreFood.Repository;
using Microsoft.AspNetCore.Mvc;

namespace CoreFood.ViewComponents
{
    public class CategoryGetList: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            CategoryRepository categoryRepository = new CategoryRepository();
            var categoryList = categoryRepository.TList();
            return View(categoryList);
        }
    }
}

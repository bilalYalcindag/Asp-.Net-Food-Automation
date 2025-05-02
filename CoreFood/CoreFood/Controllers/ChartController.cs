using CoreFood.Data;
using CoreFood.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoreFood.Controllers
{
    public class ChartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Index2()
        {
            return View();
        }
        
        public IActionResult Index3()
        {
            return View();
        }

        public IActionResult VisualizeProductResult2()
        {
            return Json(FoodList());
        }

        public IActionResult VisualizeProductResult()
        {
            return Json(ProList());

        }
        public List<Class1> ProList()
        {
            List<Class1> cs = new List<Class1>();
            cs.Add(new Class1()
            {
                proname = "Computer",
                stock = 150
            });
            cs.Add(new Class1()
            {
                proname = "LCD",
                stock = 75
            });
            cs.Add(new Class1()
            {
                proname = "USB Disk",
                stock = 220
            });
            return cs;
        }

        public List<Class2> FoodList() 
        {
            List<Class2> cs2 = new List<Class2>();
            using (var c = new Context()) 
            {
                cs2 = c.Foods.Select(x => new Class2
                {
                    foodName = x.name,
                    stock = x.stock
                }).ToList();
            }
            return cs2;
        }


        public IActionResult Statics() 
        {
            Context c = new Context();
            var deger1 = c.Foods.Count();
            ViewBag.d1 = deger1;

            var deger2 = c.Categories.Count();
            ViewBag.d2 = deger2;

            var foid = c.Categories.Where(x=>x.categoryName == "Fruit").Select(y
                =>y.categoryID).FirstOrDefault();
           
            var deger3 = c.Foods.Where(x=>x.categoryID==foid).Count();
            ViewBag.d3 = deger3;

            var deger4 = c.Foods.Where(x => x.categoryID == c.Categories.Where(z => z.categoryName == "Vegetables").Select(y
                => y.categoryID).FirstOrDefault()).Count();
            ViewBag.d4 = deger4;

            var deger5 = c.Foods.Sum(x => x.stock);
            ViewBag.d5 = deger5;

            var deger6 = c.Foods.Where(x => x.categoryID == c.Categories.Where(y => y.categoryName == "Legumes").Select(z => z.categoryID).FirstOrDefault()).Count();
            ViewBag.d6 = deger6;

            var deger7 = c.Foods.OrderByDescending(x => x.stock).Select(y => y.name).FirstOrDefault();
            ViewBag.d7 = deger7;

            var deger8 = c.Foods.OrderBy(x => x.stock).Select(y => y.name).FirstOrDefault();
            ViewBag.d8 = deger8;

            var deger9 = c.Foods.Average(x => x.price).ToString("0.00");
            ViewBag.d9 = deger9;

            var deger10 = c.Categories.Where(x => x.categoryName == "Fruit").Select(y => y.categoryID).FirstOrDefault();
            var deger10p = c.Foods.Where(y => y.categoryID == deger10).Sum(x => x.stock);
            ViewBag.d10 = deger10p;

            var deger11 = c.Categories.Where(x => x.categoryName == "Vegetables").Select(y => y.categoryID).FirstOrDefault();
            var deger11p = c.Foods.Where(y => y.categoryID == deger11).Sum(x => x.stock);
            ViewBag.d11 = deger11p;

            var deger12 = c.Foods.OrderByDescending(x => x.price).Select(y => y.name).FirstOrDefault();
            ViewBag.d12 = deger12;

            return View();
        }

    }
}

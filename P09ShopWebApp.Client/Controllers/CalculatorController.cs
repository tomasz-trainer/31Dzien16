using Microsoft.AspNetCore.Mvc;

namespace P09ShopWebApp.Client.Controllers
{
    public class CalculatorController : Controller
    {

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(IFormCollection form)
        {
            //int number1 = int.Parse(form["number1"]);
            //int number2 = int.Parse(form["number2"]);

            bool ok1 = int.TryParse(form["number1"], out int number1);
            bool ok2 = int.TryParse(form["number2"], out int number2);

            if (!ok1 || !ok2)
            {
                ViewBag.ErrorMessage = "Invalid input. Please enter valid integers.";
                return View("Index");
            }

            int result = number1 + number2;

            ViewBag.MyResult = result;
            ViewBag.Number1 = number1;
            ViewBag.Number2 = number2;

            ViewData["MyResult2"] = result;

            return View("Index");
        }
    }
}

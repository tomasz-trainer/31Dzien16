using Microsoft.AspNetCore.Mvc;
using P09ShopWebApp.Client.Models;

namespace P09ShopWebApp.Client.Controllers
{
    public class NewCalculatorController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            OperationModel operationModel = new OperationModel();
            operationModel.Number1 = 8;
            operationModel.Number2 = 10;

            return View(operationModel);
        }

        [HttpPost]
        public IActionResult Index(OperationModel operationModel) 
        {
            operationModel.Result = operationModel.Number1 + operationModel.Number2;
            return View(operationModel);
        }

    }
}

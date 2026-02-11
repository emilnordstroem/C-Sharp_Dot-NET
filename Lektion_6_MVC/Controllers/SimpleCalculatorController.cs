using Microsoft.AspNetCore.Mvc;

namespace Lektion_6_MVC.Controllers
{
    public class SimpleCalculatorController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View("Calculator");
        }

        [HttpPost]
		public IActionResult Index(IFormCollection formCollection)
		{
            int firstNumber = Convert.ToInt32(formCollection["firstNumber"]);
			int secondNumber = Convert.ToInt32(formCollection["secondNumber"]);
            string arithmeticOperator = formCollection["operator"];

            double result = 0;
            switch (arithmeticOperator)
            {
                case "+": 
                    result = firstNumber + secondNumber;
                    break;
                case "-":
                    result = firstNumber - secondNumber;
                    break;
                case "x":
                    result = firstNumber * secondNumber;
                    break;
                case "/":
                    if (secondNumber != 0)
                    {
                        result = firstNumber / secondNumber;
                    }
                    break;
                default: break;
            }

            ViewBag.CalculationResult = result;
			return View("Calculator");
		}
	}
}

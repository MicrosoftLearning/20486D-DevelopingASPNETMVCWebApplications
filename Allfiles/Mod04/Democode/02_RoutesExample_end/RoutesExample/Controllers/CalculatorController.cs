using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace RoutesExample.Controllers
{
    public class CalculatorController : Controller
    {
        public IActionResult MultByTwo(int num)
        {
            int result = num * 2;
            return Content(result.ToString());
        }

        [Route("Calc/Mult/{num1:int}/{num2:int}")]
        public IActionResult Mult(int num1, int num2)
        {
            int result = num1 * num2;
            return Content(result.ToString());
        }

        [HttpGet("Divide/{param?}")]
        public IActionResult DivideByTen(int param)
        {
            int result = param / 10;
            return Content(result.ToString());
        }
    }
}
using Microsoft.AspNetCore.Mvc;

namespace RestWithASPNETUdemy.Controllers;

[ApiController]
[Route("[controller]")]
public class CalculatorController : ControllerBase
{
    private readonly ILogger<CalculatorController> _logger;

    public CalculatorController(ILogger<CalculatorController> logger)
    {
        _logger = logger;
    }

    [HttpGet("sum/{firstNumber}/{secondNumber}")]
    public IActionResult Sum(string firstNumber, string secondNumber)
    {
        if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
        {
            var result = ConverToDouble(firstNumber) + ConverToDouble(secondNumber);

            return Ok(result.ToString());
        }

        return BadRequest("Invalid Input");
    }

    [HttpGet("subtration/{firstNumber}/{secondNumber}")]
    public IActionResult Subtration(string firstNumber, string secondNumber)
    {
        if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
        {
            var result = ConverToDouble(firstNumber) - ConverToDouble(secondNumber);

            return Ok(result.ToString());
        }

        return BadRequest("Invalid Input");
    }

    [HttpGet("multiplication/{firstNumber}/{secondNumber}")]
    public IActionResult Multiplication(string firstNumber, string secondNumber)
    {
        if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
        {
            var result = ConverToDouble(firstNumber) * ConverToDouble(secondNumber);

            return Ok(result.ToString());
        }

        return BadRequest("Invalid Input");
    }

    [HttpGet("division/{firstNumber}/{secondNumber}")]
    public IActionResult Division(string firstNumber, string secondNumber)
    {
        if (IsNumeric(firstNumber) && IsNumeric(secondNumber) && IsNonZeroNumber(secondNumber))
        {
            var result = ConverToDouble(firstNumber) / ConverToDouble(secondNumber);

            return Ok(result.ToString());
        }

        return BadRequest("Invalid Input");
    }

    [HttpGet("mean/{firstNumber}/{secondNumber}")]
    public IActionResult mean(string firstNumber, string secondNumber)
    {
        if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
        {
            var result = ConverToDouble(firstNumber) + ConverToDouble(secondNumber) / 2;

            return Ok(result.ToString());
        }

        return BadRequest("Invalid Input");
    }

    [HttpGet("Sqrt/{firstNumber}")]
    public IActionResult Sqrt(string firstNumber)
    {
        if (IsNumeric(firstNumber))
        {
            var result = Math.Sqrt(ConverToDouble(firstNumber));

            return Ok(result.ToString());
        }

        return BadRequest("Invalid Input");
    }

    private bool IsNonZeroNumber(string input)
    {
        double number;
        if (double.TryParse(input, out number))
        {
            return number != 0;
        }
        return false;
    }

    private bool IsNumeric(string strNumber)
    {
        double number;

        bool isNumber = double.TryParse(
            strNumber,
            System.Globalization.NumberStyles.Any,
            System.Globalization.NumberFormatInfo.InvariantInfo,
            out number);
        return isNumber;
    }

    private double ConverToDouble(string strNumber)
    {
        double decimalValue;

        if (double.TryParse(strNumber, out decimalValue))
        {
            return decimalValue;
        }

        return 0;
    }

    
}

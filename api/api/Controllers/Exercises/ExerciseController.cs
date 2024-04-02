using api.Controllers.Exercises.Dtos;
using api.Controllers.Exercises.Services;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers.Exercises
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExerciseController : Controller
    {
        private readonly ExerciseService exerciseService;

        public ExerciseController(ExerciseService exerciseService)
        {
            this.exerciseService = exerciseService;
        }

        [HttpPost("encrypt")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public IActionResult Encrypt(EncryptBodyDto body)
        {
            if (body.a < 1 || body.b < 1) throw new Exception("El valor de A o B deben ser mayor a 0");
            if (body.a > body.phrase.Length || body.b > body.phrase.Length) throw new Exception("El valor de A o B sobrepasa la longitud de la frase");
            string result = exerciseService.encrypt(body);
            return Ok(result);
        }

        [HttpPost("validate-fibonacci")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        public IActionResult ValidateFibonacci(ValidateFibonacciBodyDto body)
        {
            bool result = exerciseService.validateFibonacci(body);
            return Ok(result);
        }
    }
}

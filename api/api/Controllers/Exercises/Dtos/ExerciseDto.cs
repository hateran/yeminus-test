namespace api.Controllers.Exercises.Dtos
{
    public class EncryptBodyDto
    {
        public string phrase { get; set; }
        public int a {  get; set; }
        public int b { get; set; }
    }

    public class ValidateFibonacciBodyDto
    {
        public int value { get; set; }
    }
}

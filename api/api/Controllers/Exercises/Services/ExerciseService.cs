using api.Controllers.Exercises.Dtos;
using System.Text;

namespace api.Controllers.Exercises.Services
{
    public class ExerciseService
    {
        public string encrypt(EncryptBodyDto body)
        {
            string phrase = Reverse(body.phrase);
            int[] positions = transformPosIntoReverseLength([body.a, body.b], phrase.Length);
            phrase = transformValueWithPos(phrase, positions);
            phrase = transformValueWithAlphabet(phrase, positions);
            return phrase;
        }

        public bool validateFibonacci(ValidateFibonacciBodyDto body)
        {
            int a = 0;
            int b = 1;

            while (a < body.value)
            {
                int temp = a;
                a = b;
                b = temp + b;
            }
            return a == body.value;
        }

        private string Reverse(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

        private string transformValue(string phrase, int pos, string value)
        {
            var aStringBuilder = new StringBuilder(phrase);
            aStringBuilder.Remove(pos - 1, 1);
            aStringBuilder.Insert(pos - 1, value);
            return aStringBuilder.ToString();
        }

        private int[] transformPosIntoReverseLength(int[] positions, int length)
        {
            int[] result = [];
            for (int i = 0; i < positions.Length; i++)
            {
                Array.Resize(ref result, result.Length + 1);
                result[result.GetUpperBound(0)] = (length - positions[i]) + 1;
            }
            return result;
        }

        private string transformValueWithPos(string phrase, int[] positions)
        {
            string result = phrase;
            for (int i = 0; i < positions.Length; i++)
            {
                result = transformValue(result, positions[i], positions[i] % 2 == 0 ? "c" : "p");
            }
            return result;
        }

        private string transformValueWithAlphabet(string value, int[] positions)
        {
            const string alphabet = "abcdefghijklmnñopqrstuvwxyz";
            char[] chars = value.ToCharArray();
            int count = 0;
            string result = value;
            for (int i = 0; i < chars.Length; i++)
            {
                if (!positions.Contains(i + 1))
                {
                    if (count > alphabet.Length - 1) count = 0;
                    string convertTo = alphabet.ElementAt(count).ToString();
                    result = transformValue(result, i + 1, convertTo);
                    count++;
                }
            }
            return result;
        }
    }
}

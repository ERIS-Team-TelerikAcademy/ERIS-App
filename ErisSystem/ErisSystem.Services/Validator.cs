namespace ErisSystem.Services
{
    internal static class Validator
    {
        public static bool ValidateStringLenght(int min, int max, string input)
        {
            if(min <= input.Length && input.Length <= max)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

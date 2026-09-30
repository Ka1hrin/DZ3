namespace PDF3
{
    public static class InputReader
    {
        public static string ReadString(string prompt)
        {
            string? input;

            do
            {
                Console.Write(prompt);
                input = Console.ReadLine();
            }
            while (string.IsNullOrWhiteSpace(input));

            return input.Trim();
        }
    }
}
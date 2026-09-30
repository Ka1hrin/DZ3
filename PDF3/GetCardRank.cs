namespace PDF3
{
    public static class Rank
    {
        public static string GetCardRank(int k)
        {
            switch (k)
            {
                case 6: return "шестёрка";
                case 7: return "семёрка";
                case 8: return "восьмёрка";
                case 9: return "девятка";
                case 10: return "десятка";
                case 11: return "валет";
                case 12: return "дама";
                case 13: return "король";
                case 14: return "туз";
                default:
                    throw new ArgumentOutOfRangeException(nameof(k), k, $"Допустимы номера 6–14, получено {k}.");
            }
        }
    }
}

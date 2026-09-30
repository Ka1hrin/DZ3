namespace PDF3
{
    public static class Name
    {
        public static string GetWeekdayName(Weekdays day)
        {
            switch (day)
            {
                case Weekdays.Monday: return "Понедельник";
                case Weekdays.Tuesday: return "Вторник";
                case Weekdays.Wednesday: return "Среда";
                case Weekdays.Thursday: return "Четверг";
                case Weekdays.Friday: return "Пятница";
                case Weekdays.Saturday: return "Суббота";
                case Weekdays.Sunday: return "Воскресенье";
                default:
                    throw new ArgumentOutOfRangeException(nameof(day), day, "Дня недели с таким значением не существует.");
            }
        }
    }
}
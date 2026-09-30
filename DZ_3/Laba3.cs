using System;
namespace DZ3
{
    internal static class Laba3
    {
        //Создаем для экономии памяти и для предотвращения случайной перезаписи
        private static readonly string[] MonthNames = {"январь", "февраль", "март", "апрель", "май", "июнь",
            "июль", "август", "сентябрь", "октябрь", "ноябрь", "декабрь"};
        static void Main()
        {
            Homework();
            Console.ReadKey(); //Окно не закончится сразу после вывода результата
        }
        private static void Homework()
        {
            //Домашнее задание 4.1
            Console.WriteLine("Домашнее задание 4.1");
            Console.Write("Введите год: ");
            if (!int.TryParse(Console.ReadLine(), out var year) || year < 1) //Если не смог преобразовать или год меньше 1
            {
                Console.WriteLine("Ошибка: год введён некорректно.");
                return; //Возвращает обратно в метод, откуда вызван
            }

            //Проверка на високосность года
            var isLeap = (year % 4 == 0 && year % 100 != 0) || (year % 400 == 0);
            var daysInYear = isLeap ? 366 : 365; //здесь мы присваиваем переменной daysInYear значение 366, если да и 365, если нет

            Console.Write($"Введите номер дня в году (1-{daysInYear}): ");
            if (!int.TryParse(Console.ReadLine(), out var day))
            {
                Console.WriteLine("Ошибка: номер дня введён некорректно.");
                return; //Вернет в самое начало и не сохранит предыдущие значения
            }

            try //Обработка исключений
            {
                if (day < 1 || day > daysInYear)
                {
                    //ArgumentOutOfRangeException - стандартное исключение, которое принимает 3 аргумента: имя параметра, его значение и сообщение для программиста
                    var error = new ArgumentOutOfRangeException(nameof(day), day, $"В {year} году {daysInYear} дней.");
                    throw error; //Принудительный выброс исключения 
                }

                var daysInMonth = new[] { 31, isLeap ? 29 : 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };

                var passedDays = 0;

                for (var i = 0; i < daysInMonth.Length; i++)
                {
                    if (day <= passedDays + daysInMonth[i]) //если удовлетворяет, значит день в текущем месяце
                    {
                        var dayOfMonth = day - passedDays; //вычисляем конкретный день
                        Console.WriteLine($"День - {dayOfMonth}, месяц - {MonthNames[i]}.");
                        return;
                    }
                    passedDays += daysInMonth[i]; //если нет, то проверяем следующий месяц
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine($"Ошибка: допустимый диапазон 1-{daysInYear}."); //Сообщение для пользователя
            }
            finally
            {
                Console.WriteLine("Расчёт завершён.");
            }
        }
    }
}

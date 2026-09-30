using System;
namespace PDF3
{
    internal class PDF3
    {
        static void Main()
        {
            Task1();
            Task2();
            Task3();
            Task4();
            Task5();
            Console.ReadKey();
        }
        private static void Task1()
        {
            //Задание 1
            Console.WriteLine(@"Задание 1
Условие: проверить, упорядочена ли последовательность из 10 чисел по возрастанию,
и если нет — назвать порядковый номер первого числа-нарушителя.
Действия пользователя: ввести 10 целых чисел.");

            //Создаем защиту от опечаток, также можем легко менять количество чисел в последовательности
            const int Count = 10;
            int[] numbers = new int[Count];
            Console.WriteLine($"Пожалуйста, введите {Count} целых чисел по очереди:");

            //Создаем цикл для ввода 
            for (int i = 0; i < Count; i++)
            {
                numbers[i] = ConsoleHelper.ReadInt($"Число {i + 1}: "); //Записываем введённое число в элемент с индексом i
            }
            bool isSorted = true;      //Создаем флаг
            int violationPosition = -1;     //Присваиваем именно -1, т.к. такого порядкового номера нет и ошибки тоже

            //Создаем цикл проверки 
            for (int i = 0; i < Count - 1; i++) //i < Count-1 - пишем именно так, т.к. код читает число, которое правее
            {
                if (numbers[i] > numbers[i + 1])
                {
                    isSorted = false;
                    violationPosition = i + 1; //меняем на номер, который нарушает последовательность
                    break;
                }
            }
            //Вывод результата 
            if (isSorted)
                Console.WriteLine("Результат: последовательность упорядочена по возрастанию.");
            else
                Console.WriteLine($@"Нарушение порядка в позиции {violationPosition}:
число {numbers[violationPosition - 1]} больше следующего за ним.");
            //[violationPosition - 1] - превращаем обратно в индекс, чтобы вывести значение переменной

        }
        //Задание 2
        private static void Task2()
        {
            Console.WriteLine(@"Задание 2
Условие: определить достоинство карты по её номеру (6-14).
Действия пользователя: ввести номер карты.");

            int k = ConsoleHelper.ReadInt("Номер карты (6-14): ");

            try
            {
                string rank = Rank.GetCardRank(k);
                Console.WriteLine($"Ответ: карта {k} — {rank}.");
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine($"Ошибка: карты с номером {k} не существует.\nДопустимы номера 6-14.");
            }
            finally
            {
                // Выполнится и при успехе, и при ошибке
                Console.WriteLine("Обработка номера карты завершена.");
            }
        }

        //Задание 3
        private static void Task3()
        {
            Console.WriteLine(@"Задание 3
Условие: определить напиток по имени посетителя.
Действия пользователя: ввести имя посетителя.");

            string who = InputReader.ReadString("Кто пришёл (Jabroni, School Counselor, Programmer, Bike Gang Member, Politician, Rapper): ");

            Console.WriteLine($"Ответ: {who} — {Drink.GetDrink(who)}.");
        }

        //Задание 4
        private static void Task4()
        {
            Console.WriteLine(@"Задание 4
Условие: получить название дня недели по его номеру (1-7).
Действия пользователя: ввести номер дня недели.");

            int n = ConsoleHelper.ReadInt("Номер дня (1-7): ");

            //Enum.IsDefined(type, value) - проверяет, есть ли в первом второе
            //!Enum.IsDefined(..,..) - если это false, т.е. значения два нет в первом, то выполняется
            if (!Enum.IsDefined(typeof(Weekdays), n))
            {
                Console.WriteLine($"Ошибка: дня с номером {n} не существует.");
                Console.WriteLine("Допустимы номера 1-7.");
                return;
            }
            Weekdays day = (Weekdays)n; //явное приведение номера n в соответственное значение из Weekdays

            Console.WriteLine($"Ответ: {Name.GetWeekdayName(day)}.");
        }

        //Задание 5
        private static void Task5()
        {
            Console.WriteLine(@"Задание 5
Условие: обойти массив игрушек через foreach и посчитать, сколько попадёт в ""сумку""
(Hello Kitty и Barbie doll).
Действия пользователя: нет");

            string[] toys = {"Barbie doll", "Bumblebee", "Hello Kitty", "Lego", "Hello Kitty", "Spider-Man",
                "Barbie doll", "Simba", "Barbie doll", "Teddy bear"};

            //Пишем const, т.к. значения не должны меняться
            const string HelloKitty = "Hello Kitty";
            const string BarbieDoll = "Barbie doll";

            //Счетчики (количество кукол в сумке)
            int dollsInBag = 0;

            //Для каждого toy из массива 
            foreach (string toy in toys)
            {
                if (toy == HelloKitty || toy == BarbieDoll)
                    dollsInBag++;
            }
            Console.WriteLine($"Ответ: в сумке {dollsInBag} кукол.");
        }
    }
}


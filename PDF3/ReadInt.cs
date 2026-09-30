public static class ConsoleHelper
{
    //Метод, который будет проверять, что пользователь ввел число
    public static int ReadInt(string prompt)
    {
        //Переменные, которые будут использоваться внутри следующего цикла
        int value;
        bool isValid;

        do
        {
            Console.Write(prompt);
            var input = Console.ReadLine();

            isValid = int.TryParse(input, out value); //Разделяем, т.к. значение переменной дальше используется

            //Если не смог преобразовать, то вывести сообщение
            if (!isValid)
                Console.WriteLine($"Ошибка: «{input}» — не целое число. Попробуйте снова.");
        }
        while (!isValid); //Повторять, пока переменная !isValid не станет falseS

        return value;
    }
}
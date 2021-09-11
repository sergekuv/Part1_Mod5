using System;

namespace Part1_Mod5
{
    class Program
    {
        static void Main(string[] args)
        {
            //Task_5_1_1();
            //Task_5_1_5();
            //Task_5_1_6();
            Task_5_2_2();



            Console.WriteLine("\nEnd");
        }

        private static void Task_5_2_2()         //Вводим и выводим данные пользователя, включая цвета
        {
            Console.WriteLine("\n-- 5.2.2 --");
            (string Name, int Age, string[] favColors) user = EnterUserFromConsole();
            PrintUser(user);
            Console.WriteLine("\n-- end of 5.2.2 --");
        }

        private static void PrintUser((string Name, int Age, string[] favColors) user)
        {
            Console.WriteLine("Информация о пользвоателе: ");
            Console.Write($"Имя: {user.Name}; Вoзраст: {user.Age}; Любимые цвета: ");
            PrintColors(user.favColors);
        }

        private static void  PrintColors(string[] favColors)
        {
            ConsoleColor currentForeground = Console.ForegroundColor;
            ConsoleColor currentBackground = Console.BackgroundColor;
            foreach (string item in favColors)
            {
                Console.ForegroundColor = ConsoleColor.Black;
                switch (item)
                {
                    case "red":
                        Console.BackgroundColor = ConsoleColor.Red;
                        break;
                    case "green":
                        Console.BackgroundColor = ConsoleColor.Green;
                        break;
                    case "cyan":
                        Console.BackgroundColor = ConsoleColor.Cyan;
                        break;
                    default :
                        Console.BackgroundColor = ConsoleColor.Gray;
                        Console.Write("(используем серый вместо) ");
                        break;
                }
                Console.Write(" " + item + " ");
            }
            Console.ForegroundColor = currentForeground;
            Console.BackgroundColor = currentBackground;
            Console.WriteLine();
        }

        private static (string Name, int Age, string[] favColors) EnterUserFromConsole()
        {
            //вводим информацию о пользователи с консоли
            const int colorsLen = 3; //длина массива цветов
            Console.Write("Введите имя: ");
            string name = Console.ReadLine();
            Console.Write("Введите возраст (целое число цифрами): ");
            int age;
            bool ageIsCorrect = Int32.TryParse(Console.ReadLine(), out age);
            string[] colors = new string[colorsLen];
            for (int i = 0; i < colorsLen; i++)
            {
                Console.Write("Введите название цвета на английском ({0} из {1}): ", i+1, colorsLen);
                colors[i] = Console.ReadLine().ToLower();
            }
            return (name, age, colors);
        }

        static void Task_5_1_1() //Задание 5.1.1
        {
            Console.WriteLine("-- 5.1.1 --");
            //Создайте кортеж User, содержащий имя пользователя Name и массив с текстовой информацией о его пяти любимых блюдах Dishes.
            //Заполните имя пользователя через ввод в консоль, а информацию о блюдах — в цикле через консоль
            const int dishQuantity = 3; //по условию задачи количество блюд 5
            (string Name, string[] Dishes) user51 = new("", new string[dishQuantity]);
            Console.Write("Введите имя пользователя: ");
            user51.Name = Console.ReadLine();

            for (int i = 0; i < user51.Dishes.Length; i++)
            {
                Console.Write($"Введите название любимого блюда {i + 1} из {dishQuantity}: ");
                user51.Dishes[i] = Console.ReadLine();
            }
            Console.Write($"{user51.Name} likes: ");
            foreach (string dish in user51.Dishes)
            {
                Console.Write(dish + " ");
            }
            Console.WriteLine("\n-- end of 5.1.1 --\n");
        }

        static void Task_5_1_5()  // Задание 5.1.5 
        {
            Console.WriteLine("-- 5.1.5 --");
            //Напишите программу, которая в цикле вызывает метод ShowColor(), записывает его значение в массив из трех цветов favcolors,
            //а потом отображает значения этого массива. 
            string[] favColors = new string[3];
            for (int i = 0; i < favColors.Length; i++)
            {
                Console.Write($"Введите название цвета ({i + 1} из {favColors.Length}) на английском: ");
                favColors[i] = GetColorFromConsole();
                ShowColor(favColors[i]);
            }
            Array.Sort(favColors);
            Console.WriteLine("\nВывод результата сортировки");
            foreach (string color in favColors)
            {
                ShowColor(color, "");
            }
            Console.WriteLine("\n-- end of 5.1.5 --\n");
        }


        private static void Task_5_1_6() //после ввода массива с клавиатуры необходимо отсортировать массив и вывести его на экран.
        {
            const int arrLen = 3;
            Console.WriteLine("\n-- 5.1.6 --");
            int[] arr = GetArrayFromConsole(arrLen); //вводим массив
            PrintArrayToConsole(ref arr);                   //выводим массив
            SortArray(arr);                          //сортируем массив
            PrintArrayToConsole(ref arr);                   //выводим массив
            Console.WriteLine("\n-- end of 5.1.6 --");

        }

        private static void SortArray(int[] arr) 
        {
            Console.WriteLine("Сортируем массив..");
            int temp;       //переменная для обмена значениями между элементами массива
            //int position;   //позиция в массиве, где находится самая маленькая переменная для данной итерации (ее и будем менять местами с текущей)
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = i+1; j < arr.Length; j++)
                {
                    if (arr[j] < arr[i])
                    {
                        temp = arr[i];
                        arr[i] = arr[j];
                        arr[j] = temp;
                    } 
                }
            }
        }

        private static void PrintArrayToConsole(ref int[] arr)  //выводим элементы массива на консоль
        {
            Console.Write("Вот элементы массива: ");
            foreach (int i in arr)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
        }

        private static int[] GetArrayFromConsole(int arrLen)    //вводим элементы массива с консоли
        {
            int[] myArray = new int[arrLen];
            for(int i=0; i<arrLen; i++)
            {
                Console.Write($"Введите целое число - элемент массива номер {i+1} из {arrLen}: ");
                bool enteredInt = int.TryParse(Console.ReadLine(), out myArray[i]);
            }
            return myArray;
        }


        static string GetColorFromConsole() => Console.ReadLine().ToLower();  //нужны ли такие "однооператорные" методы? Попросить пару примеров, когда они нужны
        private static void ShowColor(string color, string text = "Вы выбрали")  //Временно меняем цвет фона консоли на выбранный цвет
        {
            ConsoleColor initForeground = Console.ForegroundColor;
            ConsoleColor initBackground = Console.BackgroundColor;
            Console.ForegroundColor = ConsoleColor.Black;
            switch (color)
            {
                case "cyan":
                    Console.BackgroundColor = ConsoleColor.Cyan;
                    break;
                case "red":
                    Console.BackgroundColor = ConsoleColor.Red;
                    break;
                case "green":
                    Console.BackgroundColor = ConsoleColor.Green;
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.Write($"{(text == "Вы выбрали" ? "(Такого цвета нет в меню, получите серый ) " : "")}");
                    break;
            }
            Console.WriteLine($"{text} {color}");
            Console.ForegroundColor = initForeground;
            Console.BackgroundColor = initBackground;
        }
    }
}

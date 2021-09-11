using System;

namespace Part1_Mod5
{
    class Program
    {
        static void Main(string[] args)
        {
            //Task_5_1_1();
            //Task_5_1_5();

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


            Console.WriteLine("\nEnd");
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

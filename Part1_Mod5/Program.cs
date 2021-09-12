using System;

namespace Part1_Mod5
{
    class Program
    {
        static void Main(string[] args)
        {
            //Task_5_1_1();
            //Task_5_1_5();
            //Task_5_1_6(); //она же 5.2.8, она же 5.2.14
            //Task_5_2_2(); //она же 5.2.3
            //Task_5_2_17();
            //Task_5_2_18();
            //Task_5_3_1();
            //Task_5_3_8();
            //Task_5_3_13();
            //Task_5_5_4();
            //Task_5_5_5();
            //Task_5_5_8();
            Task_5_6();

            Console.WriteLine("\nEnd");
        }

        #region 5_1
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

        private static void Task_5_1_6() // - она же 5.2.8, она же 5.2.15  после ввода массива с клавиатуры необходимо отсортировать массив и вывести его на экран
        {
            const int arrLen = 3;
            Console.WriteLine("\n-- 5.1.6 --");
            int[] arr = GetArrayFromConsole(); //вводим массив
            ShowArray(ref arr);                   //выводим массив
            SortArray(arr);                          //сортируем массив
            ShowArray(ref arr);                   //выводим массив
            Console.WriteLine("\n-- end of 5.1.6 --");

        }
        #endregion
        #region 5_2
        private static void Task_5_2_2() //Вводим и выводим данные пользователя, включая цвета
        {
            Console.WriteLine("\n-- 5.2.2 --");
            (string Name, int Age, string[] favColors) user = EnterUserFromConsole();
            PrintUser(user);
            Console.WriteLine("\n-- end of 5.2.2 --");
        }

        private static void Task_5_2_17() // Создайте метод ShowArray с параметрами: массив чисел, признак сортировки логического типа,
                                          // необязательный параметр, по умолчанию ЛОЖЬ. Метод должен выводить массив на экран.
                                          // Если значение признака сортировки равно ИСТИНА, то предварительно массив нужно отсортировать.
        {
            const int arrLen = 3;
            Console.WriteLine("\n-- 5.2.17 --");
            int[] arr = GetArrayFromConsole(); //вводим массив
            Console.WriteLine("Вызов ShowArray без сортировки");
            ShowArray(ref arr);                   //выводим массив
            Console.WriteLine("Вызов ShowArray с сортировкой");
            ShowArray(ref arr, sort: true);       //выводим массив
            Console.WriteLine("\n-- end of 5.2.18 --");

        }

        private static void Task_5_2_18() // Создайте метод ShowArray с параметрами: массив чисел, признак сортировки логического типа,
                                          // необязательный параметр, по умолчанию ЛОЖЬ. Метод должен выводить массив на экран.
                                          // Если значение признака сортировки равно ИСТИНА, то предварительно массив нужно отсортировать.
        {
            Console.WriteLine("\n-- 5.2.18 --");
            int[] arr = GetArrayFromConsole(arrLen: 10); //вводим массив
            Console.WriteLine("Вызов ShowArray без сортировки");
            ShowArray(ref arr);                   //выводим массив
            Console.WriteLine("Вызов ShowArray с сортировкой");
            ShowArray(ref arr, sort: true);       //выводим массив
            Console.WriteLine("\n-- end of 5.2.18 --");

        }
        #endregion
        #region 5_3
        private static void Task_5_3_1() //Проверяем передачу по ссылке и по значению
        {
            Console.WriteLine("\n-- 5.3.1 --");
            int[] arr = { 1, 8, 3, 2, 8 };
            ShowArray(ref arr);
            int[] arr2 = arr;
            SortArray(arr2);
            ShowArray(ref arr);
            Console.WriteLine("\n-- 5.3.1 --");
        }
        private static void Task_5_3_5() // ВОкруг задания 5.3.5: проверяем работу "in"
        {
            var arr = new int[] { 1, 2, 3 };
            Console.WriteLine(arr[0]);
            BigDataOperation(arr, arr[0]);
            Console.WriteLine(arr[0]);
        }

        private static void Task_5_3_8() // Необходимо передать по ссылке размерность массива в метод GetArrayFromConsole и изменить её на 6.
        {
            Console.WriteLine("\n-- 5.3.8 --");
            int arrLen = 10;
            Console.WriteLine($"ArrLen before GetArray...Ref: {arrLen}");
            int[] arr = GetArrayFromConsoleRef(ref arrLen); //вводим массив
            Console.WriteLine($"ArrLen after GetArray...Ref: {arrLen}");
            Console.WriteLine("Вызов ShowArray без сортировки");
            ShowArray(ref arr);                   //выводим массив
            Console.WriteLine("\n-- end of 5.3.8 --");

        }
        private static void Task_5_3_13() //Используйте код метода SortArray. Сейчас этот метод сортирует массив по возрастанию значения.
        //Создайте методы SortArrayDesc и SortArrayAsc — сортировка массива от большего к меньшему и сортировка массива от меньшего к большему.
        //Метод SortArray модифицируйте так, чтобы он вызвал оба этих метода.Результаты методов SortArrayAsc и SortArrayDesc должны представлять собой массивы.
        //Метод SortArray должен иметь один входной параметр array и два выходных: sorteddesc и sorted asc.
        {
            const int arrLen = 3;
            Console.WriteLine("\n-- 5.3.13 --");
            int[] arr = GetArrayFromConsole(); //вводим массив
            SortArray_5_3_13(in arr, out int[] sortedAsc, out int[] sortedDesc);                       //сортируем массив
            Console.WriteLine("Initial array");
            ShowArray(ref arr);                   //выводим массив
            Console.WriteLine("Sorted Asc");
            ShowArray(ref sortedAsc);
            Console.WriteLine("Sorted Desc");
            ShowArray(ref sortedDesc);

            Console.WriteLine("\n-- end of 5.3.13 --");
        }

        private static void SortArray_5_3_13(in int[] arr, out int[] sorterAsc, out int[] sortedDesc)
        {
            sorterAsc = SortArrayAsc(arr);
            sortedDesc = SortArrayDesc(arr);
        }
        #endregion
        #region 5_5
        private static void Task_5_5_4()
        {
            Console.Write("Введите фразу для эха: ");
            Echo(Console.ReadLine());
            
        }

        private static void Task_5_5_5()
        {
            Console.Write("Введите целое число для расчета факториала: ");
            bool enteredInt = UInt32.TryParse(Console.ReadLine(), out uint num);
            Console.WriteLine($"Факториал {num} равен {Factorial(num)}"); 
        }

        private static void Task_5_5_8() //Необходимо написать рекурсивный метод, который возводит введенное число N типа int в указанную степень pow типа byte.
        {
            Console.Write("Введите целое число: ");
            bool numIsInt = int.TryParse(Console.ReadLine(), out int num);
            Console.Write("Введите степень (целое положительное число): ");
            bool powIsInt = byte.TryParse(Console.ReadLine(), out byte pow);
            Console.WriteLine($"{num}**{pow} = {PowerUp(num, pow)}");

        }
        static int PowerUp(int baseNum, byte power)
        {
            if (power == 0) return 1;
            checked
            {
                try
                {
                    return baseNum * PowerUp(baseNum, (byte)(power - 1));
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return 0;
                }
            }
        }
        private static uint Factorial(uint num)
        {
            checked
            {
                try
                {
                    return num == 0 ? 1 : num * Factorial(num - 1);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return 0;
                }
            }
        }

        private static void Echo(string s)
        {
            Console.ForegroundColor = ((ConsoleColor)(s.Length % 16));
            Console.WriteLine(s);
            if (s.Length > 2)
            {
                Echo(s.Remove(0, 2));
            }
        }

        #endregion

        #region 5_6
        private static void Task_5_6()
        {

        }
        #endregion
        #region accessories
        private static int[] SortArrayAsc(int[] arr)
        {
            int[] tempArr = new int[arr.Length];
            for (int i = 0; i < arr.Length; i++)
            {
                tempArr[i] = arr[i];
            }
            Array.Sort(tempArr);
            return tempArr;
        }

        private static int[] SortArrayDesc(int[] arr)
        {
            int[] tempArr = SortArrayAsc(arr);
            Array.Reverse(tempArr);
            return tempArr;
        }

        static void BigDataOperation(in int[] arr, in int item)
        {
            arr[0] = 4;
            //item = 77; //Comp. Error
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

        private static void ShowArray(ref int[] arr, bool sort = false )  //выводим элементы массива на консоль
        {
            if (sort)
            {
                SortArray(arr);
            }
            Console.Write("Вот элементы массива: ");
            foreach (int i in arr)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
        }

        private static int[] GetArrayFromConsole(int arrLen = 3)    //вводим элементы массива с консоли
        {
            int[] myArray = new int[arrLen];
            for(int i=0; i<arrLen; i++)
            {
                Console.Write($"Введите целое число - элемент массива номер {i+1} из {arrLen}: ");
                bool enteredInt = int.TryParse(Console.ReadLine(), out myArray[i]);
            }
            return myArray;
        }

        private static int[] GetArrayFromConsoleRef(ref int arrLen)    //вводим элементы массива с консоли
        {
            arrLen = 6;
            int[] myArray = new int[arrLen];
            for (int i = 0; i < arrLen; i++)
            {
                Console.Write($"Введите целое число - элемент массива номер {i + 1} из {arrLen}: ");
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

        private static void PrintUser((string Name, int Age, string[] favColors) user)
        {
            Console.WriteLine("Информация о пользвоателе: ");
            Console.Write($"Имя: {user.Name}; Вoзраст: {user.Age}; Любимые цвета: ");
            PrintColors(user.favColors);
        }

        private static void PrintColors(string[] favColors)
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
                    default:
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
                Console.Write("{2}, введите название цвета на английском ({0} из {1}): ", i + 1, colorsLen, name); //исправлено в соотв. с требованием 5.2.3
                colors[i] = Console.ReadLine().ToLower();
            }
            return (name, age, colors);
        }
        #endregion

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Lab_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();

            int answer;//ответ в меню
            int lenght_array;//длина массива
            int min_lenght = 0;//минимальная длина массива
            int max_lenght = 100;//максимальная длина массива
            int readAnswer;//ответа выбора заполнения массива
            

            int[] arr = new int[0];//пустой массив
            int[] line = new int[0];//дополнительный массив для задания 6
           
            bool isAnswerChecked;//флаг для проверки правильности ввода ответа меню
            bool isLenghtChecked;//флаг для проверки правильности ввода длины массива
            bool isReadAnswer;//флаг для проверки правильности ввода выбора способа запонения массива
            bool isArrayNull = true;//флаг для проверки пустого массива
            
            do
            {
                Console.WriteLine("1. Создать массив");
                Console.WriteLine("2. Распечатать массив");
                Console.WriteLine("3. Удалить все элементы с четными номерами");
                Console.WriteLine("4. Добавить N элементов начиная с номера K");
                Console.WriteLine("5. Перевернуть массив");
                Console.WriteLine("6. Найти элемент с заданным ключом(значением) и посчитать кол-во сравнений, необходимых для поиска");
                Console.WriteLine("7. Сортировка способом Простое включение");
                Console.WriteLine("8. Бинарный поиск элемента");
                Console.WriteLine("9. Конец");
                Console.WriteLine("Выберите действие, которое хотите выполнить: ");

                do
                {
                    isAnswerChecked = int.TryParse(Console.ReadLine(), out answer);

                    if (answer < 1 | answer > 9)
                        isAnswerChecked = false;

                    if (!isAnswerChecked)
                        Console.WriteLine("Ошибка при вводе пункта меню. Попробуйте ещё раз");

                } while (!isAnswerChecked);
                switch (answer)
                {
                    case 1: //заполнение массива
                        Console.WriteLine("Введите количество элементов массива");
                        do
                        {
                            isLenghtChecked = int.TryParse(Console.ReadLine(),out lenght_array);

                            if (lenght_array < min_lenght | lenght_array > max_lenght)
                                Console.WriteLine("Ошибка при вводе длины массива. Попробуйте ещё раз");

                        }while (!isLenghtChecked);

                        arr = new int[lenght_array];

                        Console.WriteLine("Выберите способ заполнения массива:");
                        Console.WriteLine("1. Заполнить массив рандомно");
                        Console.WriteLine("2. Заполнить массив с клавиатуры");

                        do
                        {
                            try
                            {
                                readAnswer = int.Parse(Console.ReadLine());
                                isReadAnswer = true;
                            }
                            catch (FormatException) 
                            {
                                readAnswer = 0;
                                Console.WriteLine("Вы неправильно ввели пункт меню. Попробуйте ещё раз");
                                isReadAnswer = false;
                            }
                        } while (!isReadAnswer || readAnswer!=1 && readAnswer!=2);

                        switch (readAnswer)
                        {
                            case 1:
                                for (int i = 0; i<lenght_array; i++)
                                    arr[i] = rnd.Next(0,100);
                                break;
                            case 2:
                                int m = 0;
                                while (m < lenght_array)
                                {
                                    try
                                    {
                                        Console.WriteLine($"Введите {m + 1}-ый элемент массива: ");
                                        arr[m] = int.Parse(Console.ReadLine());
                                    }
                                    catch
                                    {
                                        Console.WriteLine("Ошибка при вводе целого числа. Попробуйте ещё раз");
                                        m--;
                                    }
                                    m++;
                                }
                                break;
                        }
                        Console.WriteLine("Массив создан");
                        isArrayNull = false;
                        break;

                    case 2: //вывод массива
                        Console.WriteLine();

                        if (!isArrayNull && arr.Length != 0)
                        {
                            for (int i = 0; i < arr.Length; i++)
                                Console.Write($"{arr[i]} ");
                            Console.WriteLine();
                        }

                        else
                            Console.WriteLine("Массив пустой");
                        Console.WriteLine();
                        break;

                    case 3: //удаление чётных элементов массива
                        Console.WriteLine();

                        if (!isArrayNull && arr.Length != 0)
                        {
                            Console.WriteLine("Начальный массив"); //Вывод начального массива
                            for (int i = 0; i < arr.Length; i++)
                                Console.Write($"{arr[i]} ");
                            Console.WriteLine();

                            int newSize = (arr.Length+1)/2;// Вычисляем количество нечетных элементов

                            int[] newArr = new int[newSize]; //создаем дополнительный массив

                            for (int i = 0, j = 0; i < arr.Length; i+=2) //идём по массиву с шагом 2
                                newArr[j++] = arr[i];

                            arr = newArr;

                            Console.WriteLine("Итоговый массив");
                            for (int i = 0; i < arr.Length; i++)
                                Console.Write($"{arr[i]} ");
                            Console.WriteLine();
                        }

                        else
                            Console.WriteLine("Массив пустой");
                        Console.WriteLine();
                        break;

                    case 4: //Добавить N элементов начиная с номера K
                        Console.WriteLine();

                        if (!isArrayNull && arr.Length != 0)
                        {
                            Console.WriteLine("Начальный массив");
                            for (int i = 0; i < arr.Length; i++)
                                Console.Write($"{arr[i]} ");
                            Console.WriteLine();

                            int n;
                            int k;

                            Console.WriteLine("Введите количество вставляемых значений");
                            do
                            {
                                isAnswerChecked = int.TryParse(Console.ReadLine(), out n);

                                if (!isAnswerChecked)
                                    Console.WriteLine("Ошибка при вводе. Попробуйте ещё раз");

                            } while (!isAnswerChecked);
                            
                            line = new int[n];

                            Console.WriteLine("Выберите способ заполнения массива:");
                            Console.WriteLine("1. Заполнить массив рандомно");
                            Console.WriteLine("2. Заполнить массив с клавиатуры");

                            do
                            {
                                try
                                {
                                    readAnswer = int.Parse(Console.ReadLine());
                                    isReadAnswer = true;
                                }
                                catch (FormatException)
                                {
                                    readAnswer = 0;
                                    Console.WriteLine("Вы неправильно ввели пункт меню. Попробуйте ещё раз");
                                    isReadAnswer = false;
                                }
                            } while (!isReadAnswer);

                            switch (readAnswer)
                            {
                                case 1:
                                    for (int i = 0; i < n; i++)
                                        line[i] = rnd.Next(0, 100);
                                    break;

                                case 2:
                                    int m = 0;
                                    while (m < n)
                                    {
                                        try
                                        {
                                            Console.WriteLine($"Введите {m + 1}-ый элемент массива: ");
                                            line[m] = int.Parse(Console.ReadLine());
                                        }
                                        catch
                                        {
                                            Console.WriteLine("Ошибка при вводе целого числа. Попробуйте ещё раз");
                                            m--;
                                        }
                                        m++;
                                    }
                                    break;
                            }

                            Console.WriteLine("Вставляемая строка");
                            for (int i = 0; i < line.Length; i++)
                                Console.Write($"{line[i]} ");
                            Console.WriteLine();

                            Console.WriteLine("Введите номер элемента, после которого нужно вставить значения");
                            do
                            {
                                isAnswerChecked = int.TryParse(Console.ReadLine(), out k);

                                if (!isAnswerChecked)
                                    Console.WriteLine("Ошибка при вводе. Попробуйте ещё раз");

                                if (k > arr.Length)
                                {
                                    Console.WriteLine("В последовательности нет столько чисел, повторите ввод");
                                    isAnswerChecked= false;
                                }

                            } while (!isAnswerChecked);

                            int[] newArr = new int[n+arr.Length];

                            for (int i = 0, j=0;i < k;i++)
                                newArr[j++] = arr[i];
                            for (int i = 0,j=k;i < n;i++)
                                newArr[j++] = line[i];
                            for (int i = k, j = k+n; i<arr.Length;i++)
                                newArr[j++] = arr[i];

                            arr = newArr;

                            Console.WriteLine("Итоговый массив");
                            for (int i = 0; i < arr.Length; i++)
                                Console.Write($"{arr[i]} ");
                            Console.WriteLine();
                        }

                        else
                            Console.WriteLine("Массив пустой");
                        Console.WriteLine();
                        break;

                    case 5://Перевернуть массив
                        Console.WriteLine();

                        if (!isArrayNull && arr.Length != 0)
                        {
                            Console.WriteLine("Начальный массив");
                            for (int i = 0; i < arr.Length; i++)
                                Console.Write($"{arr[i]} ");
                            Console.WriteLine();

                            int left = 0;
                            int right = arr.Length - 1;

                            while (left < right)
                            {
                                (arr[left], arr[right]) = (arr[right], arr[left]);
                                left++;
                                right--;
                            }

                            Console.WriteLine("Итоговый массив");
                            for (int i = 0; i < arr.Length; i++)
                                Console.Write($"{arr[i]} ");
                            Console.WriteLine();
                        }
                        else
                            Console.WriteLine("Массив пустой");
                        Console.WriteLine();
                        break;
                    case 6://Найти элемент с заданным ключом(значением) и посчитать кол-во сравнений, необходимых для поиска
                        Console.WriteLine();
                        if (!isArrayNull && arr.Length != 0)
                        {
                            Console.WriteLine("Начальный массив");
                            for (int i = 0; i < arr.Length; i++)
                                Console.Write($"{arr[i]} ");
                            Console.WriteLine();

                            int key;
                            int count = 0;

                            Console.WriteLine("Введите значение для поиска");
                            do
                            {
                                isAnswerChecked = int.TryParse(Console.ReadLine(), out key);

                                if (!isAnswerChecked)
                                    Console.WriteLine("Ошибка при вводе. Попробуйте ещё раз");

                            } while (!isAnswerChecked);

                            bool isChecked = false;

                            for (int i = 0; i < arr.Length; i++)
                            {
                                count++;
                                if (arr[i] == key)
                                {
                                    isChecked = true;
                                    Console.WriteLine($"Индекс введенного элемента: {i+1}");
                                    Console.WriteLine($"Количество сравнений необходимых для поиска: {count}");
                                    break;
                                }

                            }

                            if (!isChecked)
                                Console.WriteLine("В последовательности нет такого числа");

                        }
                        else
                            Console.WriteLine("Массив пустой");
                        Console.WriteLine();
                        break;
                    case 7: //Сортировка способом Простое включение
                        Console.WriteLine();
                        if (!isArrayNull && arr.Length != 0)
                        {
                            Console.WriteLine("Начальный массив");
                            for (int i = 0; i < arr.Length; i++)
                                Console.Write($"{arr[i]} ");
                            Console.WriteLine();

                            for (int i = 1; i < arr.Length; i++)
                            {
                                int key = arr[i];
                                int j = i - 1;

                                // Сдвиг элементов, которые больше ключа, на одну позицию вперед
                                while (j >= 0 && arr[j] > key)
                                {
                                    arr[j + 1] = arr[j];
                                    j--;
                                }
                                arr[j + 1] = key;
                            }

                            // Вывод результата
                            Console.WriteLine("Отсортированный массив");
                            for (int i = 0; i < arr.Length; i++)
                            {
                                Console.Write(arr[i] + " ");
                            }

                        }
                        else
                            Console.WriteLine("Массив пустой");
                        Console.WriteLine();
                        break;
                    case 8://Бинарный поиск элемента
                        Console.WriteLine();
                        if (!isArrayNull && arr.Length != 0)
                        {
                            Console.WriteLine("Начальный массив");
                            for (int i = 0; i < arr.Length; i++)
                                Console.Write($"{arr[i]} ");
                            Console.WriteLine();

                            int key;
                            int count = 0;
                            int left = 0;
                            int right = arr.Length - 1;
                            bool isChecked = false;

                            Console.WriteLine("Введите значение для поиска");
                            do
                            {
                                isAnswerChecked = int.TryParse(Console.ReadLine(), out key);

                                if (!isAnswerChecked)
                                    Console.WriteLine("Ошибка при вводе. Попробуйте ещё раз");

                            } while (!isAnswerChecked);

                            //Сортировка массива
                            for (int i = 1; i < arr.Length; i++)
                            {
                                int element = arr[i];
                                int j = i - 1;

                                // Сдвиг элементов, которые больше ключа, на одну позицию вперед
                                while (j >= 0 && arr[j] > element)
                                {
                                    arr[j + 1] = arr[j];
                                    j--;
                                }
                                arr[j + 1] = element;
                            }

                            // Вывод результата
                            Console.WriteLine("Отсортированный массив");
                            for (int i = 0; i < arr.Length; i++)
                            {
                                Console.Write(arr[i] + " ");
                            }

                            //поиск элемента в отсортированном массиве
                            Console.WriteLine() ;
                            while (left <= right)
                            {
                                int mid = left + (right - left) / 2;

                                count++;
                                if (arr[mid] == key)
                                {
                                    
                                    Console.WriteLine($"Элемент найден на индексе:{mid + 1} ");
                                    Console.WriteLine($"Количество требуемых сравнений:{count} ");
                                    isChecked = true;
                                    break;
                                }
                                else if (arr[mid] < key)
                                {
                                    left = mid + 1;
                                }
                                else
                                {
                                    right = mid - 1;
                                }
                            }

                            if (!isChecked)
                            {
                                Console.WriteLine("Элемент не найден.");
                            }


                        }
                        else
                            Console.WriteLine("Массив пустой");
                        Console.WriteLine();
                        break;
                }

            } while (answer < 9);
            
        }
    }
}

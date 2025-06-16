using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp59
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = new int[0];
            bool isStart = true;
            string userText;

            const string CommandDelite = "del";
            const string CommandExit = "exit";
            const string CommandSort = "sort";

            while (isStart)
            {
                Console.Clear();
                Console.WriteLine();

                for (int i = 0; i < numbers.Length; i++)
                    Console.Write($"{numbers[i]} ");

                Console.WriteLine();
                Console.WriteLine("Для добавления числа просто напиште его: ");
                Console.WriteLine("Для удаления числа введите "+CommandDelite);
                Console.WriteLine("Для сортировки введите " + CommandSort);
                Console.WriteLine("Для выхода введите "+CommandExit);
                Console.Write("Ввод: ");
                userText = Console.ReadLine();
                Console.WriteLine();

                switch (userText)
                {
                    case CommandDelite:
                        RemuveNumber(ref numbers);
                        break;
                    case CommandSort:
                        BubbleSort(ref numbers);
                        break;
                    case CommandExit:
                        isStart = false;
                        break;
                    default:
                        InputNumber(ref numbers,userText);
                        break;
                }

                Console.ReadKey();
            }
        }

        static void InputNumber(ref int[] numbers, string text)
        {
            int number;

            if (int.TryParse(text, out number))
                AddNumber(ref numbers, number);
            else
                Console.WriteLine("Я не знаю такой команды!");
        }
        
        static void AddNumber(ref int[]numbers,int number)
        {
            int[] newArray = new int[numbers.Length +1];

            for (int i = 0;i < numbers.Length;i++)
                newArray[i] = numbers[i];

            newArray[numbers.Length] = number;
            numbers = newArray;
        }

        static void RemuveNumber(ref int[] numbers)
        {
            int[] newArray = new int[numbers.Length -1];
            string userText;
            int index;
            bool IsInputIndex = false;

            while(IsInputIndex == false) 
            {
                Console.WriteLine("Введите индекс удаленного числа");
                userText = Console.ReadLine();

                if (int.TryParse((userText), out index))
                {
                    for (int i = 0; i < index;i++)
                        newArray[i] = numbers[i];
                    for (int i = index; i < newArray.Length; i++)
                        newArray[i] = numbers[(i + 1)];

                    IsInputIndex = true;
                }
                else 
                {
                    Console.WriteLine("Вы ввели не индекс!");
                }
            }

            numbers = newArray;
        }

        static void BubbleSort(ref int[] numbers)
        {
            int n = numbers.Length;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (numbers[j] > numbers[j + 1])
                    {
                        int temp = numbers[j];
                        numbers[j] = numbers[j + 1];
                        numbers[j + 1] = temp;
                    }
                }
            }
        }
    }
}

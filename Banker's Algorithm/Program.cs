using System;
using System.Collections.Generic;

namespace Banker_s_Algorithm
{
    class Program
    {
        static int IntputData(string message = "")
        {
            Console.Write(message);
            int el = 0;
            while (!int.TryParse(Console.ReadLine(), out el))
                Console.Write($"Некоректное значение!{Environment.NewLine}Попробуйте еще:");
            return el;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            int resource_count = IntputData("Введите кол-во ресурсов:");
            int[] resourse = new int[resource_count];
            for (int i = 0; i < resource_count; i++)
                resourse[i] = IntputData($"ресурс {i + 1}:");

            int process_count = IntputData("Введите кол-во процессов:");
            int[,] process = new int[process_count, resource_count * 2];
            for (int i = 0; i < process_count; i++)
            {
                Console.WriteLine($"{Environment.NewLine}Предоставлено ресурсов:");
                for (int j = 0; j < resource_count; j++)
                    process[i, j] = IntputData($"процесс {i + 1}, ресурс {j + 1}:");
                Console.WriteLine($"{Environment.NewLine}Максимальная потребность:");
                for (int j = resource_count; j < resource_count * 2; j++)
                    process[i, j] = IntputData($"процесс {i + 1}, ресурс {j - resource_count + 1}:");
            }

            int[,] allocated_resors_process = new int[resource_count, process_count];
            int[,] max_resors_process = new int[resource_count, process_count];

            Console.WriteLine($"{Environment.NewLine}Предоставлено ресурсов:");
            for (int j = 0; j < resource_count; j++)
                for (int i = 0; i < process_count; i++)
                    process[i, j] = IntputData($"процесс {i + 1}, ресурс {j + 1}:");

                



            Console.Write("Введите кол-во ресурсов:");

            Console.WriteLine("Введите потоки");
        }
    }
}

using System;
using System.Collections.Generic;

namespace Banker_s_Algorithm
{
    class Program
    {
        static int[,] FindNeed(int[,] max, int[,] alocation , int row, int cloumn)
        {
            int[,] need_resours = new int[row, cloumn];
            for (int i = 0; i < row; i++)
                for (int j = 0; j < cloumn; j++)
                    need_resours[i, j] = max[i, j] - alocation[i, j];

            return need_resours;  
        }

        static int IntIntput(string message = "")
        {
            Console.Write(message);
            int el = 0;
            while (!int.TryParse(Console.ReadLine(), out el))
                Console.Write($"Некоректное значение!{Environment.NewLine}Попробуйте еще:");
            return el;
        }

        static int[,] InputData(int resource_count, int process_count)
        {
            int[,] array = new int[resource_count, process_count];
            for (int j = 0; j < process_count; j++)
                for (int i = 0; i < resource_count; i++)                                   
                    array[i, j] = IntIntput($"-процесс A{j + 1}, ресурс R{i + 1}:");
            return array;
        }

        static int[] GetFreeResours(int[,] allocated_resors,int[] resourse, int resource_count, int process_count)
        {
            int[] free_resours = new int[resource_count];
            for (int i = 0; i < resource_count; i++)                
            {
                free_resours[i] = 0;
                for (int j = 0; j < process_count; j++)
                    free_resours[i] += resourse[i] - allocated_resors[i, j];
            }
            return free_resours;
        }

        static int GetNormalProcess()
        {
            int process_index;

        }

        static void PrintArray(int[,] array, int column, int row)
        {
            for (int j = 0; j < row; j++)
            {
                for (int i = 0; i < column; i++)
                    Console.Write($"{array[i, j]} ");
                Console.WriteLine();
            }
        }

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Hello World!");
                int resource_count = IntIntput("Введите кол-во ресурсов:");
                int[] resourse = new int[resource_count];
                for (int i = 0; i < resource_count; i++)
                    resourse[i] = IntIntput($"ресурс {i + 1}:");

                int process_count = IntIntput("Введите кол-во процессов:");

                Console.WriteLine($"{Environment.NewLine}Предоставлено ресурсов:");
                int[,] allocated_resors = InputData(resource_count, process_count);
                Console.WriteLine($"{Environment.NewLine}Максимальная потребность:");
                int[,] max_resors = InputData(resource_count, process_count);

                Console.WriteLine($"{Environment.NewLine}Предоставленные ресурсы:");
                PrintArray(allocated_resors, resource_count, process_count);
                Console.WriteLine($"{Environment.NewLine}Максимальные ресурсы:");
                PrintArray(max_resors, resource_count, process_count);

                Console.WriteLine($"{Environment.NewLine}Требуемые ресурсы:");
                int[,] need_resors = FindNeed(max_resors, allocated_resors, resource_count, process_count);
                PrintArray(need_resors, resource_count, process_count);

                int[] free_resourse = GetFreeResours(allocated_resors, resourse, resource_count, process_count);

            }
        }
    }
}

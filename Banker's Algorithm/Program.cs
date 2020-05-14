using System;

namespace Banker_s_Algorithm
{
    class Program
    {
        static int resource_count;
        static int process_count;
        static int[] resourse;
        static int[] free_resourse;
        static int[,] need_resors;
        static int[,] max_resors;
        static int[,] allocated_resors;
        static bool[] process_is_end;

        static int IntIntput(string message = "")
        {
            Console.Write(message);
            int el = 0;
            while (!int.TryParse(Console.ReadLine(), out el))
                Console.Write($"Некоректное значение!{Environment.NewLine}Попробуйте еще:");
            return el;
        }

        static int[,] FindNeed()
        {
            int[,] need_resours = new int[resource_count, process_count];
            for (int i = 0; i < resource_count; i++)
                for (int j = 0; j < process_count; j++)
                    need_resours[i, j] = max_resors[i, j] - allocated_resors[i, j];

            return need_resours;
        }        

        static int[,] InputData()
        {
            int[,] array = new int[resource_count, process_count];
            for (int j = 0; j < process_count; j++)
                for (int i = 0; i < resource_count; i++)
                    array[i, j] = IntIntput($"-процесс A{j + 1}, ресурс R{i + 1}:");
            return array;
        }

        static int[] GetFreeResours()
        {
            int[] free_resours = new int[resource_count];
            for (int i = 0; i < resource_count; i++)
            {
                free_resours[i] = resourse[i];
                for (int j = 0; j < process_count; j++)
                    free_resours[i] -= allocated_resors[i, j];
            }
            return free_resours;
        }

        static int GetNormalProcess()
        {
            int normal_resours_counter;
            for (int j = 0; j < process_count; j++) 
            {
                if (!process_is_end[j])
                {
                    normal_resours_counter = 0;
                    for (int i = 0; i < resource_count; i++)
                        if (need_resors[i, j] <= free_resourse[i])
                            normal_resours_counter++;

                    if (normal_resours_counter == resource_count)
                    {
                        for (int i = 0; i < resource_count; i++)
                            free_resourse[i] += allocated_resors[i, j];
                        process_is_end[j] = true;
                        return j;
                    }
                }                                   
            }
            return -1;
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
                Console.WriteLine($"Лабораторная работа номер 4 по ОС{Environment.NewLine}Автор: Осипов Игорь, 484гр");
                resource_count = IntIntput($"{Environment.NewLine}Введите кол-во ресурсов:");
                resourse = new int[resource_count];
                for (int i = 0; i < resource_count; i++)
                    resourse[i] = IntIntput($"ресурс {i + 1}:");

                process_count = IntIntput("Введите кол-во процессов:");

                Console.WriteLine($"{Environment.NewLine}Предоставлено ресурсов:");
                allocated_resors = InputData();
                Console.WriteLine($"{Environment.NewLine}Максимальная потребность:");
                max_resors = InputData();

                Console.WriteLine($"{Environment.NewLine}Предоставленные ресурсы:");
                PrintArray(allocated_resors, resource_count, process_count);
                Console.WriteLine($"{Environment.NewLine}Максимальные ресурсы:");
                PrintArray(max_resors, resource_count, process_count);

                Console.WriteLine($"{Environment.NewLine}Требуемые ресурсы:");
                need_resors = FindNeed();
                PrintArray(need_resors, resource_count, process_count);

                free_resourse = GetFreeResours();

                process_is_end = new bool[process_count];
                Array.Fill(process_is_end, false);
                int normal_process = 0;

                Console.WriteLine($"{Environment.NewLine}Процессы выполняются:");
                for (int i = 0; i < process_count; i++)
                {
                    normal_process = GetNormalProcess();
                    if (normal_process == -1)
                    {
                        Console.WriteLine("Опасное состояние:(");
                        break;
                    }
                    else
                        Console.WriteLine($"A{normal_process + 1}");                    
                }
                Console.WriteLine();
            }
        }           
    }
}

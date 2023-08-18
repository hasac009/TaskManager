using System;
using System.Diagnostics;

namespace TaskManager
{
    internal class TaskManager
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Выберите действие:");
                Console.WriteLine("1. Просмотреть список процессов");
                Console.WriteLine("2. Завершить процесс по ID");
                Console.WriteLine("3. Выход");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        DisplayProcesses();
                        break;

                    case "2":
                        TerminateProcess();
                        break;

                    case "3":
                        return;

                    default:
                        Console.WriteLine("Недопустимый выбор. Пожалуйста, выберите снова.");
                        break;
                }
            }
        }

        static void DisplayProcesses()
        {
            Process[] processes = Process.GetProcesses();

            Console.WriteLine("Список активных процессов:");
            Console.WriteLine("ID\tИмя процесса");

            foreach (Process process in processes)
            {
                Console.WriteLine($"{process.Id}\t{process.ProcessName}");
            }
        }

        static void TerminateProcess()
        {
            Console.Write("Введите ID процесса для завершения: ");
            int processId;

            if (int.TryParse(Console.ReadLine(), out processId))
            {
                try
                {
                    Process process = Process.GetProcessById(processId);
                    process.Kill();
                    Console.WriteLine($"Процесс с ID {processId} успешно завершен.");
                }
                catch (ArgumentException)
                {
                    Console.WriteLine($"Процесс с ID {processId} не найден.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка при завершении процесса: {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine("Неверный формат ID процесса.");
            }
        }
    }
}
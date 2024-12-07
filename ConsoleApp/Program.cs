using Pastel;
using System;
using System.Collections.Generic;

class TodoList 
{
    public static List<string> tasks = [];

    public static int GetTaskNumber(string task)
    {
        bool rightChoice = false;
        int taskIndex = 0;
        while (!rightChoice)
        {
            Console.Write($"Enter the task number to {task}: ");
            string? taskNumber = Console.ReadLine();
            taskNumber = taskNumber?.Trim().ToLower();
            Console.WriteLine(taskNumber);
            if (taskNumber == "first")
            {
                taskIndex = 0;
                rightChoice = true;
            } 
            else if (taskNumber == "last")
            {
                taskIndex = tasks.Count - 1;
                rightChoice = true;
            } 
            else if (int.TryParse(taskNumber, out taskIndex))
            {
                if (taskIndex > 0 && taskIndex <= tasks.Count)
                {
                    taskIndex--;
                    rightChoice = true;
                }
            } 
            else
            {
                Console.WriteLine("Invalid task number. Please enter a valid task number.");
            }
        }

        return taskIndex;
    }

    public static void AddTask()
    {
        Console.Write("Enter the task: ");
        string? task = Console.ReadLine();

        if (string.IsNullOrEmpty(task))
        {
            Console.WriteLine("Task cannot be empty. Please enter a valid task.");
        }
        else
        {
            tasks.Add(task);
        }
    }

    public static void RemoveTask()
    {
        int taskIndex = GetTaskNumber("remove");
        if (taskIndex >= 0 && taskIndex < tasks.Count)
        {
            tasks.RemoveAt(taskIndex);
        }
    }

    public static void EditTask()
    {
        int taskIndex = GetTaskNumber("edit");
        if (taskIndex >= 0 && taskIndex < tasks.Count)
        {
            Console.Write("Enter the new task: ");
            string? newTask = Console.ReadLine();
            if (string.IsNullOrEmpty(newTask))
            {
                Console.WriteLine("Task cannot be empty. Please enter a valid task.");
            }
            else
            {
                tasks[taskIndex] = newTask;
            }
        }
        else
        {
            Console.WriteLine("Invalid task number. Please enter a valid task number.");
        }
    }

    public static void ShowTasks()
    {
        Console.WriteLine();
        if (tasks.Count == 0)
        {
            Console.WriteLine("No tasks found!!".Pastel(ConsoleColor.Red));
        }
        else
        {
            Console.WriteLine("Tasks:".Pastel(ConsoleColor.Yellow));
            for (int i = 0; i < tasks.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {tasks[i]}".Pastel(ConsoleColor.Blue));
            }
        }
        Console.WriteLine();
    }

    static void Main(string[] args)
    {
        bool showConsole = true;
        while (showConsole)
        {
            Console.WriteLine("Welcome to your Console Todo List".Pastel(ConsoleColor.Green));
            Console.WriteLine("1. Add a task");
            Console.WriteLine("2. Remove a task");
            Console.WriteLine("3. Edit a task");
            Console.WriteLine("4. Show all tasks");
            Console.WriteLine("5. Exit");
            Console.Write("Enter your choice: ");
            string? choice = Console.ReadLine();
            bool rightChoice = int.TryParse(choice, out int result);
            
            if (rightChoice)
            {
                switch (result)
                {
                    case 1:
                        AddTask();
                        break;
                    case 2:
                        RemoveTask();
                        break;
                    case 3:
                        EditTask();
                        break;
                    case 4:
                        ShowTasks();
                        break;
                    case 5:
                        showConsole = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please enter a valid choice.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number corresponding to the options.");
            }

            Console.WriteLine();
        }
    }
}

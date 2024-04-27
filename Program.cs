// this is a console task manager application 
//Coded by Abdulhalim Muhammad on April 2023



using System;
using System.Collections.Generic;


// Create a new instance of TaskManager
TaskManager taskManager = new TaskManager();

// This is the main application loop
while (true)
{
    // Display menu options
    Console.WriteLine("Task Manager");
    Console.WriteLine("1. Add Task");
    Console.WriteLine("2. View Tasks");
    Console.WriteLine("3. View Task Description");
    Console.WriteLine("4. Mark Task as Completed");
    Console.WriteLine("5. Exit");
    Console.Write("Enter your choice: ");

    // this is where the the application will accept the user input as choice made by the user
    int choice;
    if (!int.TryParse(Console.ReadLine(), out choice))
    {
        Console.WriteLine("Invalid input. Please enter a number.");
        continue;
    }

    // this is where choices made by the user are processed 
    switch (choice)
    {
        case 1:
            // Add a new task
            Console.Write("Enter task name: ");
            string name = Console.ReadLine();
            Console.Write("Enter task description: ");
            string description = Console.ReadLine();
            Console.Write("Enter due date (YYYY-MM-DD): ");
            if (!DateTime.TryParse(Console.ReadLine(), out DateTime dueDate))
            {
                Console.WriteLine("Invalid date format. Please enter date in YYYY-MM-DD format.");
                break;
            }
            taskManager.AddTask(name, description, dueDate);
            Console.WriteLine("Task added successfully!");
            break;

        case 2:
            // View all tasks
            taskManager.DisplayTasks();
            break;

        case 3:
            // View task description
            Console.Write("Enter the index of the task to view description: ");
            if (!int.TryParse(Console.ReadLine(), out int descIndex))
            {
                Console.WriteLine("Invalid input. Please enter a number.");
                break;
            }
            taskManager.DisplayTaskDescription(descIndex - 1); // Index is displayed from 1 to the user, but internally it starts from 0
            break;

        case 4:
            // Mark a task as completed
            Console.Write("Enter the index of the task to mark as completed: ");
            if (!int.TryParse(Console.ReadLine(), out int index))
            {
                Console.WriteLine("Invalid input. Please enter a number.");
                break;
            }
            taskManager.MarkTaskAsCompleted(index - 1); // Index is displayed from 1 to the user, but internally it starts from 0
            break;

        case 5:
            // Exit the program
            break;

        default:
            // Invalid choice
            Console.WriteLine("Invalid choice. Please select a valid option.");
            break;
    }
}




class Task
{
    // Properties of a task
    public int taskID { get; set; }
    public string TaskName { get; set; }
    public string Description { get; set; }
    public DateTime DueDate { get; set; }
    public bool IsCompleted { get; set; }

    // Constructor to initialize a task
    public Task(string name, string description, DateTime dueDate)
    {
        TaskName = name;
        Description = description;
        DueDate = dueDate;
        IsCompleted = false;
    }

    // Method to mark a task as completed
    public void MarkAsCompleted()
    {
        IsCompleted = true;
    }

    // Override ToString method to customize string representation of a task
    public override string ToString()
    {
        return $"{TaskName} - Due: {DueDate.ToShortDateString()} - Completed: {(IsCompleted ? "Yes" : "No")}";
    }
}

// TaskManager class managing a collection of tasks
class TaskManager
{
    // List to hold tasks
    private List<Task> tasks = new List<Task>();

    // Method to add a new task
    public void AddTask(string name, string description, DateTime dueDate)
    {
        Task newTask = new Task(name, description, dueDate);
        tasks.Add(newTask);
    }

    // Method to display all tasks
    public void DisplayTasks()
    {
        Console.WriteLine("Tasks:");
        for (int i = 0; i < tasks.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {tasks[i].ToString()}");
        }
    }

    // Method to display description of a task
    public void DisplayTaskDescription(int index)
    {
        if (index >= 0 && index < tasks.Count)
        {
            Console.WriteLine($"Description of task '{tasks[index].TaskName}': {tasks[index].Description}");
        }
        else
        {
            Console.WriteLine("Invalid task index.");
        }
    }

    // Method to mark a task as completed
    public void MarkTaskAsCompleted(int index)
    {
        if (index >= 0 && index < tasks.Count)
        {
            tasks[index].MarkAsCompleted();
        }
        else
        {
            Console.WriteLine("Invalid task index.");
        }
    }
}



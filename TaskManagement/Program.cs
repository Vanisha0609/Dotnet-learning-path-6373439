using System;

class Task
{
    public int TaskId;
    public string TaskName;
    public string Status;
}

class Node
{
    public Task Data;
    public Node? Next;

    public Node(Task task)
    {
        Data = task;
        Next = null;
    }
}

class TaskLinkedList
{
    private Node? head = null;

    public void AddTask(Task task)
    {
        Node newNode = new Node(task);
        if (head == null)
        {
            head = newNode;
        }
        else
        {
            Node temp = head;
            while (temp.Next != null)
                temp = temp.Next;
            temp.Next = newNode;
        }
        Console.WriteLine("Task added successfully.");
    }

    public void TraverseTasks()
    {
        if (head == null)
        {
            Console.WriteLine("No tasks to display.");
            return;
        }

        Node temp = head;
        while (temp != null)
        {
            Console.WriteLine($"ID: {temp.Data.TaskId}, Name: {temp.Data.TaskName}, Status: {temp.Data.Status}");
            temp = temp.Next;
        }
    }

    public void SearchTask(int taskId)
    {
        Node? temp = head;
        while (temp != null)
        {
            if (temp.Data.TaskId == taskId)
            {
                Console.WriteLine($"Found Task: ID: {temp.Data.TaskId}, Name: {temp.Data.TaskName}, Status: {temp.Data.Status}");
                return;
            }
            temp = temp.Next;
        }
        Console.WriteLine("Task not found.");
    }

    public void DeleteTask(int taskId)
    {
        if (head == null)
        {
            Console.WriteLine("List is empty.");
            return;
        }

        if (head.Data.TaskId == taskId)
        {
            head = head.Next;
            Console.WriteLine("Task deleted.");
            return;
        }

        Node current = head;
        while (current.Next != null)
        {
            if (current.Next.Data.TaskId == taskId)
            {
                current.Next = current.Next.Next;
                Console.WriteLine("Task deleted.");
                return;
            }
            current = current.Next;
        }

        Console.WriteLine("Task not found.");
    }
}

class Program
{
    static void Main()
    {
        TaskLinkedList taskList = new TaskLinkedList();
        while (true)
        {
            Console.WriteLine("\n--- Task Management System ---");
            Console.WriteLine("1. Add Task");
            Console.WriteLine("2. Search Task");
            Console.WriteLine("3. List Tasks");
            Console.WriteLine("4. Delete Task");
            Console.WriteLine("5. Exit");
            Console.Write("Enter choice: ");
            int choice = int.Parse(Console.ReadLine()!);

            switch (choice)
            {
                case 1:
                    Task t = new Task();
                    Console.Write("Enter Task ID: ");
                    t.TaskId = int.Parse(Console.ReadLine()!);
                    Console.Write("Enter Task Name: ");
                    t.TaskName = Console.ReadLine()!;
                    Console.Write("Enter Status: ");
                    t.Status = Console.ReadLine()!;
                    taskList.AddTask(t);
                    break;

                case 2:
                    Console.Write("Enter Task ID to search: ");
                    int searchId = int.Parse(Console.ReadLine()!);
                    taskList.SearchTask(searchId);
                    break;

                case 3:
                    taskList.TraverseTasks();
                    break;

                case 4:
                    Console.Write("Enter Task ID to delete: ");
                    int deleteId = int.Parse(Console.ReadLine()!);
                    taskList.DeleteTask(deleteId);
                    break;

                case 5:
                    return;

                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
    }
}


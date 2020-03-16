using ResumeBase.Model;
using ResumeBase.storage;
using System;


namespace ResumeBase.Driver
{
    class MainSortedArray
    {
        private readonly static SortedArrayStorage ARRAY_STORAGE = new SortedArrayStorage();
        static void Main()
        {
            while (true)
            {
                Console.Write("Please enter the command (list | save uuid | delete uuid | get uuid | update | clear | exit): ");
                String[] input = Console.ReadLine().Trim().ToLower().Split(" ");
                if (input.Length < 1 || input.Length > 2)
                {
                    Console.WriteLine("Illegal command.");
                    continue;
                }
                String uuid = null;
                if (input.Length == 2)
                {
                    uuid = String.Intern(input[1]);
                }
                switch (input[0])
                {
                    case "list":
                        PrintAll();
                        break;
                    case "size":
                        Console.WriteLine(ARRAY_STORAGE.Count());
                        break;
                    case "save":
                        ARRAY_STORAGE.Save(new Resume(uuid));
                        PrintAll();
                        break;
                    case "delete":
                        ARRAY_STORAGE.Delete(uuid);
                        PrintAll();
                        break;
                    case "get":
                        Console.WriteLine(ARRAY_STORAGE.Get(uuid));
                        break;
                    case "update":
                        ARRAY_STORAGE.Update(new Resume(uuid));
                        PrintAll();
                        break;
                    case "clear":
                        ARRAY_STORAGE.Clear();
                        PrintAll();
                        break;
                    case "exit":
                        return;
                    default:
                        Console.WriteLine("Illegal command.");
                        break;
                }
            }

        }

        static void PrintAll()
        {
            Resume[] all = ARRAY_STORAGE.GetAll();
            Console.WriteLine("----------------------------");
            if (all.Length == 0)
            {
                Console.WriteLine("Empty");
            }
            else
            {
                foreach (Resume resume in all)
                {
                    Console.WriteLine(resume);
                }
            }
            Console.WriteLine("----------------------------");
        }
    }
}

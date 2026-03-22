using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Console.WriteLine("Welcome to my Contact List");

        bool running = true;

        List<int> ids = new List<int>();

        Dictionary<int, string> names = new Dictionary<int, string>();
        Dictionary<int, string> lastnames = new Dictionary<int, string>();
        Dictionary<int, string> addresses = new Dictionary<int, string>();
        Dictionary<int, string> phones = new Dictionary<int, string>();
        Dictionary<int, string> emails = new Dictionary<int, string>();
        Dictionary<int, int> ages = new Dictionary<int, int>();
        Dictionary<int, bool> bestFriends = new Dictionary<int, bool>();

        while (running)
        {
            Console.WriteLine("1. Add Contact");
            Console.WriteLine("2. Show Contacts");
            Console.WriteLine("3. Search Contact");
            Console.WriteLine("4. Edit Contact");
            Console.WriteLine("5. Delete Contact");
            Console.WriteLine("6. Exit");

            Console.WriteLine("Choose option:");

            int option = 0;

            try
            {
                option = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Only numbers!");
                continue;
            }

            switch (option)
            {
                case 1:
                    AddContact(ids, names, lastnames, addresses, phones, emails, ages, bestFriends);
                    break;

                case 2:
                    ShowContacts(ids, names, lastnames, addresses, phones, emails, ages, bestFriends);
                    break;

                case 3:
                    SearchContact(ids, names, lastnames, phones, emails);
                    break;

                case 4:
                    EditContact(ids, names, lastnames, addresses, phones, emails, ages, bestFriends);
                    break;

                case 5:
                    DeleteContact(ids, names, lastnames, addresses, phones, emails, ages, bestFriends);
                    break;

                case 6:
                    running = false;
                    Console.WriteLine("Bye!");
                    break;

                default:
                    Console.WriteLine("Wrong option");
                    break;
            }
        }
    }

    static void AddContact(List<int> ids, Dictionary<int, string> names,
        Dictionary<int, string> lastnames, Dictionary<int, string> addresses,
        Dictionary<int, string> phones, Dictionary<int, string> emails,
        Dictionary<int, int> ages, Dictionary<int, bool> bestFriends)
    {
        Console.WriteLine("Enter name:");
        string name = Console.ReadLine();

        Console.WriteLine("Enter lastname:");
        string lastname = Console.ReadLine();

        Console.WriteLine("Enter address:");
        string address = Console.ReadLine();

        Console.WriteLine("Enter phone:");
        string phone = Console.ReadLine();

        Console.WriteLine("Enter email:");
        string email = Console.ReadLine();

        Console.WriteLine("Enter age:");
        int age = 0;

        try
        {
            age = Convert.ToInt32(Console.ReadLine());
        }
        catch
        {
            Console.WriteLine("Invalid Age");
            return;
        }

        Console.WriteLine("Best friend? 1 = Yes, 2 = No");
        bool isBestFriend = false;

        try
        {
            isBestFriend = Convert.ToInt32(Console.ReadLine()) == 1;
        }
        catch
        {
            Console.WriteLine("Invalid answer");
            return;
        }

        int id = ids.Count + 1;
        ids.Add(id);

        names[id] = name;
        lastnames[id] = lastname;
        addresses[id] = address;
        phones[id] = phone;
        emails[id] = email;
        ages[id] = age;
        bestFriends[id] = isBestFriend;

        Console.WriteLine("Contact added!");
    }

    static void ShowContacts(List<int> ids, Dictionary<int, string> names,
        Dictionary<int, string> lastnames, Dictionary<int, string> addresses,
        Dictionary<int, string> phones, Dictionary<int, string> emails,
        Dictionary<int, int> ages, Dictionary<int, bool> bestFriends)
    {
        if (ids.Count == 0)
        {
            Console.WriteLine("No contacts");
            return;
        }

        foreach (int id in ids)
        {
            string best = bestFriends[id] ? "Yes" : "No";

            Console.WriteLine($"|Id:{id} | Name:{names[id]} |Lastname: {lastnames[id]} |Phone number: {phones[id]} |Email: {emails[id]} | Age: {ages[id]} | is your Best Friend: {best}");
        }
    }

    static void SearchContact(List<int> ids, Dictionary<int, string> names,
        Dictionary<int, string> lastnames, Dictionary<int, string> addresses,
        Dictionary<int, string> phones, Dictionary<int, string> emails,
        Dictionary<int, int> ages, Dictionary<int, bool> bestFriends)
    {
        Console.WriteLine("Enter ID to search:");

        int id = 0;

        try
        {
            id = Convert.ToInt32(Console.ReadLine());
        }
        catch
        {
            Console.WriteLine("Invalid ID");
            return;
        }

        if (names.ContainsKey(id))
        {
            Console.WriteLine($"|Id:{id} | Name:{names[id]} |Lastname: {lastnames[id]} |Phone number: {phones[id]} |Email: {emails[id]} | Age: {ages[id]} | is your Best Friend: {bestFriends}");
        }
        else
        {
            Console.WriteLine("Contact not found");
        }
    }

    static void EditContact(List<int> ids, Dictionary<int, string> names,
        Dictionary<int, string> lastnames, Dictionary<int, string> addresses,
        Dictionary<int, string> phones, Dictionary<int, string> emails,
        Dictionary<int, int> ages, Dictionary<int, bool> bestFriends)
    {
        Console.WriteLine("Enter ID to edit:");

        int id = 0;

        try
        {
            id = Convert.ToInt32(Console.ReadLine());
        }
        catch
        {
            Console.WriteLine("Invalid ID");
            return;
        }

        if (!names.ContainsKey(id))
        {
            Console.WriteLine("ID not found");
            return;
        }

        Console.WriteLine("New name:");
        names[id] = Console.ReadLine();

        Console.WriteLine("New lastname:");
        lastnames[id] = Console.ReadLine();

        Console.WriteLine("New address:");
        addresses[id] = Console.ReadLine();

        Console.WriteLine("New phone:");
        phones[id] = Console.ReadLine();

        Console.WriteLine("New email:");
        emails[id] = Console.ReadLine();

        Console.WriteLine("New age:");
        try
        {
            ages[id] = Convert.ToInt32(Console.ReadLine());
        }
        catch
        {
            Console.WriteLine("Wrong age, keeping old");
        }

        Console.WriteLine("Best friend? 1 = Yes, 2 = No");
        try
        {
            bestFriends[id] = Convert.ToInt32(Console.ReadLine()) == 1;
        }
        catch
        {
            Console.WriteLine("Wrong option, keeping old");
        }

        Console.WriteLine("Contact updated!");
    }

    static void DeleteContact(List<int> ids, Dictionary<int, string> names,
        Dictionary<int, string> lastnames, Dictionary<int, string> addresses,
        Dictionary<int, string> phones, Dictionary<int, string> emails,
        Dictionary<int, int> ages, Dictionary<int, bool> bestFriends)
    {
        Console.WriteLine("Enter ID to delete:");

        int id = 0;

        try
        {
            id = Convert.ToInt32(Console.ReadLine());
        }
        catch
        {
            Console.WriteLine("Invalid ID");
            return;
        }

        if (names.ContainsKey(id))
        {
            ids.Remove(id);
            names.Remove(id);
            lastnames.Remove(id);
            addresses.Remove(id);
            phones.Remove(id);
            emails.Remove(id);
            ages.Remove(id);
            bestFriends.Remove(id);

            Console.WriteLine("Deleted!");
        }
        else
        {
            Console.WriteLine("ID not found");
        }
    }
}
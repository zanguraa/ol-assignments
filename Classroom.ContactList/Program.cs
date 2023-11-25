namespace Classroom.ContactList
{
    internal class Program
    {
        private static ContactManager _contactManager = new ContactManager();
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("\nWelcome to your Contact List.\r\n");
                Console.WriteLine("Please choose an option:\r\n1. Add Contact\r\n2. View All Contacts\r\n3. Search Contacts\r\n4. Exit");
                var userResponse = Console.ReadLine();
                UserChoice(userResponse);
                if (userResponse == "Exit")
                {
                    break;
                }
            }
        }
        static void UserChoice(string args)
        {
            switch (args)
            {
                case "1":
                    AddContact();
                    break;
                case "2":
                    ShowAllContact();
                    break;
                case "3":
                    Console.WriteLine("Search Contacts");
                    break;
                case "4":
                    Console.WriteLine("Exit");
                    break;
            }
        }
        private static void AddContact()
        {
            Console.WriteLine("Enter the contact's name:");
            var userName = Console.ReadLine();
            Console.WriteLine("Enter the contact's phone number:");
            var userPhoneNumber = Console.ReadLine();
            Console.WriteLine("Enter the contact's email:");
            var userEmail = Console.ReadLine();
            _contactManager.AddContact(userName, userPhoneNumber, userEmail);
        }
        private static void ShowAllContact()
        {
            _contactManager.GetContacts();
        }

    }
}
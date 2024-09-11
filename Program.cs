using System;
class Program
{
    static public void Main()
    {
        Console.WriteLine("Hi!\n Welcome to our online device store!");
        bool choice = true;
        int num;
        Console.WriteLine("If you are a customer, enter 1, if you are an employee, enter 2");
        num = int.Parse(Console.ReadLine());
        do
        {
            if (num == 1)
            {
                Customer customer = new Customer();
                string value;
                Console.WriteLine("To register, enter \'reg\', to authorize - \'auth\'");
                value = Console.ReadLine();
                if (value.ToLower() == "reg")
                {
                    customer.Register();
                }
                else if (value.ToLower() == "auth")
                {
                    Console.WriteLine("Enter your email");
                    string email = Console.ReadLine();
                    bool ch = customer.Authenticate(email);
                    if (ch)
                    {
                        do
                        {
                            Console.WriteLine("Enter 1 to sort all devices information by name");
                            Console.WriteLine("Enter 2 to sort all devices information by price");
                            Console.WriteLine("Enter 3 to sort phone information by name");
                            Console.WriteLine("Enter 4 to sort phone information by price");
                            Console.WriteLine("Enter 5 to sort laptop information by name");
                            Console.WriteLine("Enter 6 to sort laptop information by price");
                            Console.WriteLine("Enter 7 to exit");
                            int number = int.Parse(Console.ReadLine());
                            switch (number)
                            {
                                case 1:
                                    {
                                        Phone phone = new Phone();
                                        phone.SortByName("alldevices.txt");
                                    }
                                    break;
                                case 2:
                                    {
                                        Phone phone = new Phone();
                                        phone.SortByPrice("alldevices.txt");
                                    }
                                    break;
                                case 3:
                                    {
                                        Phone phone = new Phone();
                                        phone.SortByName("phones.txt");
                                    }
                                    break;
                                case 4:
                                    {
                                        Phone phone = new Phone();
                                        phone.SortByPrice("phones.txt");
                                    }
                                    break;
                                case 5:
                                    {
                                        Laptop laptop = new Laptop();
                                        laptop.SortByName("laptops.txt");
                                    }
                                    break;
                                case 6:
                                    {
                                        Laptop laptop = new Laptop();
                                        laptop.SortByPrice("laptops.txt");
                                    }
                                    break;
                                case 7:
                                    {
                                        return;
                                    }
                                    break;
                            }
                        } while (true);
                    }
                    else Console.WriteLine("Password entered incorrectly! \a");
                }
                else
                {
                    Console.WriteLine("Input error! \a");
                }
            }
            else if (num == 2)
            {
                Employee employee = new Employee();
                string value;
                Console.WriteLine("To register, enter \'reg\', to authorize - \'auth\'");
                value = Console.ReadLine();
                if (value.ToLower() == "reg")
                {
                    employee.Register();
                }
                else if (value.ToLower() == "auth")
                {
                    Console.WriteLine("Enter your email");
                    string email = Console.ReadLine();
                    bool ch = employee.Authenticate(email);
                    Console.WriteLine("Enter employee code");
                    int code = int.Parse(Console.ReadLine());
                    string[] employeecode = File.ReadAllText(email + ".txt").Split(',');
                    if (ch && code.ToString() == employeecode[2])
                    {
                        Console.WriteLine("Enter \'phone\' if you want to add information about your phone,\n" +
                            "enter \'laptop\' for your laptop, and \'ex\' to exit");
                        string nameOfChoice = Console.ReadLine();
                        if (nameOfChoice.ToLower() == "phone")
                        {
                            do
                            {
                                string ph = "phones.txt";
                                Phone phone = new Phone();
                                Console.WriteLine("Enter 1 to add information about the new phone");
                                Console.WriteLine("Enter 2 to delete phone information");
                                Console.WriteLine("Enter 3 to find phone information");
                                Console.WriteLine("Enter 4 to sort phone information by name");
                                Console.WriteLine("Enter 5 to sort phone information by price");
                                Console.WriteLine("Enter 6 to exit");
                                int number = int.Parse(Console.ReadLine());
                                switch (number)
                                {
                                    case 1:
                                        {
                                            phone.AddDev();
                                        }
                                        break;
                                    case 2:
                                        {
                                            phone.DeleteDev();
                                        }
                                        break;
                                    case 3:
                                        {
                                            phone.FindDev();
                                        }
                                        break;
                                    case 4:
                                        {
                                            phone.SortByName(ph);
                                        }
                                        break;
                                    case 5:
                                        {
                                            phone.SortByPrice(ph);
                                        }
                                        break;
                                    case 6:
                                        {
                                            return;
                                        }
                                        break;
                                }
                            } while (true);
                        }
                        else if (nameOfChoice.ToLower() == "laptop")
                        {
                            do
                            {
                                string lp = "laptops.txt";
                                Laptop laptop = new Laptop();
                                Console.WriteLine("Enter 1 to add information about the new laptop");
                                Console.WriteLine("Enter 2 to delete laptop information");
                                Console.WriteLine("Enter 3 to find laptop information");
                                Console.WriteLine("Enter 4 to sort laptop information by name");
                                Console.WriteLine("Enter 5 to sort laptop information by price");
                                Console.WriteLine("Enter 6 to exit");
                                int number = int.Parse(Console.ReadLine());
                                switch (number)
                                {
                                    case 1:
                                        {
                                            laptop.AddDev();
                                        }
                                        break;
                                    case 2:
                                        {
                                            laptop.DeleteDev();
                                        }
                                        break;
                                    case 3:
                                        {
                                            laptop.FindDev();
                                        }
                                        break;
                                    case 4:
                                        {
                                            laptop.SortByName(lp);
                                        }
                                        break;
                                    case 5:
                                        {
                                            laptop.SortByPrice(lp);
                                        }
                                        break;
                                    case 6:
                                        {
                                            return;
                                        }
                                        break;
                                }
                            } while (true);
                        }
                        else if (nameOfChoice.ToLower() == "ex")
                        {
                            choice = false;
                        }
                        else Console.WriteLine("Input error! \a");
                    }
                    else Console.WriteLine("Password entered incorrectly! \a");
                }
                else
                {
                    Console.WriteLine("Input error! \a");
                }
            }
            else Console.WriteLine("Input error! \a");
        } while (choice);
    }
}

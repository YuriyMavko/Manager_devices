using System;
using System.IO;
using System.Text.RegularExpressions;
public class Customer : User
{
    public string ShippingAddress { get; set; }
    public string PaymentMethod { get; set; }

    public override void Register()
    {
        Regex emailRegex = new Regex(@"[A-Za-z]+[\. A-Za-z0-9 _-]*[A-Za-z0-9]+@[A-Za-z]+\.[A-Za-z]+");
        do
        {
            Console.WriteLine("Enter your email");
            Email = Console.ReadLine();

            if (emailRegex.IsMatch(Email))
            {
                Console.WriteLine("Email is valid.");
                break;
            }
            else
            {
                Console.WriteLine("Invalid email. Please enter a valid email address.");
            }
        } while (true);
        Console.WriteLine("Create your password");
        Password = Console.ReadLine();
        Console.WriteLine("Enter your shipping address");
        ShippingAddress = Console.ReadLine();
        Console.WriteLine("Enter your payment method");
        PaymentMethod = Console.ReadLine();
        try
        {
            using (StreamWriter writer = new StreamWriter($"{Email}.txt"))
            {
                writer.WriteLine($"{Email},{Password},{ShippingAddress},{PaymentMethod}");
            }
            Console.WriteLine("Customer registered successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error registering customer: {ex.Message}");
        }
    }
}
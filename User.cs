using System;
using System.IO;
using System.Text.RegularExpressions;
public abstract class User
{
    public string Email { get; set; }
    public string Password { get; set; }

    public abstract void Register();
    public bool Authenticate(string email)
    {
        bool value;
        Regex emailRegex = new Regex(@"[A-Za-z]+[\. A-Za-z0-9 _-]*[A-Za-z0-9]+@[A-Za-z]+\.[A-Za-z]+");
        do
        {

            if (emailRegex.IsMatch(email))
            {
                break;
            }
            else
            {
                Console.WriteLine("Invalid email. Please enter a valid email address.");
            }
        } while (true);
        string filePath = email + ".txt";
        if (File.Exists(filePath))
        {
            Console.WriteLine("Enter password:");
            string password = Console.ReadLine();

            string[] storedPassword = File.ReadAllText(filePath).Split(',');

            if (password == storedPassword[1])
            {
                value = true;
            }
            else
            {
                value = false;
            }
        }
        else
        {
            value = false;
        }
        return value;
    }
}

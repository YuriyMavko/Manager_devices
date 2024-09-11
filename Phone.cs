using System;
using System.Collections.Generic;
using System.IO;
public class Phone : Device
{
    string ph = "phones.txt";
    public string OperatingSystem { get; set; }
    public int Memory { get; set; }
    public string Processor { get; set; }

    public override void AddDev()
    {
        Console.WriteLine("Enter the name of the device");
        string fileName = Console.ReadLine();
        Name = fileName;

        Console.WriteLine($"Enter price {Name}");
        string priceInput = Console.ReadLine();
        if (!string.IsNullOrEmpty(priceInput))
        {
            if (decimal.TryParse(priceInput, out decimal price))
            {
                Price = price;
            }
            else
            {
                Console.WriteLine("Invalid price format. Please enter a valid decimal value.");
                return;
            }
        }
        else
        {
            Console.WriteLine("Price cannot be empty. Please enter a valid decimal value.");
            return;
        }

        Console.WriteLine($"Enter operating system {Name}");
        OperatingSystem = Console.ReadLine();

        Console.WriteLine($"Enter memory {Name}");
        string memoryInput = Console.ReadLine();
        if (!string.IsNullOrEmpty(memoryInput))
        {
            if (int.TryParse(memoryInput, out int memory))
            {
                Memory = memory;
            }
            else
            {
                Console.WriteLine("Invalid memory format. Please enter a valid integer value.");
                return;
            }
        }
        else
        {
            Console.WriteLine("Memory cannot be empty. Please enter a valid integer value.");
            return;
        }

        Console.WriteLine($"Enter processor {Name}");
        Processor = Console.ReadLine();

        fileName += ".txt";
        try
        {
            using (StreamWriter writer = new StreamWriter(fileName, true))
            {
                writer.WriteLine($"{Name},{Price},{OperatingSystem},{Memory},{Processor}");
            }
            using (StreamWriter writer = new StreamWriter(allDevices, true))
            {
                writer.WriteLine($"{Name},{Price},{OperatingSystem},{Memory},{Processor}");
            }
            using (StreamWriter writer = new StreamWriter(ph, true))
            {
                writer.WriteLine($"{Name},{Price},{OperatingSystem},{Memory},{Processor}");
            }
            Console.WriteLine("Phone details saved to file successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving phone details to file: {ex.Message}");
        }
    }
    public override void FindDev()
    {
        Console.WriteLine("Enter the name of the device");
        string fileName = Console.ReadLine();
        string DeviceName = fileName;
        fileName += ".txt";
        try
        {
            string[] lines = File.ReadAllLines(fileName);
            foreach (string line in lines)
            {
                if (line.StartsWith(DeviceName))
                {
                    string[] details = line.Split(',');
                    Console.WriteLine($"Device: {details[0]}");
                    Console.WriteLine($"Price: {details[1]}");
                    Console.WriteLine($"Operating System: {details[2]}");
                    Console.WriteLine($"Memory: {details[3]}");
                    Console.WriteLine($"Processor: {details[4]}");
                    return;
                }
            }
            Console.WriteLine($"Device '{DeviceName}' not found.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error finding device information: {ex.Message}");
        }
    }
}
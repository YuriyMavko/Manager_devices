using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using System.Runtime.Serialization.Json;
public class Laptop : Device
{
    string lp = "laptops.txt";
    public double ScreenSize { get; set; }
    public int Ram { get; set; }
    public string BatterySpece { get; set; }

    public override void AddDev()
    {
        Console.WriteLine("Enter the name of the device");
        string fileName = Console.ReadLine();
        Console.WriteLine($"Enter price for {fileName}");
        decimal price;
        if (!decimal.TryParse(Console.ReadLine(), out price))
        {
            Console.WriteLine("Invalid price format. Please enter a valid decimal number.");
            return;
        }
        Console.WriteLine($"Enter screen size for {fileName}");
        double screenSize;
        if (!double.TryParse(Console.ReadLine(), out screenSize))
        {
            Console.WriteLine("Invalid screen size format. Please enter a valid decimal number.");
            return;
        }
        Console.WriteLine($"Enter RAM for {fileName}");
        int ram;
        if (!int.TryParse(Console.ReadLine(), out ram))
        {
            Console.WriteLine("Invalid RAM format. Please enter a valid integer number.");
            return;
        }
        Console.WriteLine($"Enter battery space for {fileName}");
        string batterySpace = Console.ReadLine();

        try
        {
            using (StreamWriter writer = new StreamWriter($"{fileName}.txt", true))
            {
                writer.WriteLine($"{fileName}, {price}, {screenSize}, {ram}, {batterySpace}");
            }
            using (StreamWriter writer = new StreamWriter(allDevices, true))
            {
                writer.WriteLine($"{fileName}, {price}, {screenSize}, {ram}, {batterySpace}");
            }
            using (StreamWriter writer = new StreamWriter(lp, true))
            {
                writer.WriteLine($"{fileName}, {price}, {screenSize}, {ram}, {batterySpace}");
            }
            Console.WriteLine($"{fileName} details saved to file successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving {fileName} details to file: {ex.Message}");
        }
        //serialization json
        Laptop lapt = new Laptop
        {
            Name = fileName,
            Price = price,
            ScreenSize = screenSize,
            Ram = ram,
            BatterySpece = batterySpace
        };

        try
        {
            string lappath = "laptop_" + fileName + ".json";

            string json = JsonConvert.SerializeObject(lapt);
            using (StreamWriter writer = new StreamWriter(lappath, true))
            {
                if (new FileInfo(lappath).Length > 0) 
                    writer.Write(","); 

                writer.Write(json);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving {fileName} details to file: {ex.Message}");
        }
    }

    public override void FindDev()
    {
        Console.WriteLine("Enter the name of the device");
        string fileName = Console.ReadLine();
        string namefile = fileName;
        fileName += ".txt";
        try
        {
            using (StreamReader reader = new StreamReader(fileName))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split(',');
                    if (parts.Length >= 1 && parts[0] == namefile)
                    {
                        string[] details = line.Split(',');
                        Console.WriteLine($"Device: {details[0]}");
                        Console.WriteLine($"Price: {details[1]}");
                        Console.WriteLine($"Screen size: {details[2]}");
                        Console.WriteLine($"RAM: {details[3]}");
                        Console.WriteLine($"Battery space: {details[4]}");
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error finding device in file: {ex.Message}");
        }
        Console.WriteLine("Do you want to deserialize? - enter yes");
        string choice = Console.ReadLine();
        if (choice == "yes")
        {
            try
            {
                Laptop laptop = new Laptop();
                string lappath = "laptop_" + namefile + ".json";
                string json = File.ReadAllText(lappath);
                laptop = JsonConvert.DeserializeObject<Laptop>(json);
                if (laptop.Name == namefile)
                {
                    Console.WriteLine($"Device: {laptop.Name}");
                    Console.WriteLine($"Price: {laptop.Price}");
                    Console.WriteLine($"Screen size: {laptop.ScreenSize}");
                    Console.WriteLine($"RAM: {laptop.Ram}");
                    Console.WriteLine($"Battery space: {laptop.BatterySpece}");
                }
                else
                {
                    Console.WriteLine($"Device with name {namefile} not found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error finding or deserializing device: {ex.Message}");
            }
        }

    }
}

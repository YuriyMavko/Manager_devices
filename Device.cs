using System;
using System.Collections.Generic;
using System.IO;
public abstract class Device
{
    public string allDevices = "alldevices.txt";
    public string Name { get; set; }
    public decimal Price { get; set; }

    public abstract void AddDev();
    public void SortByPrice(string filePath)
    {
        try
        {
            string[] lines = File.ReadAllLines(filePath);
            List<string[]> phoneDetails = new List<string[]>();
            foreach (string line in lines)
            {
                string[] details = line.Split(',');
                phoneDetails.Add(details);
            }

            Console.WriteLine("If you want to sort the data by ascending price, enter 1,\n" +
                "if by descending price, enter 2:");
            int num = int.Parse(Console.ReadLine());

            if (num == 1)
                phoneDetails.Sort((x, y) => Convert.ToInt32(x[1]).CompareTo(Convert.ToInt32(y[1])));
            else if (num == 2)
                phoneDetails.Sort((x, y) => Convert.ToInt32(y[1]).CompareTo(Convert.ToInt32(x[1])));
            else
            {
                Console.WriteLine("Input error!");
                return;
            }

            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (string[] details in phoneDetails)
                {
                    writer.WriteLine(string.Join(",", details));
                }
            }

            Console.WriteLine("Phone details sorted and saved to file successfully.");
            string[] sortedLines = File.ReadAllLines(filePath);
            Console.WriteLine("Sorted data in the file:");
            foreach (string sortedLine in sortedLines)
            {
                Console.WriteLine(sortedLine);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }

    public void SortByName(string filePath)
    {
        try
        {
            string[] lines = File.ReadAllLines(filePath);
            List<string[]> phoneDetails = new List<string[]>();
            foreach (string line in lines)
            {
                string[] details = line.Split(',');
                phoneDetails.Add(details);
            }
            phoneDetails.Sort((x, y) => x[0].CompareTo(y[0]));

            string tempFilePath = Path.GetTempFileName(); 

            using (StreamWriter writer = new StreamWriter(tempFilePath))
            {
                foreach (string[] details in phoneDetails)
                {
                    writer.WriteLine(string.Join(",", details));
                }
            }

            File.Replace(tempFilePath, filePath, null);

            Console.WriteLine("Phone details sorted by name and saved to file successfully.");
            string[] sortedLines = File.ReadAllLines(filePath);
            Console.WriteLine("Sorted data in the file:");
            foreach (string sortedLine in sortedLines)
            {
                Console.WriteLine(sortedLine);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error sorting and saving phone details by name to file: {ex.Message}");
        }
    }
    public void DeleteDev()
    {
        Console.WriteLine("Enter the name of the device");
        string fileName = Console.ReadLine();
        string DeviceName = fileName;
        fileName += ".txt";
        try
        {
            string[] lines = File.ReadAllLines(fileName);
            using (StreamWriter writer = new StreamWriter(fileName))
            {
                foreach (string line in lines)
                {
                    if (!line.StartsWith(DeviceName))
                    {
                        writer.WriteLine(line);
                    }
                }
            }
            if (new FileInfo(fileName).Length == 0)
            {
                File.Delete(fileName);
                Console.WriteLine($"File {fileName} deleted successfully.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error deleting phone details: {ex.Message}");
        }
    }
    public abstract void FindDev();
}

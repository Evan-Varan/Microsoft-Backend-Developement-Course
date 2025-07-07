using System;
using System.IO;
using System.Threading.Tasks;
class DelayedWorker
{
    public async Task SimulateDelay()
    {
        await Task.Delay(5000); //waits for 5 seconds then prints
        Console.WriteLine("operation completed after 5 seconds.");
    }
}

class DelayedFileReader
{
    public async Task ReadFileAsync(string filePath)
    {
        using (StreamReader reader = new StreamReader(filePath))
        {
            string content = await
            reader.ReadFileAsync("example.txt");
        }
        Console.WriteLine(content);
    }
}

class APIReader
{
    public async Task GetDataFromMultipleSources()
    {
        Task<string> data1 = GetDataFromApiAsync("https://api.example.com/data1");
        Task<string> data2 = GetDataFromApiAsync("https://api.example.com/data1"); //Dummy Async Methods
        await Task.WhenAll(data1, data2); //Waits for both tasks to finish
        Console.WriteLine(data1.Result);
        Console.WriteLine(data2.Result);
    }
}
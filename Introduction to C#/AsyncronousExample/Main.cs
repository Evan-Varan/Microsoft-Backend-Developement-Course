using System;
using System.Threading.Tasks;

/* Note this code is sudocode and will not build properly */
class Program
{
    static async Task Main() // Main must be async to call an async method
    {
        Console.WriteLine("Hello, World!");

        /*Example One */
        var worker = new DelayedWorker(); // Worker instantiation
        await worker.SimulateDelay(); //Call the delay method

        /*Example Two */
        var fileReader = new DelayedFileReader();
        await fileReader.ReadFileAsync();

        /*Example Three (Multiple Async Calls) */
        var apiReader = new APIReader();
        await APIReader.GetDataFromMultipleSources();
    }
}



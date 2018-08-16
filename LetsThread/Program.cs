using System;
using System.Threading;
using System.Threading.Tasks;

namespace LetsThread
{
    class Program
    {
        static void Main(string[] args)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            MainAsync(args).GetAwaiter().GetResult();
            watch.Stop();
            Console.WriteLine($"Async time: {watch.ElapsedMilliseconds}");

            watch = System.Diagnostics.Stopwatch.StartNew();
            var threadedClass = new ThreadClass();
            threadedClass.DownloadSomeSites();
            watch.Stop();
            Console.WriteLine($"Sync time: {watch.ElapsedMilliseconds}");

            watch = System.Diagnostics.Stopwatch.StartNew();
            var threadedClassMultiThread = new ThreadClass();
            threadedClass.DownloadSomeSitesMultiThread();
            watch.Stop();
            Console.WriteLine($"Multithread time: {watch.ElapsedMilliseconds}");

            Console.ReadLine();
        }

        static async Task MainAsync(string[] args)
        {
            var threadedClass = new ThreadClass();
            await threadedClass.DownloadSomeSitesAsync();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LetsThread
{
    public class ThreadClass
    {
        public async Task DownloadSomeSitesAsync()
        {
            HttpClient client =
                new HttpClient() { MaxResponseContentBufferSize = 1000000 };
  
            var download1 = ProcessURLAsync("http://msdn.microsoft.com", client);
            var download2 = ProcessURLAsync("http://msdn.microsoft.com", client);
            var download3 = ProcessURLAsync("http://msdn.microsoft.com", client);

            var result1 = await download1;
            var result2 = await download2;
            var result3 = await download3;
        }

        public void DownloadSomeSitesMultiThread()
        {
            HttpClient client =
                new HttpClient() { MaxResponseContentBufferSize = 1000000 };

            var thread1 = new Thread(ProcessURLVoid);
            var thread2 = new Thread(ProcessURLVoid);
            var thread3 = new Thread(ProcessURLVoid);

            thread1.Start();
            thread2.Start();
            thread3.Start();
        }

        void ProcessURLVoid()
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            var client = new HttpClient() { MaxResponseContentBufferSize = 1000000 };
            var byteArray = client.GetByteArrayAsync("http://msdn.microsoft.com").Result;
            watch.Stop();
            Console.WriteLine($"Thread time: {watch.ElapsedMilliseconds}");
        }

        async Task<int> ProcessURLAsync(string url, HttpClient client)
        {
            var byteArray = await client.GetByteArrayAsync(url);
            return byteArray.Length;
        }

        public void DownloadSomeSites()
        {
            HttpClient client =
                new HttpClient() { MaxResponseContentBufferSize = 1000000 };

            int download1 =
                ProcessURL("http://msdn.microsoft.com", client);
            int download2 =
                ProcessURL("http://msdn.microsoft.com", client);
            int download3 =
                ProcessURL("http://msdn.microsoft.com", client);
        }

        private int ProcessURL(string url, HttpClient client)
        {
            var byteArray = client.GetByteArrayAsync(url).Result;
            return byteArray.Length;
        }
    }
}

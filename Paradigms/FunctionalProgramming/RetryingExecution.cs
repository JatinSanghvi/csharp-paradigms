namespace Paradigms.FunctionalProgramming
{
    using System;
    using System.Net;

    internal static class RetryingExecution
    {
        public static void Main()
        {
            using (var client = new WebClient())
            {
                Download(client, "https://jsonplaceholder.typicode.com/users");
                Download(client, "https://api.github.com");
            }
        }

        private static void Download(WebClient client, string address)
        {
            Console.WriteLine($"Downloading page: {address}.");
            Func<string> download = () => client.DownloadString(address);
            download.WithRetry();
        }

        private static T WithRetry<T>(this Func<T> function)
        {
            int attempt = 1;

            while (true)
            {
                Console.WriteLine($"Attempt: {attempt}");

                try
                {
                    T result = function();
                    Console.WriteLine("Execution succeeded.");
                    return result;
                }
                catch
                {
                    if (attempt == 3)
                    {
                        Console.WriteLine("Execution failed.");
                        throw;
                    }

                    attempt += 1;
                }
            }
        }
    }
}

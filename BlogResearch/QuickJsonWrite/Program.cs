using Newtonsoft.Json;
using System;

namespace QuickJsonWrite
{
    class Program
    {
        static void Main(string[] args)
        {
            var obj = new
                {
                    user = new
                        {
                            name = "John",
                            age = 21,
                            data = new[] { 1, 2, 3, 4}
                        }
                };

            Console.WriteLine(JsonConvert.SerializeObject(obj, Formatting.Indented));
        }
    }
}

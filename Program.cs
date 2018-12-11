using System;
using TrainingApi.Utilities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingApi
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Testing...");
            string input = Console.ReadLine();
            string output = AesCrypto.Decrypt(input);
            Console.WriteLine($"Result: {output}");
            Console.ReadLine();
        }
    }
}

using JwtRsa256.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JwtRsa256
{
    class Program
    {
        static void Main(string[] args)
        {
            var token = Token.Generate();
            Console.WriteLine("== Token Value ==");
            Console.WriteLine(token);
            Console.ReadLine();
        }
    }
}

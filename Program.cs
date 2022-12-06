using System;
using System.IO;

namespace CodeGenerator
{
    internal class Program
    {
        protected const string _parmPre = "-pre";
        protected const string _parmPost = "-post";

        private static void Main(string[] args)
        {
            Console.WriteLine("Code Generator!!!");
            Console.WriteLine("Generate Code by appending lines in the file with pre and post code snippets.");

            if (args == null || args.Length == 0)
            {
                Console.WriteLine("Please provide full path to file.");
                Console.WriteLine($"Along with {_parmPre} 'code snippet' to placed at the begining of each line in the file.");
                Console.WriteLine($"{_parmPost} 'code snippet' to be appended to the end of each line.");
            }
            else
            {
                string file = args[0];

                if (File.Exists(file))
                {
                    Console.WriteLine($"Found file: {file}");

                    string[] lines = File.ReadAllLines(file);

                    string preCode = ExtractParameter(args, _parmPre);
                    Console.WriteLine($"Using Pre Code: {preCode}");
                    string postCode = ExtractParameter(args, _parmPost);

                    Console.WriteLine($"Using Post Code: {postCode}");

                    foreach (string eachLine in lines)
                    {
                        Console.WriteLine(preCode + eachLine + postCode);
                    }
                }
            }

            Console.WriteLine("Done!!");
        }

        private static string ExtractParameter(string[] args, string parmName)
        {
            bool foundParm = false;
            string parmValue = string.Empty;
            foreach (string eachParm in args)
            {
                if (foundParm)
                {
                    parmValue = eachParm;
                    break;
                }
                if (string.Equals(eachParm, parmName, StringComparison.InvariantCultureIgnoreCase))
                {
                    foundParm = true;
                }
            }

            return parmValue;
        }
    }
}
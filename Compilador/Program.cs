using Compilador.Services;
using System;
using System.IO;
using System.Linq;

namespace Compilador
{
    internal class Program
    {
        private static int Main(string[] args)
        {
            string filePath = string.Empty;
            string outputPath = string.Empty;

#if DEBUG
            filePath = Path.Combine(Environment.CurrentDirectory, "primos.dotdot");
            outputPath = Environment.CurrentDirectory + "/primos.c";
            Console.WriteLine(Compiler.Convert(filePath, outputPath));
#else
            if(!CheckArgs(args, ref filePath, ref outputPath))
            {
                return -1;
            }

            if (!CheckFile(filePath))
            {
                return -1;
            }

            Console.WriteLine(Compiler.Convert(filePath, outputPath));
#endif
            return 0;
        }

        private static bool CheckArgs(string[] args, ref string filePath, ref string outputPath)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Missing paremeters: --path / --outPath");
                return false;
            }

            if (!VerifyAndGetArgument(args, new string[] { "--filePath", "-f" }, ref filePath))
            {
                return false;
            }

            if (!VerifyAndGetArgument(args, new string[] { "--outPath", "-o" }, ref outputPath))
            {
                return false;
            }

            if (!File.Exists(filePath))
            {
                Console.WriteLine($"Path does not exist: {filePath}");
                return false;
            }

            return true;
        }

        private static bool CheckFile(string filePath)
        {
            if (!File.Exists(filePath))
            {
                Console.WriteLine($"Path does not exist: {filePath}");
                return false;
            }

            if (Path.GetExtension(filePath) != ".dotdot" && Path.GetExtension(filePath) != ".c")
            {
                Console.WriteLine($"File is using the wrong extension. Expecting .dotdot extension");
                return false;
            }

            return true;
        }

        private static bool VerifyAndGetArgument(string[] args, string[] argument, ref string argumentValue)
        {
            if (!args.Any(a => argument.Contains(a)))
            {
                Console.WriteLine($"Missing paremeters: {argument.First()}");
                return false;
            }

            (string Argument, int Index) path = args.Select((s, i) => (s, i)).FirstOrDefault(t => argument.Contains(t.s));
            if (path.Index + 1 >= args.Length)
            {
                Console.WriteLine($"Missing paremeters: {argument.First()}");
                return false;
            }

            argumentValue = args[path.Index + 1];
            return true;
        }
    }
}

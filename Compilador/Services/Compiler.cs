using Compilador.Models;
using System.IO;

namespace Compilador.Services
{
    public static class Compiler
    {
        public static void Convert(string filePath, string outputPath)
        {
            DotCode dotCode = GetDotCode(filePath);

        }

        private static DotCode GetDotCode(string filePath)
        {
            using (StreamReader sr = new StreamReader(filePath))
            {
                string content = sr.ReadToEnd();
                return new DotCode(Path.GetFileName(filePath), filePath, content);
            }
        }
    }
}
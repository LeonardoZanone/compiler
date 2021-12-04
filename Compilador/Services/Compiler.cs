using CompiladorAPI.Models;
using DotLanguage.Models;
using System.IO;

namespace Compilador.Services
{
    public static class Compiler
    {
        public static void Convert(string filePath, string outputPath)
        {
            DotCode dotCode = new DotCode(Path.GetFileName(filePath), filePath, ReadCode(filePath));
            string cCode = dotCode.TranslateTo<CCode>();
            var a = 10;
        }
        private static string ReadCode(string filePath)
        {
            string content;
            using (StreamReader sr = new StreamReader(filePath))
            {
                content = sr.ReadToEnd();
            }
            return content;
        }
    }
}
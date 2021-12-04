using CompiladorAPI.Models;
using DotLanguage.Models;
using System.IO;

namespace Compilador.Services
{
    public static class Compiler
    {
        public static void Convert(string filePath, string outputPath)
        {
            //DotCode dotCode = new DotCode(Path.GetFileName(filePath), filePath, ReadCode(filePath));
            DotCode dotCode = new DotCode(Path.GetFileName(filePath), filePath, ReadCode(filePath));
            CCode cCode = (CCode)dotCode.TranslateTo<CCode>();
            string code = dotCode.ToString();
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
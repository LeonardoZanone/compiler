using CompiladorAPI.Models;
using DotLanguage.Models;
using System;
using System.IO;

namespace Compilador.Services
{
    public static class Compiler
    {
        public static void Convert(string filePath, string outputPath)
        {
            try
            {
                DotCode dotCode = new DotCode(Path.GetFileName(filePath), filePath, ReadCode(filePath));
                string cCode = dotCode.TranslateTo<CCode>();
                using(StreamWriter sw = new StreamWriter(outputPath))
                {
                    sw.Write(cCode);
                }
            }
            catch (Exception) { }
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
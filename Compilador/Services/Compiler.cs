using CompiladorAPI.Models;
using DotLanguage.Models;
using System.IO;

namespace Compilador.Services
{
    public static class Compiler
    {
        public static string Convert(string filePath, string outputPath)
        {
            //try
            //{
            string extesion = Path.GetExtension(filePath);
            string fullOutPath = Path.GetFullPath(outputPath);
            switch (extesion)
            {
                case ".c":
                    CCode cCode = new CCode(Path.GetFileName(filePath), filePath, ReadCode(filePath));
                    string dotCodeString = cCode.TranslateTo<DotCode>();
                    if (!string.IsNullOrEmpty(dotCodeString))
                    {
                        WriteCode(fullOutPath, dotCodeString);
                    }
                    else
                    {
                        return "There was a sintax error!";
                    }
                    return $"Success! The translated code can be found at {fullOutPath}";
                case ".dotdot":
                    DotCode dotCode = new DotCode(Path.GetFileName(filePath), filePath, ReadCode(filePath));
                    string cCodeString = dotCode.TranslateTo<CCode>();
                    if (!string.IsNullOrEmpty(cCodeString))
                    {
                        WriteCode(fullOutPath, cCodeString + "return 0;\n}");
                    }
                    else
                    {
                        return "There was a sintax error!";
                    }
                    return $"Success! The translated code can be found at {fullOutPath}";
                default:
                    return $"Invalid extension {extesion}. Expected extensions: .c .dotdot";
            }
            //}
            //catch (Exception)
            //{
            //    return "A problem happened";
            //}
        }

        private static void WriteCode(string outputPath, string cCode)
        {
            using (StreamWriter sw = new StreamWriter(outputPath))
            {
                sw.Write(cCode);
            }
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
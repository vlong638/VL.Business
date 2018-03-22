using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PathFixer
{
    class Program
    {
        static void Main(string[] args)
        {
            var path = Path.Combine(@"C:\ProgramData\Autodesk\Revit\Addins\2016", "ConstructionManagement.addin");
            if (File.Exists(path))
            {
                var texts = File.ReadAllLines(path);
                for (int i = 0; i < texts.Length; i++)
                {
                    var text = texts[i];
                    if (text.Contains("<Assembly>"))
                    {
                        Regex regex = new Regex(@"(.*<Assembly>)(.+)(</Assembly>)");
                        var match = regex.Match(text);
                        if (match.Groups.Count==4)
                        {
                            texts[i] = match.Groups[1] + Path.Combine(System.Environment.CurrentDirectory, match.Groups[2].ToString().Trim().TrimStart('\\')) + match.Groups[3];
                        }
                    }
                }
                File.WriteAllLines(path, texts);
            }
        }
    }
}

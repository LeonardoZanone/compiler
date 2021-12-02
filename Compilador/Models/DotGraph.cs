using Compilador.Interfaces;
using Compilador.Models.Nodes;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace Compilador.Models
{
    public class DotGraph : IGraph
    {
        public Node Root { get; set; }
        public DotGraph()
        {
            Root = new SNode();
        }

        public void Analyse(string content)
        {   
            Regex whitespaces = new Regex(@"\s");
            content = whitespaces.Replace(content, new MatchEvaluator(match => ""));
            string result = Root.Validate(content, new List<NodeType>());
            Translate();
        }

        public ICode Translate()
        {
            using (StreamWriter sw = new StreamWriter("result.txt"))
            {
                string result = Root.ToString();
                sw.Write(result);
            }
            return null;
        }
    }
}
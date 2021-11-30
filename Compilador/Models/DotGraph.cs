using Compilador.Interfaces;
using Compilador.Models.Nodes;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Compilador.Models
{
    public class DotGraph : IGraph
    {
        public Node Root { get; set; }
        public IEnumerable<INode> Nodes { get; set; }

        public DotGraph()
        {
            Root = new SNode();
        }

        public void Analyse(string content)
        {
            Regex whitespaces = new Regex(@"\s");
            content = whitespaces.Replace(content, new MatchEvaluator(match => ""));
            string reault = Root.Validate(content, new List<NodeType>());
            var nodes = new List<Node>();
        }

        public ICode Translate()
        {
            throw new System.NotImplementedException();
        }
    }
}
using CLanguage.Models.Nodes;
using CompiladorAPI.Interfaces;
using CompiladorAPI.Models.Nodes;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace CompiladorAPI.Models
{
    public class CGraph : IGraph
    {
        private bool _isAnalysed;
        public Node Root { get; private set; }

        public CGraph()
        {
            Root = new SNode();
        }

        public void Analyse(string content)
        {
            Regex whitespaces = new Regex(@"\s");
            content = whitespaces.Replace(content, new MatchEvaluator(match => ""));
            string result = Root.Validate(content, new List<NodeType>());
            if (result == null)
            {
                _isAnalysed = true;
            }
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

        public bool IsAnalysed()
        {
            return _isAnalysed;
        }

        public IEnumerable<INode> Traversal()
        {
            foreach (INode node in TraversalLoop(Root))
            {
                yield return node;
            }
            yield break;
        }

        private IEnumerable<INode> TraversalLoop(INode node)
        {
            foreach (INode child in node.GetChildren())
            {
                foreach (INode item in TraversalLoop(child))
                {
                    yield return item;
                }
                yield return child;
            }
            yield break;
        }
    }
}
using CompiladorAPI.Interfaces;
using CompiladorAPI.Models.Nodes;
using DotLanguage.Models.Nodes;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace DotLanguage.Models
{
    public class DotGraph : IGraph
    {
        public Node Root { get; set; }
        private bool _isAnalysed;
        public DotGraph()
        {
            Root = new SNode();
        }

        public void Analyse(string content)
        {
            //Regex whitespaces = new Regex(@"\s");
            //content = whitespaces.Replace(content, new MatchEvaluator(match => ""));
            string result = Root.Validate(content, new List<NodeType>());
            if (result == null)
            {
                _isAnalysed = true;
            }
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
                if (!child.IsSimpleTranslation())
                {
                    yield return child;
                    yield break;
                }
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
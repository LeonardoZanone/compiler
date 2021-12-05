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
            string result = Root.Validate(content, new List<NodeType>());
            if (string.IsNullOrEmpty(result))
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
            yield return Root;
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
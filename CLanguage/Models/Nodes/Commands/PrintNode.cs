using CLanguage.Models.Nodes.Commands.Terminal;
using CompiladorAPI.Interfaces;
using CompiladorAPI.Models;
using CompiladorAPI.Models.Nodes;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace CLanguage.Models.Nodes.Commands
{
    public class PrintNode : Node
    {
        public override NodeType Type => NodeType.PRINT;
        private static readonly Regex firstPrintRegex = new Regex(@"^[p]*");

        public PrintNode()
        {
        }

        public PrintNode(string value) : base(value)
        {
        }

        public override bool First(char next)
        {
            return firstPrintRegex.IsMatch(next.ToString());
        }

        public override bool Follow(string next)
        {
            return new BlocoNode().Follow(next) || new BlocoNode().First(next.FirstOrDefault());
        }

        public override IEnumerable<Condition> GetNeightbors()
        {
            yield return new Condition(new List<INode>() {
                new TerminalPrintNode(),
                new TerminalNode("("),
                new ArgsNode(),
                new TerminalNode(")"),
            });
            yield break;
        }

        public override bool IsTerminal()
        {
            return false;
        }

        public override bool IsSimpleTranslation()
        {
            return false;
        }
        public override string ToString()
        {
            return $"printf(\"%i\", {GetChildren()[2]});";
        }

        public override INode From(INode node)
        {
            PrintNode clonedNode = new PrintNode();
            foreach (INode child in node.GetChildren())
            {
                clonedNode.AddChild((Node)child);
            }
            return clonedNode;
        }
    }
}

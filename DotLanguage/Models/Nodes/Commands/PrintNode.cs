using CompiladorAPI.Interfaces;
using CompiladorAPI.Models;
using CompiladorAPI.Models.Nodes;
using DotLanguage.Models.Nodes.Commands.Terminal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace DotLanguage.Models.Nodes.Commands
{
    public class PrintNode : Node
    {
        public override NodeType Type => NodeType.PRINT;
        private static readonly Regex firstPrintRegex = new Regex(@"^[a]*");

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
                new ArgNode(),
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
            return $"aPrinter({GetChildren()[2].GetChildren()[3]});";
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

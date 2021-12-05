using CompiladorAPI.Interfaces;
using CompiladorAPI.Models;
using CompiladorAPI.Models.Nodes;
using System.Collections.Generic;
using System.Linq;

namespace CLanguage.Models.Nodes
{
    public class SNode : Node
    {
        public SNode()
        {
        }

        public SNode(string value) : base(value)
        {
        }

        public override NodeType Type => NodeType.S;

        public override IEnumerable<Condition> GetNeightbors()
        {
            yield return new Condition(new List<INode>() {
                new TerminalNode("void"),
                new TerminalNode("main"),
                new TerminalNode("("),
                new TerminalNode(")"),
                new TerminalNode("{"),
                new BlocoNode(),
                new TerminalNode("}")
            });
            yield break;
        }

        public override bool IsTerminal()
        {
            return false;
        }

        public override bool Follow(string next)
        {
            return true;
        }

        public override bool First(char next)
        {
            return new BlocoNode().First(next);
        }

        public override bool Build(char next)
        {
            return false;
        }

        public override string ToString()
        {
            return "void main() {\n";
        }

        public override string GetCleanValue()
        {
            return string.Empty;
        }
    }
}

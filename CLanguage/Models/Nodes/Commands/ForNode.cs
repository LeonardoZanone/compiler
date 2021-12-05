using CLanguage.Models.Nodes.Commands.Terminal;
using CompiladorAPI.Interfaces;
using CompiladorAPI.Models;
using CompiladorAPI.Models.Nodes;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace CLanguage.Models.Nodes.Commands
{
    public class ForNode : Node
    {
        public override NodeType Type => NodeType.FOR;

        private static readonly Regex firstComandoRegex = new Regex(@"^[f]*");

        public ForNode()
        {
        }

        public ForNode(string value) : base(value)
        {
        }

        public override bool First(char next)
        {
            return firstComandoRegex.IsMatch(next.ToString());
        }

        public override bool Follow(string next)
        {
            return new BlocoNode().Follow(next) || new BlocoNode().First(next.FirstOrDefault());
        }

        public override IEnumerable<Condition> GetNeightbors()
        {
            yield return new Condition(new List<INode>() {
                new TerminalForNode(),
                new TerminalNode("("),
                new ExprAttrNode(),
                new TerminalNode(";"),
                new ExprBiNode(),
                new TerminalNode(";"),
                new ExprNode(),
                new TerminalNode(")"),
            });
            yield break;
        }

        public override bool IsTerminal()
        {
            return false;
        }
    }
}

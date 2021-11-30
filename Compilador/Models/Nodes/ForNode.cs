using Compilador.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Compilador.Models.Nodes
{
    public class ForNode : Node
    {
        public override NodeType Type => NodeType.FOR;

        private static readonly Regex firstComandoRegex = new Regex(@"^[f]*");

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
                new TerminalNode("for"),
                new TerminalNode("("),
                new ExprAttrNode(),
                new TerminalNode(";"),
                new ExprBiNode(),
                new TerminalNode(";"),
                new ExprNode(),
                new TerminalNode(";"),
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
    }
}

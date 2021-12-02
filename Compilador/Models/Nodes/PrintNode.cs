using Compilador.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Compilador.Models.Nodes
{
    public class PrintNode : Node
    {
        public override NodeType Type => NodeType.PRINT;
        private static readonly Regex firstPrintRegex = new Regex(@"^[p]*");

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
                new TerminalNode("print"),
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
    }
}

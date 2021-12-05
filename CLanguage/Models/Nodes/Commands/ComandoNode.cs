using CompiladorAPI.Interfaces;
using CompiladorAPI.Models;
using CompiladorAPI.Models.Nodes;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace CLanguage.Models.Nodes.Commands
{
    public class ComandoNode : Node
    {
        public override NodeType Type => NodeType.COMANDO;
        /// <summary>
        /// Matches the beggining of if, for, while, do, print
        /// </summary>
        private static readonly Regex firstComandoRegex = new Regex(@"^[ifwdp]*");

        public ComandoNode()
        {
        }

        public ComandoNode(string value) : base(value)
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
            yield return new Condition(new List<INode>() { new PrintNode(), new TerminalNode(";") });
            yield return new Condition(new List<INode>() { new IfNode(), new TerminalNode("{"), new BlocoNode(), new TerminalNode("}") });
            yield return new Condition(new List<INode>() { new ForNode(), new TerminalNode("{"), new BlocoNode(), new TerminalNode("}") });
            yield return new Condition(new List<INode>() { new WhileNode(), new TerminalNode("{"), new BlocoNode(), new TerminalNode("}") });
            yield break;
        }

        public override bool IsTerminal()
        {
            return false;
        }
    }
}
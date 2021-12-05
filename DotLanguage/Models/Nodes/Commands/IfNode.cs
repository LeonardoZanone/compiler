using CompiladorAPI.Interfaces;
using CompiladorAPI.Models;
using CompiladorAPI.Models.Nodes;
using DotLanguage.Models.Nodes.Commands.Terminal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace DotLanguage.Models.Nodes.Commands
{
    public class IfNode : Node
    {
        public override NodeType Type => NodeType.IF;

        private static readonly Regex firstComandoRegex = new Regex(@"^[Y]*");

        public IfNode()
        {
        }

        public IfNode(string value) : base(value)
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
                new TerminalIfNode(), 
                new TerminalNode("("), 
                new ExprBiNode(), 
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

﻿using CLanguage.Models.Nodes.Commands.Terminal;
using CompiladorAPI.Interfaces;
using CompiladorAPI.Models;
using CompiladorAPI.Models.Nodes;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace CLanguage.Models.Nodes.Commands
{
    public class WhileNode : Node
    {
        public override NodeType Type => NodeType.WHILE;
        private static readonly Regex firstComandoRegex = new Regex(@"^[w]*");

        public WhileNode()
        {
        }

        public WhileNode(string value) : base(value)
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
                new TerminalDoNode(),
                new TerminalNode("{"),
                new BlocoNode(),
                new TerminalNode("}"),
                new TerminalWhileNode(),
                new TerminalNode("("),
                new ExprBiNode(),
                new TerminalNode(")"),
            });
            yield return new Condition(new List<INode>() {
                new TerminalWhileNode(),
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

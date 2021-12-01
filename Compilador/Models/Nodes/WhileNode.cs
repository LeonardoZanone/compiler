﻿using Compilador.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Compilador.Models.Nodes
{
    public class WhileNode : Node
    {
        public override NodeType Type => NodeType.WHILE;
        private static readonly Regex firstComandoRegex = new Regex(@"^[w]*");

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
                new TerminalNode("while"),
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

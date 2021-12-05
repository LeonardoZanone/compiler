﻿using CompiladorAPI.Models;
using CompiladorAPI.Models.Nodes;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace DotLanguage.Models.Nodes.Commands.Terminal
{
    public class TerminalIfNode : Node
    {
        public override NodeType Type => NodeType.TERMINALIF;
        private static readonly Regex firstRegex = new Regex(@"^[Y]*");
        private static readonly Regex validateRegex = new Regex(@"^Yeah$");
        private static readonly Regex buildRegex = new Regex(@"^Ye*a*h*(?<=Ye*a*h*)$");

        public TerminalIfNode()
        {
        }

        public TerminalIfNode(string value) : base(value)
        {
        }

        public override bool First(char next)
        {
            return firstRegex.IsMatch(next.ToString());
        }

        public override bool Follow(string next)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<Condition> GetNeightbors()
        {
            yield break;
        }

        public override bool IsTerminal()
        {
            return true;
        }
        public override bool Validate()
        {
            if (validateRegex.IsMatch(Value))
            {
                _isValid = true;
                return true;
            }
            return false;
        }

        public override bool Build(char next)
        {
            if (buildRegex.IsMatch(Value + next))
            {
                Value += next;
                return true;
            }
            return false;
        }
        public override string ToString()
        {
            return "Yeah";
        }
    }
}

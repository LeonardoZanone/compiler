using CompiladorAPI.Models;
using CompiladorAPI.Models.Nodes;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace DotLanguage.Models.Nodes.Commands.Terminal
{
    public class TerminalDoNode : Node
    {
        public override NodeType Type => NodeType.TERMINALDO;
        private static readonly Regex firstRegex = new Regex(@"^[b]*");
        private static readonly Regex validateRegex = new Regex(@"^behavior$");
        private static readonly Regex buildRegex = new Regex(@"^be*h*a*v*i*o*r*(?<=be*h*a*v*i*o*r*)$");

        public TerminalDoNode()
        {
        }

        public TerminalDoNode(string value) : base(value)
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
            return "behavior";
        }
    }
}

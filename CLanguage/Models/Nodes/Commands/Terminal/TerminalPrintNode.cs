using CompiladorAPI.Models;
using CompiladorAPI.Models.Nodes;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace CLanguage.Models.Nodes.Commands.Terminal
{
    public class TerminalPrintNode : Node
    {
        public override NodeType Type => NodeType.TERMINALPRINT;
        private static readonly Regex firstRegex = new Regex(@"^[p]*");
        private static readonly Regex validateRegex = new Regex(@"^printf$");
        private static readonly Regex buildRegex = new Regex(@"^pr*i*n*t*f*(?<=pr*i*n*t*f*)$");

        public TerminalPrintNode()
        {
        }

        public TerminalPrintNode(string value) : base(value)
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
            return "printf";
        }
    }
}

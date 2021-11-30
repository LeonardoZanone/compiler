using Compilador.Interfaces;
using System.Collections.Generic;

namespace Compilador.Models.Nodes
{
    public class TerminalNode : Node
    {
        private readonly string constValue;
        public TerminalNode(string value)
        {
            constValue = value;
        }
        public override NodeType Type => NodeType.TERMINAL;

        public override bool Build(char next)
        {
            if(constValue.StartsWith(Value + next))
            {
                Value += next;
                return true;
            }
            return false;
        }

        public override bool First(char next)
        {
            return constValue.StartsWith(next);
        }

        public override bool Follow(string next)
        {
            return true;
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
            if(Value == constValue)
            {
                _isValid = true;
                return true;
            }
            return false;
        }

    }
}

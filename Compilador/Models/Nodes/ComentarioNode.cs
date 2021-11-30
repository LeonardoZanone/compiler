using Compilador.Interfaces;
using System.Collections.Generic;

namespace Compilador.Models.Nodes
{
    public class ComentarioNode : Node
    {
        public override NodeType Type => NodeType.COMENTARIO;

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
            if(Value.StartsWith("...") && Value.EndsWith("...")) 
            {
                _isValid = true;
                return true; 
            }

            return base.Validate();
        }

        public override bool First(char next)
        {
            return next == '.';
        }

        public override bool Follow(string next)
        {
            return next.Contains("...");
        }

        public override bool Build(char next)
        {
            if (string.IsNullOrEmpty(Value) && next != '.')
            {
                return false;
            }

            if (Value.Length > 2 && Value.EndsWith("..") && next == '.')
            {
                Value += next;
                return false;
            }

            Value += next;
            return true;
        }
    }
}

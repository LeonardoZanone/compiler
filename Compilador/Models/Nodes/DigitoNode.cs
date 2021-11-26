using Compilador.Interfaces;
using System.Collections.Generic;

namespace Compilador.Models.Nodes
{
    public class DigitoNode : Node
    {
        public override NodeType Type => NodeType.DIGITO;

        public override bool Build(char next)
        {
            throw new System.NotImplementedException();
        }

        public override bool First(char next)
        {
            return IsDigit(next.ToString());
        }

        public override bool Follow(string next)
        {
            if(string.IsNullOrEmpty(Value) && IsDigit(next.ToString()))
            {
                Value += next;
            }
            return false;
        }

        public override IEnumerable<Condition> GetNeightbors()
        {
            yield break;
        }

        public override bool IsTerminal()
        {
            return true;
        }

        public override bool Validate(string value = null, List<INode> nodes = null)
        {
            return IsDigit(Value);
        }

        private bool IsDigit(string value)
        {
            switch (value)
            {
                case "0":
                case "1":
                case "2":
                case "3":
                case "4":
                case "5":
                case "6":
                case "7":
                case "8":
                case "9":
                    return true;
                default: return false;
            }
        }
    }
}
using CompiladorAPI.Interfaces;
using CompiladorAPI.Models;
using CompiladorAPI.Models.Nodes;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace DotLanguage.Models.Nodes
{
    public class DigitoNode : Node
    {
        public override NodeType Type => NodeType.DIGITO;
        private static readonly Regex numberRegex = new Regex(@"^\d{1}$");

        public DigitoNode()
        {
        }

        public DigitoNode(string value) : base(value)
        {
        }

        public override bool Build(char next)
        {
            if (string.IsNullOrEmpty(Value) && IsDigit(next.ToString()))
            {
                Value += next;
            }
            return false;
        }

        public override bool First(char next)
        {
            return IsDigit(next.ToString());
        }

        public override bool Follow(string next)
        {
            return new InteiroNode().First(next.FirstOrDefault()) || new InteiroNode().Follow(next);
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
            if (IsDigit(Value))
            {
                _isValid = true;
                return true;
            }
            return false;
        }

        private bool IsDigit(string value)
        {
            return numberRegex.IsMatch(value);
        }
    }
}
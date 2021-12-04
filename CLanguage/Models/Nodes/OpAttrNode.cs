using CompiladorAPI.Models;
using CompiladorAPI.Models.Nodes;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace CLanguage.Models.Nodes
{
    public class OpAttrNode : Node
    {
        public override NodeType Type => NodeType.OPATTR;
        private static readonly Regex opAttrRegex = new Regex(@"^[\+\-\*\/]{0,1}={0,1}$");
        private static readonly Regex firstOpAttrRegex = new Regex(@"^\+|\-|\*|\/|\=");
        private static readonly Regex buildOpAttrRegex = new Regex(@"^[\+\-\*\/]{0,1}={0,1}$");

        public OpAttrNode()
        {
        }

        public OpAttrNode(string value) : base(value)
        {
        }

        public override bool Build(char next)
        {
            if (buildOpAttrRegex.IsMatch(Value + next))
            {
                Value += next;
                return true;
            }
            return false;
        }

        public override bool First(char next)
        {
            return firstOpAttrRegex.IsMatch(next.ToString());
        }

        public override bool Follow(string next)
        {
            return new AtribuicaoNode().First(next.FirstOrDefault());
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
            if (opAttrRegex.IsMatch(Value))
            {
                _isValid = true;
                return true;
            }
            return false;
        }
    }
}
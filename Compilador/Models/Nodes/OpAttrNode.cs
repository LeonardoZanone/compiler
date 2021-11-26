using Compilador.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Compilador.Models.Nodes
{
    public class OpAttrNode : Node
    {
        public override NodeType Type => NodeType.OPATTR;
        private readonly Regex opAttrRegex = new Regex(@"^[\+\-\*\/]*={0,1}$");
        private readonly Regex firstOpAttrRegex = new Regex(@"^\+|\-|\*|\/");
        private readonly Regex buildOpAttrRegex = new Regex(@"^[\+\-\*\/]*={0,1}");

        public override bool Build(char next)
        {
            if(buildOpAttrRegex.IsMatch(Value + next))
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

        public override bool Validate(string value = null, List<INode> nodes = null)
        {
            return opAttrRegex.IsMatch(Value);
        }
    }
}
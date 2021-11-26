
using Compilador.Interfaces;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Compilador.Models.Nodes
{
    internal class OpUnNode : Node
    {
        public override NodeType Type => NodeType.OPUN;
        private readonly Regex opUnRegex = new Regex(@"^(\+\+|\-\-|\!){1}$");
        private readonly Regex firstOpUnRegex = new Regex(@"^(\+|\-|\!)");
        private readonly Regex buildOpUnRegex = new Regex(@"^(\+\+*|\-\-*|\!)$");

        public override bool Build(char next)
        {
            if(buildOpUnRegex.IsMatch(Value + next))
            {
                Value += next;
                return true;
            }
            return false;
        }

        public override bool First(char next)
        {
            return firstOpUnRegex.IsMatch(next.ToString());
        }

        public override bool Follow(string next)
        {
            return new ExprAttrNode().Follow(next);
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
            return opUnRegex.IsMatch(Value);
        }
    }
}
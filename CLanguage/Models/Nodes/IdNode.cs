using CompiladorAPI.Models;
using CompiladorAPI.Models.Nodes;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace CLanguage.Models.Nodes
{
    public class IdNode : Node
    {
        private static readonly Regex firstIdRegex = new Regex(@"[a-zA-Z]");
        private static readonly Regex idRegex = new Regex(@"^[a-zA-Z]+[a-zA-Z0-9]*$");

        public IdNode()
        {
        }

        public IdNode(string value) : base(value)
        {
        }

        public override NodeType Type => NodeType.ID;

        public override bool Build(char next)
        {
            if (idRegex.IsMatch(Value + next))
            {
                Value += next;
                return true;
            }
            return false;
        }

        public override bool First(char next)
        {
            return firstIdRegex.IsMatch(next.ToString());
        }

        public override bool Follow(string next)
        {
            return
                new OpAttrNode().First(next.FirstOrDefault()) ||
                new OpUnNode().First(next.FirstOrDefault()) ||
                new ExprNode().Follow(next) ||
                new AtribuicaoNode().Follow(next) ||
                new ArgNode().Follow(next) ||
                new ValorNode().Follow(next);
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
            if (idRegex.IsMatch(Value))
            {
                _isValid = true;
                return true;
            }
            return false;
        }
    }
}

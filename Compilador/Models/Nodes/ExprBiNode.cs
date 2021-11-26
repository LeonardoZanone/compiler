using Compilador.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Compilador.Models.Nodes
{
    public class ExprBiNode : Node
    {
        public override NodeType Type => NodeType.EXPRBI;

        public override bool First(char next)
        {
            return new ValorNode().First(next);
        }

        public override bool Follow(string next)
        {
            return next == ")" || new ExprNode().Follow(next) || new ExprNode().First(next.FirstOrDefault());
        }

        public override IEnumerable<Condition> GetNeightbors()
        {
            yield return new Condition(new List<INode>() { new ValorNode(), new OpBiNode(), new ValorNode() });
            yield break;
        }

        public override bool IsTerminal()
        {
            return false;
        }
    }
}
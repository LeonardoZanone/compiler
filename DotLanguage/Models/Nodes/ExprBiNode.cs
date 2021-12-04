using CompiladorAPI.Interfaces;
using CompiladorAPI.Models;
using CompiladorAPI.Models.Nodes;
using System.Collections.Generic;
using System.Linq;

namespace DotLanguage.Models.Nodes
{
    public class ExprBiNode : Node
    {
        public ExprBiNode()
        {
        }

        public ExprBiNode(string value) : base(value)
        {
        }

        public override NodeType Type => NodeType.EXPRBI;

        public override bool First(char next)
        {
            return next == '(' || new ValorNode().First(next);
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
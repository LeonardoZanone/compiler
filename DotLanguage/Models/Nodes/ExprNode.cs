using CompiladorAPI.Interfaces;
using CompiladorAPI.Models;
using CompiladorAPI.Models.Nodes;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotLanguage.Models.Nodes
{
    public class ExprNode : Node
    {
        public ExprNode()
        {
        }

        public ExprNode(string value) : base(value)
        {
        }

        public override NodeType Type => NodeType.EXPR;

        public override bool First(char next)
        {
            return new ValorNode().First(next) || new TipoNode().First(next);
        }

        public override bool Follow(string next)
        {
            return next.Contains(";");
        }

        public override IEnumerable<Condition> GetNeightbors()
        {
            yield return new Condition(new List<INode> { new ExprAttrNode() });
            yield return new Condition(new List<INode> { new ExprBiNode() });
            yield return new Condition(new List<INode> { new ExprAttrNode(), new ExprNode() });
            yield return new Condition(new List<INode> { new ExprBiNode(), new ExprNode() });
            yield break;
        }

        public override bool IsTerminal()
        {
            return false;
        }
    }
}

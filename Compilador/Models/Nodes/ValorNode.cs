
using Compilador.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Compilador.Models.Nodes
{
    public class ValorNode : Node
    {
        public override NodeType Type => NodeType.VALOR;

        public override bool First(char next)
        {
            return next == '(' || new DigitoNode().First(next) || new IdNode().First(next);
        }

        public override bool Follow(string next)
        {
            return next == "=" ||
                new ExprBiNode().Follow(next) ||
                new OpBiNode().First(next.FirstOrDefault()) ||
                new ValorNode().First(next.FirstOrDefault()) ||
                new AtribuicaoNode().Follow(next);
        }

        public override IEnumerable<Condition> GetNeightbors()
        {
            yield return new Condition(new List<INode>() { new TerminalNode("("), new ExprBiNode(), new TerminalNode(")") });
            yield return new Condition(new List<INode>() { new InteiroNode() });
            yield return new Condition(new List<INode>() { new FloatNode() });
            yield return new Condition(new List<INode>() { new IdNode() });
            yield return new Condition(new List<INode>() { new ExprBiNode() });
            yield break;
        }

        public override bool IsTerminal()
        {
            return false;
        }
    }
}
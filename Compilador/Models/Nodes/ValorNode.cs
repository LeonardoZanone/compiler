
using Compilador.Interfaces;
using System.Collections.Generic;

namespace Compilador.Models.Nodes
{
    public class ValorNode : Node
    {
        public override NodeType Type => NodeType.VALOR;

        public override bool Build(char next)
        {
            throw new System.NotImplementedException();
        }

        public override bool First(char next)
        {
            return new DigitoNode().First(next) || new IdNode().First(next);
        }

        public override bool Follow(string next)
        {
            throw new System.NotImplementedException();
        }

        public override IEnumerable<Condition> GetNeightbors()
        {
            yield return new Condition(new List<INode>() { new TerminalNode("<id>") });
            yield return new Condition(new List<INode>() { new InteiroNode() });
            yield return new Condition(new List<INode>() { new FloatNode() });
            yield return new Condition(new List<INode>() { new ExprBiNode() });
            yield return new Condition(new List<INode>() { new TerminalNode("("), new ExprBiNode(), new TerminalNode(")") });
            yield break;
        }

        public override bool IsTerminal()
        {
            return false;
        }

        public override bool Validate(string value = null, List<INode> nodes = null)
        {
            throw new System.NotImplementedException();
        }
    }
}
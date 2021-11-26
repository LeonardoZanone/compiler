using Compilador.Interfaces;
using System.Collections.Generic;

namespace Compilador.Models.Nodes
{
    public class AtribuicaoNode : Node
    {
        public override NodeType Type => NodeType.ATRIBUICAO;

        public override IEnumerable<Condition> GetNeightbors()
        {
            yield return new Condition(new List<INode>() { new ExprBiNode() });
            yield return new Condition(new List<INode>() { new TerminalNode("<id>") });
            yield return new Condition(new List<INode>() { new ValorNode() });
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
        public override bool Follow(string next)
        {
            throw new System.NotImplementedException();
        }

        public override bool First(char next)
        {
            throw new System.NotImplementedException();
        }

        public override bool Build(char next)
        {
            throw new System.NotImplementedException();
        }
    }
}
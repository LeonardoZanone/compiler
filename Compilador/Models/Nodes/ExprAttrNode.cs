using Compilador.Interfaces;
using System.Collections.Generic;

namespace Compilador.Models.Nodes
{
    internal class ExprAttrNode : Node
    {
        public override NodeType Type => NodeType.EXPRATT;

        public override bool Build(char next)
        {
            throw new System.NotImplementedException();
        }

        public override bool First(char next)
        {
            throw new System.NotImplementedException();
        }

        public override bool Follow(string next)
        {
            throw new System.NotImplementedException();
        }

        public override IEnumerable<Condition> GetNeightbors()
        {
            yield return new Condition(new List<INode>() { new TipoNode(), new TerminalNode("<id>"), new OpAttrNode(), new AtribuicaoNode() });
            yield return new Condition(new List<INode>() { new TerminalNode("<id>"), new OpAttrNode(), new AtribuicaoNode() });
            yield return new Condition(new List<INode>() { new TipoNode(), new TerminalNode("<id>") });
            yield return new Condition(new List<INode>() { new TerminalNode("<id>"), new OpUnNode() });
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
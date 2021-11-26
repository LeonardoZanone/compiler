using Compilador.Interfaces;
using System.Collections.Generic;

namespace Compilador.Models.Nodes
{
    public class FloatNode : Node
    {
        public override NodeType Type => NodeType.FLOAT;

        public override bool First(char next)
        {
            return new DigitoNode().First(next);
        }

        public override bool Follow(string next)
        {
            return new ValorNode().Follow(next);
        }

        public override IEnumerable<Condition> GetNeightbors()
        {
            yield return new Condition(new List<INode>() { new InteiroNode(), new TerminalNode("."), new InteiroNode() });
            yield break;
        }

        public override bool IsTerminal()
        {
            return false;
        }
    }
}
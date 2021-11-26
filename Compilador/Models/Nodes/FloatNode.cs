using Compilador.Interfaces;
using System.Collections.Generic;

namespace Compilador.Models.Nodes
{
    public class FloatNode : Node
    {
        public override NodeType Type => NodeType.FLOAT;

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
            yield return new Condition(new List<INode>() { new InteiroNode(), new TerminalNode("."), new InteiroNode() });
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
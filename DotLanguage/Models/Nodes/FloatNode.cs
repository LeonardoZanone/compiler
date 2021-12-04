using CompiladorAPI.Interfaces;
using CompiladorAPI.Models;
using CompiladorAPI.Models.Nodes;
using System.Collections.Generic;

namespace DotLanguage.Models.Nodes
{
    public class FloatNode : Node
    {
        public FloatNode()
        {
        }

        public FloatNode(string value) : base(value)
        {
        }

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
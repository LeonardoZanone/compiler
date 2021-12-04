using CompiladorAPI.Interfaces;
using CompiladorAPI.Models;
using CompiladorAPI.Models.Nodes;
using System.Collections.Generic;

namespace CLanguage.Models.Nodes
{
    public class InteiroNode : Node
    {
        public InteiroNode()
        {
        }

        public InteiroNode(string value) : base(value)
        {
        }

        public override NodeType Type => NodeType.INTEIRO;

        public override bool First(char next)
        {
            return new DigitoNode().First(next);
        }

        public override bool Follow(string next)
        {
            return next == "." || new ValorNode().Follow(next);
        }

        public override IEnumerable<Condition> GetNeightbors()
        {
            yield return new Condition(new List<INode>() { new DigitoNode() });
            yield return new Condition(new List<INode>() { new DigitoNode(), new InteiroNode() });
            yield break;
        }

        public override bool IsTerminal()
        {
            return false;
        }
    }
}
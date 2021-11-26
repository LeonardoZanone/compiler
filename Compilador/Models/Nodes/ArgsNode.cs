using Compilador.Interfaces;
using System.Collections.Generic;

namespace Compilador.Models.Nodes
{
    public class ArgsNode : Node
    {
        public override NodeType Type => NodeType.ARGS;

        public override bool First(char next)
        {
            return new ArgNode().First(next);
        }

        public override bool Follow(string next)
        {
            return false;
        }

        public override IEnumerable<Condition> GetNeightbors()
        {
            yield return new Condition(new List<INode>() { new ArgNode(), new TerminalNode(","), new ArgNode() });
            yield return new Condition(new List<INode>() { new ArgNode() });
            yield break;
        }

        public override bool IsTerminal()
        {
            return false;
        }
    }
}
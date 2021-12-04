using CompiladorAPI.Interfaces;
using CompiladorAPI.Models;
using CompiladorAPI.Models.Nodes;
using System.Collections.Generic;

namespace DotLanguage.Models.Nodes
{
    public class ArgsNode : Node
    {
        public ArgsNode()
        {
        }

        public ArgsNode(string value) : base(value)
        {
        }

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
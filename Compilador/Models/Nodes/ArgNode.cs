using Compilador.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Compilador.Models.Nodes
{
    public class ArgNode : Node
    {
        public override NodeType Type => NodeType.ARG;

        public override bool First(char next)
        {
            return new IdNode().First(next) || new ValorNode().First(next);
        }

        public override bool Follow(string next)
        {
            return
                next == "," ||
                next == ")" ||
                new ArgsNode().Follow(next) ||
                new ArgsNode().First(next.FirstOrDefault());
        }

        public override IEnumerable<Condition> GetNeightbors()
        {
            yield return new Condition(new List<INode>() { new IdNode() });
            yield return new Condition(new List<INode>() { new ExprBiNode() });
            yield return new Condition(new List<INode>() { new ValorNode() });
            yield break;
        }

        public override bool IsTerminal()
        {
            return false;
        }
    }
}

using CompiladorAPI.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace CompiladorAPI.Models
{
    public class Condition
    {
        public readonly List<INode> Nodes;

        public Condition(List<INode> nodes)
        {
            Nodes = nodes;
        }

        public int Count() => Nodes.Count;
    }
}
using Compilador.Interfaces;
using System.Collections.Generic;

namespace Compilador.Models.Nodes
{
    public class SNode : Node
    {
        public override NodeType Type => NodeType.S;

        public override IEnumerable<Condition> GetNeightbors()
        {
            yield return new Condition(new List<INode>() { new BlocoNode() });
            yield break;
        }

        public override bool IsTerminal()
        {
            return false;
        }

        public override bool Follow(string next)
        {
            return true;
            //return next == 0x1A.ToString(); //EOF (End of file)
        }

        public override bool First(char next)
        {
            return new BlocoNode().First(next);
        }

        public override bool Build(char next)
        {
            return false;
        }
    }
}

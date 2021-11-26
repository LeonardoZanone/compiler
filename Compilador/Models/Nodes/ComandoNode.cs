using Compilador.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Compilador.Models.Nodes
{
    internal class ComandoNode : Node
    {
        public override NodeType Type => NodeType.COMANDO;

        public override bool Build(char next)
        {
            throw new System.NotImplementedException();
        }

        public override bool First(char next)
        {
            return next == 'i' ||   //if
                next == 'f' ||      //for
                next == 'w' ||      //while
                next == 'd' ||      //do
                next == 'p';        //print
        }

        public override bool Follow(string next)
        {
            return new BlocoNode().Follow(next) || new BlocoNode().First(next.First());
        }

        public override IEnumerable<Condition> GetNeightbors()
        {
            throw new System.NotImplementedException();
        }

        public override bool IsTerminal()
        {
            return true;
        }
    }
}
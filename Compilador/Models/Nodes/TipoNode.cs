using Compilador.Interfaces;
using System.Collections.Generic;

namespace Compilador.Models.Nodes
{
    public class TipoNode : Node
    {
        public override NodeType Type => NodeType.TIPO;

        public override bool Build(char next)
        {
            throw new System.NotImplementedException();
        }

        public override bool First(char next)
        {
            return next == 'i' //int
                || next == 'f' //float
                || next == 'c' //char
                || next == 'b';//bool
        }

        public override bool Follow(string next)
        {
            throw new System.NotImplementedException();
        }

        public override IEnumerable<Condition> GetNeightbors()
        {
            throw new System.NotImplementedException();
        }

        public override bool IsTerminal()
        {
            return true;
        }

        public override bool Validate(string value = null, List<INode> nodes = null)
        {
            throw new System.NotImplementedException();
        }
    }
}
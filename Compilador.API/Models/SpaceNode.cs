using CompiladorAPI.Models;
using CompiladorAPI.Models.Nodes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Compilador.API.Models
{
    public class SpaceNode : Node
    {
        private string _space;
        public SpaceNode(string value) : base(value)
        {
            _space = value;
        }

        public override NodeType Type => NodeType.SPACE;

        public override bool First(char next)
        {
            return _space.StartsWith(next);
        }

        public override bool Follow(string next)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<Condition> GetNeightbors()
        {
            yield break;
        }

        public override bool IsTerminal()
        {
            return true;
        }
        public override string ToString()
        {
            return _space;
        }
    }
}

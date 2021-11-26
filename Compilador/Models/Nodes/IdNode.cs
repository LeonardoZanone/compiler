using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Compilador.Models.Nodes
{
    public class IdNode : Node
    {
        private static readonly Regex alphabet = new Regex(@"[a-zA-Z]");
        public override NodeType Type => NodeType.ID;

        public override bool Build(char next)
        {
            throw new NotImplementedException();
        }

        public override bool First(char next)
        {
            return alphabet.IsMatch(next.ToString());
        }

        public override bool Follow(string next)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<Condition> GetNeightbors()
        {
            throw new NotImplementedException();
        }

        public override bool IsTerminal()
        {
            throw new NotImplementedException();
        }
    }
}

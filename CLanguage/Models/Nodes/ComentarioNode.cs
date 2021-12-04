using CompiladorAPI.Interfaces;
using CompiladorAPI.Models;
using CompiladorAPI.Models.Nodes;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace CLanguage.Models.Nodes
{
    public class ComentarioNode : Node
    {
        private static readonly Regex firstComentarioRegex = new Regex(@"^[\/\**]*");
        private static readonly Regex buildComentarioRegex = new Regex(@"^\/\*(.*)(\*\/){0,1}");
        private static readonly Regex comentarioRegex = new Regex(@"^\/\*(.*)\*\/$");
        public ComentarioNode()
        {
        }

        public ComentarioNode(string value) : base(value)
        {
        }

        public override NodeType Type => NodeType.COMENTARIO;

        public override IEnumerable<Condition> GetNeightbors()
        {
            yield break;
        }

        public override bool IsTerminal()
        {
            return true;
        }

        public override bool Validate()
        {
            if (comentarioRegex.IsMatch(Value))
            {
                _isValid = true;
                return true;
            }
            return false;
        }

        public override bool First(char next)
        {
            return firstComentarioRegex.IsMatch(next.ToString());
        }

        public override bool Follow(string next)
        {
            return next.Contains("*/");
        }

        public override bool Build(char next)
        {
            if (buildComentarioRegex.IsMatch(Value + next))
            {
                Value += next;
                return true;
            }
            return false;
        }

        public override INode From(INode node)
        {
            return new ComentarioNode("/*" + node.GetCleanValue() + "*/");
        }
    }
}

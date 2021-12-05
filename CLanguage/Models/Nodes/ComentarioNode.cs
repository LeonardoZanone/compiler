using CompiladorAPI.Interfaces;
using CompiladorAPI.Models;
using CompiladorAPI.Models.Nodes;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace CLanguage.Models.Nodes
{
    public class ComentarioNode : Node
    {
        private static readonly Regex firstRegex = new Regex(@"^[\/\**]*");
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
            if (Value.StartsWith("/*") && Value.EndsWith("*/"))
            {
                _isValid = true;
                return true;
            }
            return false;
        }

        public override bool First(char next)
        {
            return firstRegex.IsMatch(next.ToString());
        }

        public override bool Follow(string next)
        {
            return next.Contains("*/");
        }

        public override bool Build(char next)
        {
            if(string.IsNullOrEmpty(Value) && next != '/')
            {
                return false;
            }

            if(Value.EndsWith("*") && next == '/')
            {
                Value += next;
                return false;
            }

            Value += next;
            return true;
        }

        public override INode From(INode node)
        {
            return new ComentarioNode("/*" + node.GetCleanValue() + "*/");
        }

        public override string GetCleanValue()
        {
            return Value.TrimStart("/*".ToCharArray()).TrimEnd("*/".ToCharArray());
        }
    }
}

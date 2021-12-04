
using CompiladorAPI.Interfaces;
using CompiladorAPI.Models;
using CompiladorAPI.Models.Nodes;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace DotLanguage.Models.Nodes
{
    internal class OpUnNode : Node
    {
        public override NodeType Type => NodeType.OPUN;
        private static readonly Regex opUnRegex = new Regex(@"^(\+\+|\-\-|\!){1}$");
        private static readonly Regex firstOpUnRegex = new Regex(@"^(\+|\-|\!)");
        private static readonly Regex buildOpUnRegex = new Regex(@"^(\+\+*|\-\-*|\!)$");

        public OpUnNode()
        {
        }

        public OpUnNode(string value) : base(value)
        {
        }

        public override bool Build(char next)
        {
            if(buildOpUnRegex.IsMatch(Value + next))
            {
                Value += next;
                return true;
            }
            return false;
        }

        public override bool First(char next)
        {
            return firstOpUnRegex.IsMatch(next.ToString());
        }

        public override bool Follow(string next)
        {
            return new ExprAttrNode().Follow(next);
        }

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
            if (opUnRegex.IsMatch(Value))
            {
                _isValid = true;
                return true;
            }
            return false;
        }
    }
}
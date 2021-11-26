using Compilador.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Compilador.Models.Nodes
{
    internal class ComandoNode : Node
    {
        public override NodeType Type => NodeType.COMANDO;
        /// <summary>
        /// Matches the beggining of if, for, while, do, print
        /// </summary>
        private readonly Regex firstComandoRegex = new Regex(@"^[ifwdp]*");
        private readonly Regex comandoRegex = new Regex(@"^if|for|while|do|print$");
        private readonly Regex buildComandoRegex = new Regex(@"^if*|fo*r*|wh*i*l*e*|do*|pr*i*n*t*");

        public override bool Build(char next)
        {
            if(buildComandoRegex.IsMatch(Value + next))
            {
                Value += next;
                return true;
            }
            return false;
        }

        public override bool First(char next)
        {
            return firstComandoRegex.IsMatch(next.ToString());
        }

        public override bool Follow(string next)
        {
            return new BlocoNode().Follow(next) || new BlocoNode().First(next.First());
        }

        public override IEnumerable<Condition> GetNeightbors()
        {
            yield break;
        }

        public override bool IsTerminal()
        {
            return true;
        }
        public override bool Validate(string value = null, List<INode> nodes = null)
        {
            return comandoRegex.IsMatch(Value);
        }
    }
}
﻿using Compilador.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Compilador.Models.Nodes
{
    public class TipoNode : Node
    {
        public override NodeType Type => NodeType.TIPO;
        /// <summary>
        /// Matches the beggining of int, float, char, bool
        /// </summary>
        private readonly Regex firstTipoRegex = new Regex(@"^[ifcb]*");
        private readonly Regex tipoRegex = new Regex(@"^int|float|char|bool$");
        private readonly Regex buildTipoRegex = new Regex(@"^in*t*|fl*o*a*t*|ch*a*r*|bo*o*l*");

        public override bool Build(char next)
        {
            if(buildTipoRegex.IsMatch(Value + next))
            {
                Value += next;
                return true;
            }

            return false;
        }

        public override bool First(char next)
        {
            return firstTipoRegex.IsMatch(next.ToString());
        }

        public override bool Follow(string next)
        {
            return new IdNode().First(next.FirstOrDefault());
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
            return tipoRegex.IsMatch(Value);
        }
    }
}
﻿using Compilador.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Compilador.Models.Nodes
{
    public class OpBiNode : Node
    {
        public override NodeType Type => NodeType.OPBI;
        private readonly Regex opBiRegex = new Regex(@"^[\!\=\<\>]*={0,1}$|^[\+\-\/\<\>\%]$|^[&|]{2}$");
        private readonly Regex firstOpBiRegex = new Regex(@"^\!|\=|\+|\-|\/|\<|\>|\%|\&|\|");
        private readonly Regex buildOpBiRegex = new Regex(@"^[\!\=\<\>]*={0,1}$|^[\+\-\/\<\>\%]$|^[&|]{2}");

        public override bool Build(char next)
        {
            if(buildOpBiRegex.IsMatch(Value + next))
            {
                Value += next;
                return true;
            }
            return false;
        }

        public override bool First(char next)
        {
            return firstOpBiRegex.IsMatch(next.ToString());
        }

        public override bool Follow(string next)
        {
            return new ValorNode().First(next.FirstOrDefault());
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
            return opBiRegex.IsMatch(Value);
        }
    }
}
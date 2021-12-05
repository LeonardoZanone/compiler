﻿using CompiladorAPI.Models;
using CompiladorAPI.Models.Nodes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace CLanguage.Models.Nodes.PrimitiveTypes
{
    public class IntTypeNode : Node
    {
        public override NodeType Type => NodeType.INTTYPE;
        private static readonly Regex firstRegex = new Regex(@"^[i]*");
        private static readonly Regex validateRegex = new Regex(@"^int$");
        private static readonly Regex buildRegex = new Regex(@"^in*t*(?<=in*t*)$");

        public IntTypeNode()
        {
        }

        public IntTypeNode(string value) : base(value)
        {
        }

        public override bool First(char next)
        {
            return firstRegex.IsMatch(next.ToString());
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

        public override bool Validate()
        {
            if (validateRegex.IsMatch(Value))
            {
                _isValid = true;
                return true;
            }
            return false;
        }

        public override bool Build(char next)
        {
            if (buildRegex.IsMatch(Value + next))
            {
                Value += next;
                return true;
            }
            return false;
        }

        public override string ToString()
        {
            return "int";
        }
    }
}

﻿
using Compilador.Interfaces;
using System.Collections.Generic;

namespace Compilador.Models.Nodes
{
    internal class OpUnNode : Node
    {
        public override NodeType Type => NodeType.OPUN;

        public override bool Build(char next)
        {
            throw new System.NotImplementedException();
        }

        public override bool First(char next)
        {
            throw new System.NotImplementedException();
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
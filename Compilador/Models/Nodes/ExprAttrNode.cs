﻿using Compilador.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Compilador.Models.Nodes
{
    internal class ExprAttrNode : Node
    {
        public override NodeType Type => NodeType.EXPRATT;

        public override bool First(char next)
        {
            return new IdNode().First(next) || new TipoNode().First(next);
        }

        public override bool Follow(string next)
        {
            return new ExprNode().Follow(next) || new ExprNode().First(next.FirstOrDefault());
        }

        public override IEnumerable<Condition> GetNeightbors()
        {
            yield return new Condition(new List<INode>() { new TipoNode(), new IdNode(), new OpAttrNode(), new AtribuicaoNode() });
            yield return new Condition(new List<INode>() { new IdNode(), new OpAttrNode(), new AtribuicaoNode() });
            yield return new Condition(new List<INode>() { new TipoNode(), new IdNode() });
            yield return new Condition(new List<INode>() { new IdNode(), new OpUnNode() });
            yield break;
        }

        public override bool IsTerminal()
        {
            return false;
        }
    }
}
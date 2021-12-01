﻿using Compilador.Interfaces;
using System.Collections.Generic;

namespace Compilador.Models.Nodes
{
    public class AtribuicaoNode : Node
    {
        public override NodeType Type => NodeType.ATRIBUICAO;

        public override IEnumerable<Condition> GetNeightbors()
        {
            yield return new Condition(new List<INode>() { new IdNode() });
            yield return new Condition(new List<INode>() { new ValorNode() });
            yield return new Condition(new List<INode>() { new ExprBiNode() });
            yield break;
        }

        public override bool IsTerminal()
        {
            return false;
        }

        public override bool Follow(string next)
        {
            return new ExprNode().Follow(next);
        }

        public override bool First(char next)
        {
            return new IdNode().First(next) || new ExprBiNode().First(next) || new ValorNode().First(next);
        }

    }
}
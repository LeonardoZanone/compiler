using Compilador.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Compilador.Models.Nodes
{
    public class BlocoNode : Node
    {
        public override NodeType Type => NodeType.BLOCO;

        public override IEnumerable<Condition> GetNeightbors()
        {
            yield return new Condition(new List<INode>() { new ExprNode(), new TerminalNode(";"), new BlocoNode() });
            yield return new Condition(new List<INode>() { new ComentarioNode(), new BlocoNode() });
            yield return new Condition(new List<INode>() { new ComandoNode(), new BlocoNode() });
            yield return new Condition(new List<INode>() { new ExprNode(), new TerminalNode(";")});
            yield return new Condition(new List<INode>() { new ComandoNode() });
            yield return new Condition(new List<INode>() { new ComentarioNode() });
            yield return new Condition(new List<INode>() { new TerminalNode("") });
            yield break;
        }

        public override bool IsTerminal()
        {
            return false;
        }

        public override bool Follow(string next)
        {
            return new SNode().Follow(next) || next.EndsWith("}");
        }

        public override bool First(char next)
        {
            return new ExprNode().First(next) || new ComandoNode().First(next) || new ComentarioNode().First(next);
        }
    }
}

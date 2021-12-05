using CompiladorAPI.Interfaces;
using CompiladorAPI.Models;
using CompiladorAPI.Models.Nodes;
using DotLanguage.Models.Nodes;
using DotLanguage.Models.Nodes.Commands;
using DotLanguage.Models.Nodes.Commands.Terminal;
using DotLanguage.Models.Nodes.PrimitiveTypes;
using System;
using System.Collections.Generic;

namespace DotLanguage.Models
{
    public class DotCode : Code
    {
        public static readonly Dictionary<NodeType, INode> DotNodes = new Dictionary<NodeType, INode>();

        public DotCode(string fileName, string filePath, string content) : base(fileName, filePath, content)
        {
            Initiaze();
        }

        public DotCode()
        {
            Initiaze();
        }

        private void Initiaze()
        {
            DotNodes.Add(NodeType.ARG, new ArgNode());
            DotNodes.Add(NodeType.ARGS, new ArgsNode());
            DotNodes.Add(NodeType.ATRIBUICAO, new AtribuicaoNode());
            DotNodes.Add(NodeType.BLOCO, new BlocoNode());
            DotNodes.Add(NodeType.BOOLTYPE, new BoolTypeNode());
            DotNodes.Add(NodeType.CHARTYPE, new CharTypeNode());
            DotNodes.Add(NodeType.COMANDO, new ComandoNode());
            DotNodes.Add(NodeType.COMENTARIO, new ComentarioNode());
            DotNodes.Add(NodeType.DIGITO, new DigitoNode());
            DotNodes.Add(NodeType.DO, new TerminalDoNode());
            DotNodes.Add(NodeType.ELSE, new TerminalElseNode());
            DotNodes.Add(NodeType.ELSEIF, new TerminalElseIfNode());
            DotNodes.Add(NodeType.EXPR, new ExprNode());
            DotNodes.Add(NodeType.EXPRATT, new ExprAttrNode());
            DotNodes.Add(NodeType.EXPRBI, new ExprBiNode());
            DotNodes.Add(NodeType.FLOAT, new FloatNode());
            DotNodes.Add(NodeType.FLOATTYPE, new FloatTypeNode());
            DotNodes.Add(NodeType.FOR, new ForNode());
            DotNodes.Add(NodeType.ID, new IdNode());
            DotNodes.Add(NodeType.IF, new IfNode());
            DotNodes.Add(NodeType.INTEIRO, new InteiroNode());
            DotNodes.Add(NodeType.INTTYPE, new IntTypeNode());
            DotNodes.Add(NodeType.OPATTR, new OpAttrNode());
            DotNodes.Add(NodeType.OPBI, new OpBiNode());
            DotNodes.Add(NodeType.OPUN, new OpUnNode());
            DotNodes.Add(NodeType.PRINT, new PrintNode());
            DotNodes.Add(NodeType.S, new SNode());
            DotNodes.Add(NodeType.TERMINAL, new TerminalNode(""));
            DotNodes.Add(NodeType.TERMINALDO, new TerminalDoNode());
            DotNodes.Add(NodeType.TERMINALFOR, new TerminalForNode());
            DotNodes.Add(NodeType.TERMINALIF, new TerminalIfNode());
            DotNodes.Add(NodeType.TERMINALPRINT, new TerminalPrintNode());
            DotNodes.Add(NodeType.TERMINALWHILE, new TerminalWhileNode());
            DotNodes.Add(NodeType.TIPO, new TipoNode());
            DotNodes.Add(NodeType.VALOR, new ValorNode());
            DotNodes.Add(NodeType.WHILE, new WhileNode());
        }

        protected override void SetGraph()
        {
            SetGraph(new DotGraph());
        }
        protected override void Analyse()
        {
            Graph.Analyse(Content);
        }
        public override INode GetNode(NodeType type)
        {
            return DotNodes[type];
        }
    }
}

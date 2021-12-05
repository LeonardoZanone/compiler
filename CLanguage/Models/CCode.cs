using CLanguage.Models.Nodes;
using CLanguage.Models.Nodes.Commands;
using CLanguage.Models.Nodes.Commands.Terminal;
using CLanguage.Models.Nodes.PrimitiveTypes;
using CompiladorAPI.Interfaces;
using CompiladorAPI.Models.Nodes;
using System;
using System.Collections.Generic;

namespace CompiladorAPI.Models
{
    public class CCode : Code
    {
        public static readonly Dictionary<NodeType, INode> CNodes = new Dictionary<NodeType, INode>();
        public CCode()
        {
            CNodes.Add(NodeType.ARG, new ArgNode());
            CNodes.Add(NodeType.ARGS, new ArgsNode());
            CNodes.Add(NodeType.ATRIBUICAO, new AtribuicaoNode());
            CNodes.Add(NodeType.BLOCO, new BlocoNode());
            CNodes.Add(NodeType.BOOLTYPE, new BoolTypeNode());
            CNodes.Add(NodeType.CHARTYPE, new CharTypeNode());
            CNodes.Add(NodeType.COMANDO, new ComandoNode());
            CNodes.Add(NodeType.COMENTARIO, new ComentarioNode());
            CNodes.Add(NodeType.DIGITO, new DigitoNode());
            CNodes.Add(NodeType.DO, new TerminalDoNode());
            CNodes.Add(NodeType.ELSE, new TerminalElseNode());
            CNodes.Add(NodeType.ELSEIF, new TerminalElseIfNode());
            CNodes.Add(NodeType.EXPR, new ExprNode());
            CNodes.Add(NodeType.EXPRATT, new ExprAttrNode());
            CNodes.Add(NodeType.EXPRBI, new ExprBiNode());
            CNodes.Add(NodeType.FLOAT, new FloatNode());
            CNodes.Add(NodeType.FLOATTYPE, new FloatTypeNode());
            CNodes.Add(NodeType.FOR, new ForNode());
            CNodes.Add(NodeType.ID, new IdNode());
            CNodes.Add(NodeType.IF, new IfNode());
            CNodes.Add(NodeType.INTEIRO, new InteiroNode());
            CNodes.Add(NodeType.INTTYPE, new IntTypeNode());
            CNodes.Add(NodeType.OPATTR, new OpAttrNode());
            CNodes.Add(NodeType.OPBI, new OpBiNode());
            CNodes.Add(NodeType.OPUN, new OpUnNode());
            CNodes.Add(NodeType.PRINT, new PrintNode());
            CNodes.Add(NodeType.S, new SNode());
            CNodes.Add(NodeType.TERMINAL, new TerminalNode(""));
            CNodes.Add(NodeType.TERMINALDO, new TerminalDoNode());
            CNodes.Add(NodeType.TERMINALFOR, new TerminalForNode());
            CNodes.Add(NodeType.TERMINALIF, new TerminalIfNode());
            CNodes.Add(NodeType.TERMINALPRINT, new TerminalPrintNode());
            CNodes.Add(NodeType.TERMINALWHILE, new TerminalWhileNode());
            CNodes.Add(NodeType.TIPO, new TipoNode());
            CNodes.Add(NodeType.VALOR, new ValorNode());
            CNodes.Add(NodeType.WHILE, new WhileNode());
        }
        public CCode(string fileName, string filePath, string content) : base(fileName, filePath, content)
        {
            
        }
        protected override void SetGraph()
        {
            SetGraph(new CGraph());
        }
        protected override void Analyse()
        {
            Graph.Analyse(Content);
        }

        public override INode GetNode(NodeType type)
        {
            return CNodes[type];
        }
    }
}

using CLanguage.Models.Nodes;
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
            CNodes.Add(NodeType.COMANDO, new ComandoNode());
            CNodes.Add(NodeType.COMENTARIO, new ComentarioNode());
            CNodes.Add(NodeType.DIGITO, new DigitoNode());
            //CNodes.Add(NodeType.DO, new DoNode());
            //CNodes.Add(NodeType.ELSE, new ElseNode());
            //CNodes.Add(NodeType.ELSEIF, new ElseIfNode());
            CNodes.Add(NodeType.EXPR, new ExprNode());
            CNodes.Add(NodeType.EXPRATT, new ExprAttrNode());
            CNodes.Add(NodeType.EXPRBI, new ExprBiNode());
            CNodes.Add(NodeType.FLOAT, new FloatNode());
            CNodes.Add(NodeType.FOR, new ForNode());
            CNodes.Add(NodeType.ID, new IdNode());
            CNodes.Add(NodeType.IF, new IfNode());
            CNodes.Add(NodeType.INTEIRO, new InteiroNode());
            CNodes.Add(NodeType.OPATTR, new OpAttrNode());
            CNodes.Add(NodeType.OPBI, new OpBiNode());
            CNodes.Add(NodeType.OPUN, new OpUnNode());
            CNodes.Add(NodeType.PRINT, new PrintNode());
            CNodes.Add(NodeType.S, new SNode());
            CNodes.Add(NodeType.TERMINAL, new TerminalNode(""));
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

        public override ICode TranslateTo<ICodeType>()
        {
            string a = string.Empty;
            if (Graph?.IsAnalysed() ?? false)
            {
                foreach (INode node in Graph.Traversal())
                {
                    if (node.IsTerminal())
                    {
                        INode convertedNode = node.TranslateNodeTo<CCode>();
                        a += convertedNode.ToString();
                    }
                }
            }
            return null;
        }
    }
}

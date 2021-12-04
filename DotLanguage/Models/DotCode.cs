using CompiladorAPI.Interfaces;
using CompiladorAPI.Models;
using CompiladorAPI.Models.Nodes;
using DotLanguage.Models.Nodes;
using System.Collections.Generic;

namespace DotLanguage.Models
{
    public class DotCode : Code
    {
        public static readonly Dictionary<NodeType, INode> DotNodes = new Dictionary<NodeType, INode>();

        public DotCode(string fileName, string filePath, string content) : base(fileName, filePath, content)
        {
            DotNodes.Add(NodeType.ARG, new ArgNode());
            DotNodes.Add(NodeType.ARGS, new ArgsNode());
            DotNodes.Add(NodeType.ATRIBUICAO, new AtribuicaoNode());
            DotNodes.Add(NodeType.BLOCO, new BlocoNode());
            DotNodes.Add(NodeType.COMANDO, new ComandoNode());
            DotNodes.Add(NodeType.COMENTARIO, new ComentarioNode());
            DotNodes.Add(NodeType.DIGITO, new DigitoNode());
            //CNodes.Add(NodeType.DO, new DoNode());
            //CNodes.Add(NodeType.ELSE, new ElseNode());
            //CNodes.Add(NodeType.ELSEIF, new ElseIfNode());
            DotNodes.Add(NodeType.EXPR, new ExprNode());
            DotNodes.Add(NodeType.EXPRATT, new ExprAttrNode());
            DotNodes.Add(NodeType.EXPRBI, new ExprBiNode());
            DotNodes.Add(NodeType.FLOAT, new FloatNode());
            DotNodes.Add(NodeType.FOR, new ForNode());
            DotNodes.Add(NodeType.ID, new IdNode());
            DotNodes.Add(NodeType.IF, new IfNode());
            DotNodes.Add(NodeType.INTEIRO, new InteiroNode());
            DotNodes.Add(NodeType.OPATTR, new OpAttrNode());
            DotNodes.Add(NodeType.OPBI, new OpBiNode());
            DotNodes.Add(NodeType.OPUN, new OpUnNode());
            DotNodes.Add(NodeType.PRINT, new PrintNode());
            DotNodes.Add(NodeType.S, new SNode());
            DotNodes.Add(NodeType.TERMINAL, new TerminalNode(""));
            DotNodes.Add(NodeType.TIPO, new TipoNode());
            DotNodes.Add(NodeType.VALOR, new ValorNode());
            DotNodes.Add(NodeType.WHILE, new WhileNode());
        }

        public DotCode()
        {
        }

        protected override void SetGraph()
        {
            SetGraph(new DotGraph());
        }
        protected override void Analyse()
        {
            Graph.Analyse(Content);
        }
        public override ICode TranslateTo<TCode>()
        {
            string a = string.Empty;
            if (Graph?.IsAnalysed() ?? false)
            {
                foreach (INode node in Graph.Traversal())
                {
                    if(node.IsTerminal())
                    {
                        INode convertedNode = node.TranslateNodeTo<TCode>();
                        a += convertedNode.ToString();
                    }
                }
            }
            return null;
        }

        public override INode GetNode(NodeType type)
        {
            return DotNodes[type];
        }
    }
}

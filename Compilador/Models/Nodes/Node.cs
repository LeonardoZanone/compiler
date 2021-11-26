using Compilador.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Compilador.Models.Nodes
{
    public abstract class Node : INode
    {
        public abstract NodeType Type { get; }

        public virtual string Value { get; set; } = string.Empty;

        public List<INode> Children { get; set; } = new List<INode>();

        public Node()
        {
        }
        public Node(string value)
        {
            Value = value;
        }
        public virtual bool Validate(string value = null, List<INode> nodes = null)
        {
            if (IsTerminal())
            {
                return true;
            }

            //foreach (Condition condition in GetNeightbors())
            //{
            //    List<INode> nodes2 = condition.Validate(value, nodes);
            //    if (nodes2?.Count == condition.Count())
            //    {
            //        Children.AddRange(nodes2);
            //    }
            //}

            return false;
        }

        public List<INode> Validate(string value)
        {
            List<INode> result = new List<INode>();
            foreach (Condition condition in GetNeightbors())
            {
                foreach (INode node in condition.Nodes)
                {
                    char[] values = value.ToCharArray();
                    bool added = false;

                    if (!node.Follow(value))
                    {
                        break;
                    }

                    if (!node.First(value.FirstOrDefault()))
                    {
                        break;
                    }

                    foreach (char character in values)
                    {
                        if (!node.Build(character))
                        {
                            break;
                        }
                    }

                    if (node.Validate(value, null))
                    {
                        result.Add(node);
                        added = true;
                        //node.GetChildren().AddRange(result);
                        value = value.Substring(node.GetValue().Count());
                    }

                    foreach (var item in node.GetNeightbors())
                    {
                        foreach (var item2 in item.Nodes)
                        {
                            item2.Validate(value);
                        }
                    }

                    if (!added)
                    {
                        break;
                    }

                    if (string.IsNullOrEmpty(node.GetValue()))
                    {
                        return result;
                    }
                }
            }
            return result;
        }

        public abstract IEnumerable<Condition> GetNeightbors();
        public abstract bool IsTerminal();
        public abstract bool First(char next);
        public abstract bool Follow(string next);
        public abstract bool Build(char next);

        public string GetValue()
        {
            return Value;
        }

        public List<INode> GetChildren()
        {
            return Children;
        }
    }

    public enum NodeType
    {
        S = 0,
        BLOCO = 1,
        EXPR = 2,
        EXPRATT = 3,
        ATRIBUICAO = 4,
        EXPRBI = 5,
        VALOR = 6,
        FLOAT = 7,
        INTEIRO = 8,
        DIGITO = 9,
        TIPO = 10,
        COMANDO = 11,
        IF = 12,
        ELSE = 13,
        ELSEIF = 14,
        FOR = 15,
        WHILE = 16,
        DO = 17,
        PRINT = 18,
        ARGS = 19,
        ARG = 20,
        OPUN = 21,
        OPBI = 22,
        OPATTR = 23,
        TERMINAL = 24,
        COMENTARIO = 25,
        ID = 26
    }
}
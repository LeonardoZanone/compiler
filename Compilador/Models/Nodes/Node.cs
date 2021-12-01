using Compilador.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Compilador.Models.Nodes
{
    public abstract class Node : INode
    {
        public abstract NodeType Type { get; }

        public virtual string Value { get; set; } = string.Empty;

        private List<INode> Children { get; set; } = new List<INode>();
        private INode Parent { get; set; }

        public Node()
        {
        }
        public Node(string value)
        {
            Value = value;
        }
        public virtual bool Validate()
        {
            if(!IsTerminal() && GetChildren().Last().IsValid())
            {
                IsValid(true);
                return true;
            }
            return false;
        }

        protected bool _isValid;

        public string Validate(string value, List<NodeType> callStack)
        {
            string backupValue = value;
            foreach (Condition condition in GetNeightbors())
            {
                value = backupValue;
                Children = new List<INode>();
                foreach (INode node in condition.Nodes)
                {
                    if (string.IsNullOrEmpty(value))
                    {
                        callStack.RemoveAt(callStack.Count - 1);
                        IsValid(true);
                        return null;
                    }

                    AddChild(node as Node);
                    callStack.Add((node as Node).Type);

                    if (callStack.Count(n => n == Type) > 20)
                    {
                        (node as Node).Value = "STACK LIMIT";
                        callStack.RemoveAt(callStack.Count - 1);
                        return value;
                    }

                    if (!node.First(value.FirstOrDefault()))
                    {
                        callStack.RemoveAt(callStack.Count - 1);
                        break;
                    }

                    //if (!node.Follow(value))
                    //{
                    //    callStack.RemoveAt(callStack.Count - 1);
                    //    break;
                    //}

                    if (node.IsTerminal())
                    {
                        foreach (char character in value)
                        {
                            if (!node.Build(character))
                            {
                                break;
                            }
                        }

                        if (node.Validate())
                        {
                            value = value.Substring(node.GetValue().Count());
                            if(condition.Nodes.Last() == node)
                            {
                                return value;
                            }
                        }
                        else
                        {
                            callStack.RemoveAt(callStack.Count - 1);
                            break;
                        }
                    }
                    else
                    {
                        string tempValue = node.Validate(value, callStack);
                        
                        if (tempValue != "FAILED PATH")
                        {
                            value = tempValue;
                        }

                        if (string.IsNullOrEmpty(value) && Validate())
                        {
                            callStack.RemoveAt(callStack.Count - 1);
                            (node as Node).Parent.IsValid(true);
                            return null;
                        }

                        if (node.Validate() && condition.Nodes.Last() == node)
                        {
                            return value;
                        }
                    }
                    callStack.RemoveAt(callStack.Count - 1);
                }
            }

            return "FAILED PATH";

            //foreach (Condition condition in GetNeightbors())
            //{
            //    foreach (INode node in condition.Nodes)
            //    {
            //        char[] values = value.ToCharArray();
            //        bool added = false;

            //        if (!node.Follow(value))
            //        {
            //            break;
            //        }

            //        if (!node.First(value.FirstOrDefault()))
            //        {
            //            break;
            //        }

            //        foreach (char character in values)
            //        {
            //            if (!node.Build(character))
            //            {
            //                break;
            //            }
            //        }

            //        if (node.Validate(value, null))
            //        {
            //            return node;
            //            //result.Add(node);
            //            //node.GetChildren().Add(node);
            //            //if (node.IsTerminal())
            //            //{
            //            //    return value.Substring(node.GetValue().Count());
            //            //}
            //        }

            //        foreach (Condition item in node.GetNeightbors())
            //        {
            //            foreach (INode item2 in item.Nodes)
            //            {
            //                INode result = item2.Validate(value);
            //                if (result != null)
            //                {
            //                    this.GetChildren().Add(result);
            //                    value = value.Substring(result.GetValue().Count());
            //                }
            //            }
            //        }

            //        if (!added)
            //        {
            //            break;
            //        }

            //        //if (string.IsNullOrEmpty(node.GetValue()))
            //        //{
            //        //    return result;
            //        //}
            //    }
            //}
            //return null;
        }

        public abstract IEnumerable<Condition> GetNeightbors();
        public abstract bool IsTerminal();
        public abstract bool First(char next);
        public abstract bool Follow(string next);
        public virtual bool Build(char next)
        {
            return IsTerminal();
        }

        public string GetValue()
        {
            return Value;
        }

        public List<INode> GetChildren()
        {
            return Children;
        }

        public NodeType GetNodeType()
        {
            return Type;
        }

        public bool IsValid(bool isValid = false)
        {
            if(isValid)
            {
                _isValid = true;
            }
            return _isValid;
        }

        public void AddChild(Node child)
        {
            Children.Add(child);
            child.Parent = this;
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
﻿using Compilador.API.Models;
using CompiladorAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace CompiladorAPI.Models.Nodes
{
    public abstract class Node : INode
    {
        public abstract NodeType Type { get; }

        public virtual string Value { get; set; } = string.Empty;

        private List<INode> Children { get; set; } = new List<INode>();
        private INode Parent { get; set; }
        private static readonly Dictionary<Type, ICode> Codes = new Dictionary<Type, ICode>();
        private static readonly Regex whiteSpaces = new Regex(@"^\s");
        public Node()
        {
        }
        public Node(string value)
        {
            Value = value;
        }
        public virtual bool Validate()
        {
            if (!IsTerminal() && GetChildren().Last().IsValid())
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
                value = HandleWhitespaces(value);
                value = backupValue;
                Children = new List<INode>();
                foreach (INode node in condition.Nodes)
                {
                    value = HandleWhitespaces(value);
                    if (string.IsNullOrEmpty(value))
                    {
                        callStack.RemoveAt(callStack.Count - 1);
                        IsValid(true);
                        return null;
                    }

                    if (Type == NodeType.BLOCO && IsValid())
                    {
                        break;
                    }

                    AddChild(node as Node);

                    callStack.Add((node as Node).Type);

                    if (callStack.Count(n => n == Type) > 1000)
                    {
                        (node as Node).Value = "STACK LIMIT";
                        callStack.RemoveAt(callStack.Count - 1);
                        return "STACK LIMIT";
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
                            if (condition.Nodes.Last() == node)
                            {
                                callStack.RemoveAt(callStack.Count - 1);
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
                        value = node.Validate(value, callStack);

                        if (value == "FAILED PATH" || value == "STACK LIMIT")
                        {
                            value = backupValue;
                            break;
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
        }

        private string HandleWhitespaces(string value)
        {
            while (whiteSpaces.IsMatch(value))
            {
                AddChild(new SpaceNode(value.First().ToString()));
                value = value.Substring(1);
            }

            return value;
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
            if (isValid)
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

        public override string ToString()
        {
            string text = string.Empty;
            if (IsTerminal())
            {
                return Value;
            }
            foreach (INode child in GetChildren())
            {
                text += child.ToString();
            }
            return text;
        }

        public INode TranslateNodeTo<TCode>() where TCode : ICode
        {
            if (!Codes.ContainsKey(typeof(TCode)))
            {
                Codes.Add(typeof(TCode), (ICode)Activator.CreateInstance(typeof(TCode)));
            }
            ICode code = Codes[typeof(TCode)];
            return code.GetNode(Type).From(this);
        }

        public virtual INode From(INode node)
        {
            INode clonedNode = (INode)Activator.CreateInstance(GetType(), node.GetCleanValue());
            foreach (INode child in node.GetChildren())
            {
                clonedNode.AddChild((Node)child);
            }
            return clonedNode;
        }

        public virtual string GetCleanValue()
        {
            return Value;
        }

        public virtual bool IsSimpleTranslation()
        {
            return true;
        }
    }

    public enum NodeType
    {
        SPACE = 0,
        S,
        BLOCO,
        EXPR,
        EXPRATT,
        ATRIBUICAO,
        EXPRBI,
        VALOR,
        FLOAT,
        INTEIRO,
        DIGITO,
        TIPO,
        COMANDO,
        IF,
        ELSE,
        ELSEIF,
        FOR,
        WHILE,
        DO,
        PRINT,
        ARGS,
        ARG,
        OPUN,
        OPBI,
        OPATTR,
        TERMINAL,
        COMENTARIO,
        ID,
        TERMINALIF,
        TERMINALFOR,
        TERMINALDO,
        TERMINALPRINT,
        TERMINALWHILE,
        INTTYPE,
        FLOATTYPE,
        CHARTYPE,
        BOOLTYPE
    }
}
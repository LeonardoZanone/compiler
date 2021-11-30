using Compilador.Models;
using Compilador.Models.Nodes;
using System.Collections.Generic;

namespace Compilador.Interfaces
{
    public interface INode
    {
        public string GetValue();
        public List<INode> GetChildren();
        public bool Validate();
        public IEnumerable<Condition> GetNeightbors();
        public bool IsTerminal();
        public bool Build(char next);
        public bool First(char next);
        public bool Follow(string next);
        public string Validate(string value, List<NodeType> callStack);
        public NodeType GetNodeType();
        public bool IsValid(bool valid = false);
        public void AddChild(Node child);
    }
}

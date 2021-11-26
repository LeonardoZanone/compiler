using Compilador.Models;
using Compilador.Models.Nodes;
using System.Collections.Generic;

namespace Compilador.Interfaces
{
    public interface INode
    {
        public string GetValue();
        public List<INode> GetChildren();
        public bool Validate(string value = null, List<INode> nodes = null);
        public IEnumerable<Condition> GetNeightbors();
        public bool IsTerminal();
        public bool Build(char next);
        public bool First(char next);
        public bool Follow(string next);
        public List<INode> Validate(string value);
        public NodeType GetNodeType();
    }
}

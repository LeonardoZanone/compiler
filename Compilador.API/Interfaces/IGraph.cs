using CompiladorAPI.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CompiladorAPI.Interfaces
{
    public interface IGraph
    {
        public void Analyse(string content);
        public IEnumerable<INode> Traversal();
        public bool IsAnalysed();
    }
}

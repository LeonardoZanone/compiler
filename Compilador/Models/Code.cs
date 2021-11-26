using Compilador.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Compilador.Models
{
    public abstract class Code
    {
        public string FileName { get; protected set; }
        public string FilePath { get; protected set; }
        public string Content { get; protected set; }
        private IGraph _graph { get; set; }

        public Code(string fileName, string filePath, string content)
        {
            FileName = fileName;
            FilePath = filePath;
            Content = content;
            SetGraph();
            Analyse();
        }

        protected IGraph Graph { get => _graph; }

        protected abstract void Analyse();
        protected abstract void SetGraph();
        protected void SetGraph(IGraph graph) => this._graph = graph;
    }
}

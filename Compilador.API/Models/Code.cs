﻿using CompiladorAPI.Interfaces;
using CompiladorAPI.Models.Nodes;
using System.Collections.Generic;

namespace CompiladorAPI.Models
{
    public abstract class Code : ICode
    {
        public string FileName { get; protected set; }
        public string FilePath { get; protected set; }
        public string Content { get; protected set; }
        protected IGraph _graph { get; set; }

        public Code() { }
        public Code(string fileName, string filePath, string content)
        {
            FileName = fileName;
            FilePath = filePath;
            Content = content;
            SetGraph();
            Analyse();
        }

        protected IGraph Graph => _graph;

        protected abstract void Analyse();
        protected abstract void SetGraph();
        protected void SetGraph(IGraph graph)
        {
            _graph = graph;
        }

        public abstract ICode TranslateTo<TCode>() where TCode : ICode;

        public abstract INode GetNode(NodeType type);
    }
}
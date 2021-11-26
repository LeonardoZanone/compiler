using Compilador.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Compilador.Interfaces
{
    public interface IGraph
    {
        public void Analyse(string content);
        public ICode Translate();
    }
}

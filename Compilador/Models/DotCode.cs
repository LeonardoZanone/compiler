using Compilador.Interfaces;

namespace Compilador.Models
{
    public class DotCode : Code
    {
        public DotCode(string fileName, string filePath, string content) : base(fileName, filePath, content)
        {

        }
        protected override void SetGraph()
        {
            this.SetGraph(new DotGraph());
        }
        protected override void Analyse()
        {
            Graph.Analyse(Content);
        }

        protected override void TrasnslateTo(ICode code)
        {
            throw new System.NotImplementedException();
        }
    }
}

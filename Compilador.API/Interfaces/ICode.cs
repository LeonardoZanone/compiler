using CompiladorAPI.Models.Nodes;

namespace CompiladorAPI.Interfaces
{
    public interface ICode
    {
        ICode TranslateTo<TCode>() where TCode : ICode;

        INode GetNode(NodeType type);
    }
}

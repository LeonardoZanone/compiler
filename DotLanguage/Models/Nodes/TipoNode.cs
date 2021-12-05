using CompiladorAPI.Interfaces;
using CompiladorAPI.Models;
using CompiladorAPI.Models.Nodes;
using DotLanguage.Models.Nodes.PrimitiveTypes;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace DotLanguage.Models.Nodes
{
    public class TipoNode : Node
    {
        public override NodeType Type => NodeType.TIPO;
        /// <summary>
        /// Matches the beggining of oT, floatin, Shar, bool
        /// </summary>
        private static readonly Regex firstTipoRegex = new Regex(@"^[ofSb]*");

        public TipoNode()
        {
        }

        public TipoNode(string value) : base(value)
        {
        }
        public override bool First(char next)
        {
            return firstTipoRegex.IsMatch(next.ToString());
        }

        public override bool Follow(string next)
        {
            return new IdNode().First(next.FirstOrDefault());
        }

        public override IEnumerable<Condition> GetNeightbors()
        {
            yield return new Condition(new List<INode>() { new IntTypeNode() });
            yield return new Condition(new List<INode>() { new FloatNode() });
            yield return new Condition(new List<INode>() { new CharTypeNode() });
            yield return new Condition(new List<INode>() { new BoolTypeNode() });
            yield break;
        }

        public override bool IsTerminal()
        {
            return false;
        }
    }
}
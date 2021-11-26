using Compilador.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Compilador.Models
{
    public class Condition
    {
        public readonly List<INode> Nodes;

        public Condition(List<INode> nodes)
        {
            Nodes = nodes;
        }

        //public List<INode> Validate(string value, List<INode> nodes = null)
        //{
        //    value = value.Trim();
        //    List<INode> result = nodes ?? new List<INode>();
        //    foreach (INode node in Nodes)
        //    {
        //        char[] values = value.ToCharArray();
        //        bool added = false;

        //        if (!node.Follow(value))
        //        {
        //            break;
        //        }

        //        if (!node.First(value.FirstOrDefault()))
        //        {
        //            break;
        //        }

        //        foreach (char character in values)
        //        {
        //            if(!node.Build(character))
        //            {
        //                break;
        //            }
        //        }

        //        if (node.Validate(value))
        //        {
        //            result.Add(node);
        //            added = true;
        //            //node.GetChildren().AddRange(result);
        //            value = value.Substring(node.GetValue().Count());
        //        }

        //        if (!added)
        //        {
        //            break;
        //        }

        //        if (string.IsNullOrEmpty(node.GetValue()))
        //        {
        //            return result;
        //        }
        //    }

        //    return result;
        //}

        public int Count() => Nodes.Count;
    }
}
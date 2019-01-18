using System;
using System.Collections.Generic;
using System.Text;

namespace N_AryTree
{
    public class TreeNode<T>
    {

        public T Value { get; set; }
        public TreeNode<T> Parent { get; set; }
        public List<TreeNode<T>> Child { get; set;}

        public TreeNode(T data, List<TreeNode<T>> children, TreeNode<T> parentNode)
        {
            this.Value = data;
            this.Child = children;
            this.Parent = parentNode;
        }

        public override string ToString()
        {
            return Value.ToString();
        }



    }
}

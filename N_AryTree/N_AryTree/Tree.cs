using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace N_AryTree
{
    public class Tree<T>
    {
        public int Count { get; set; }
        public int LeafCount { get; set; }

        public TreeNode<T> headOfTreeNode;
        public List<TreeNode<T>> treeTotal = new List<TreeNode<T>>();

        public Tree(T data)
        {
            //Initialise the tree, with data the value of the first node
            this.Count = 1;
            this.LeafCount = 1;
            headOfTreeNode = new TreeNode<T>(data, new List<TreeNode<T>>(), null);
            treeTotal.Add(headOfTreeNode);
        }


        public void AddChildNode(TreeNode<T> parentNode, T value)
        {
            //adds new TreeNode with supplied value to Tree below node parentNode

            TreeNode<T> childNode = new TreeNode<T>(value, new List<TreeNode<T>>(), parentNode);
            treeTotal.Add(childNode);

            AdjustCount(parentNode, childNode, true);

        }

        public void AdjustCount(TreeNode<T> parentNode, TreeNode<T> childNode, bool Add)
        {
            //Is a function to adjust the count
            if (Add)
            {
                if (parentNode.Child.Count != 0)
                {
                    LeafCount++;
                }

                parentNode.Child.Add(childNode);
                Count++;
            }
            else
            {
                if (parentNode.Child.Count != 0)
                {
                    LeafCount--;
                }
                Count--;
            }
        }

        public void RemoveNode(TreeNode<T> node)
        {
            //remove specific TreeNode from Tree

            List<TreeNode<T>> childrenNode = node.Parent.Child;
            int ixChildren = childrenNode.FindIndex(child => child.Equals(node));
            childrenNode.RemoveAt(ixChildren);
            treeTotal.Remove(node);

            AdjustCount(node.Parent, node, false);

            if (node.Child.Count != 0)
            {
                for(int i = 0; i < node.Child.Count; i++)
                {
                    RemoveNode(node.Child[i]);
                    i--;
                }
            }

        }

        public string TraverseNodes()
        {
            //Returns all node values
            //Per row, per column
            StringBuilder partialString = new StringBuilder();
            bool first = true;

            foreach (TreeNode<T> n in treeTotal)
            {
                T nodeValue = n.Value;

                if (!first)
                {
                    partialString.Append("," + nodeValue.ToString());
                }
                else
                {
                    partialString.Append(nodeValue.ToString());
                    first = false;
                }
            }

            string stringTree = partialString.ToString();
            return stringTree;

        }

        public string SumToLeafs()
        {

            //Returns only all summed node values on the paths to each leaf node 

            StringBuilder partialString = new StringBuilder();
            List<T> sumList = new List<T>();

            foreach (var n in treeTotal)
            {
                if(n.Child.Count == 0)
                {
                    TreeNode<T> current = n;
                    List<T> sum = new List<T>();

                    while(current.Parent != null)
                    {
                        sum.Add(current.Value);
                        current = current.Parent;
                    }

                    sum.Add(headOfTreeNode.Value);
                    sum.Reverse();

                    //To add whether it is an int, string, double, or whatsoever. Dynamic.
                    //Note: References > Microsoft.Csharp must be added to the project
                    dynamic total = sum[0];
                    sum.Remove(sum[0]);

                    foreach (var val in sum)
                    {
                        total = total + val;
                    }

                    sumList.Add(total);

                }
            }

            //Print with ,
            foreach (var sum in sumList)
            {
                partialString.Append(", " + sum.ToString());
            }

            string sumString = partialString.ToString();
            return sumString;
        }

    }
}

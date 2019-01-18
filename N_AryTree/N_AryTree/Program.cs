using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N_AryTree
{
    class MainClass
    {
        public static void Main(string[] args)
        {

            Tree<string> beginningTree = new Tree<string>("Chaos");


            beginningTree.AddChildNode(beginningTree.headOfTreeNode, "Erebus");
            beginningTree.AddChildNode(beginningTree.headOfTreeNode, "Nyx");

            TreeNode<string> Parent = beginningTree.headOfTreeNode.Child[1];

            beginningTree.AddChildNode(Parent, "Hemera");
            beginningTree.AddChildNode(Parent, "Aether");
            beginningTree.AddChildNode(Parent, "Gaia");
            beginningTree.AddChildNode(Parent, "Tartar");

            Parent = Parent.Child[2];
            beginningTree.AddChildNode(Parent, "Pontus");
            beginningTree.AddChildNode(Parent, "Ouranos");

            //This is the statement to print
            Console.WriteLine(beginningTree.headOfTreeNode.Value);
            foreach (var kid in beginningTree.headOfTreeNode.Child)
            {
                Console.Write(kid.Value.ToString() + " ");
            }
            Console.WriteLine();

            foreach (var kid in beginningTree.headOfTreeNode.Child)
            {
                foreach (var grandkid in kid.Child)
                {

                    Console.Write(grandkid.Value.ToString() + " ");
                }
            }
            Console.WriteLine();
            foreach (var kid in beginningTree.headOfTreeNode.Child)
            {
                //Console.WriteLine("    ");
                foreach (var grandkid in kid.Child)
                {
                    foreach (var grandGrandkid in grandkid.Child)
                    {

                        Console.Write(grandGrandkid.Value.ToString() + " ");
                    }
                }
            }


            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine(beginningTree.TraverseNodes());
            Console.WriteLine("Number of nodes: " + beginningTree.Count.ToString());
            Console.WriteLine("Number of leaves: " + beginningTree.LeafCount.ToString());
            Console.WriteLine("The succesive node hierarchy: " + beginningTree.TraverseNodes().ToString());
            Console.WriteLine("The sum of the tree leafs: " + beginningTree.SumToLeafs());
            Console.WriteLine();
            beginningTree.RemoveNode(Parent); // Remove Gaia and children from the tree
            Console.WriteLine(Parent.ToString() + " is removed from the tree, plus children.");
            Console.WriteLine();
            Console.WriteLine("The new succesive node hierarchy: " + beginningTree.TraverseNodes().ToString());
            Console.ReadLine();



        }
    }
}

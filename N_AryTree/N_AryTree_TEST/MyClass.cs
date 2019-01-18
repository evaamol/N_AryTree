using System;
using NUnit.Framework;
using N_AryTree;

namespace N_AryTree_TEST
{
    [TestFixture]
    public class MyClass
    {
        [TestCase]
        public void TestN_ARY_Add()
        {
            //Test if the adding of Children is done right
            Tree<string> beginningTree = new Tree<string>("Chaos");


            beginningTree.AddChildNode(beginningTree.headOfTreeNode, "Erebus");
            beginningTree.AddChildNode(beginningTree.headOfTreeNode, "Nyx");

            TreeNode<string> Parent1 = beginningTree.headOfTreeNode.Child[1];

            beginningTree.AddChildNode(Parent1, "Hemera");
            beginningTree.AddChildNode(Parent1, "Aether");
            beginningTree.AddChildNode(Parent1, "Gaia");
            beginningTree.AddChildNode(Parent1, "Tartar");

            TreeNode<string> Parent2 = Parent1.Child[2];
            beginningTree.AddChildNode(Parent2, "Pontus");
            beginningTree.AddChildNode(Parent2, "Ouranos");

            Assert.Multiple(() =>
            {
                Assert.That(beginningTree.treeTotal.Count == 9);
                Assert.AreEqual(Parent1, beginningTree.headOfTreeNode.Child[1]);
                Assert.Contains(Parent1, beginningTree.treeTotal);
                Assert.Contains(Parent2, beginningTree.treeTotal);

            });
        }
        [TestCase]
        public void TestN_ARY_Remove()
        {
            //Test if the removal of parents and children is done right
            Tree<string> beginningTree = new Tree<string>("Chaos");


            beginningTree.AddChildNode(beginningTree.headOfTreeNode, "Erebus");
            beginningTree.AddChildNode(beginningTree.headOfTreeNode, "Nyx");

            TreeNode<string> Parent1 = beginningTree.headOfTreeNode.Child[1];

            beginningTree.AddChildNode(Parent1, "Hemera");
            beginningTree.AddChildNode(Parent1, "Aether");
            beginningTree.AddChildNode(Parent1, "Gaia");
            beginningTree.AddChildNode(Parent1, "Tartar");

            TreeNode<string> Parent2 = Parent1.Child[2];
            beginningTree.AddChildNode(Parent2, "Pontus");
            beginningTree.AddChildNode(Parent2, "Ouranos");

            beginningTree.RemoveNode(Parent2);

            Assert.Multiple(() =>
            {
                Assert.That(beginningTree.treeTotal.Count == 6);
                Assert.AreEqual(Parent1, beginningTree.headOfTreeNode.Child[1]);
                Assert.Contains(Parent1, beginningTree.treeTotal);
            });

        } 
    }
}

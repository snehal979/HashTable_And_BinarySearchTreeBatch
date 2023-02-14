using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace HashTableAndBinaryTree
{
    public class MyBinaryNode
    {
        public Node midRoot { get; set; }
        /// <summary>
        /// Section 4 BTS -Insert data
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public void Insert(int data)
        {
            Node beforeNode = null;
            Node afterNode = this.midRoot;
            while (afterNode!=null)
            {
                beforeNode = afterNode;
                if (data < afterNode.data)
                {
                    afterNode=afterNode.leftNode;
                }
                else
                {
                    afterNode=afterNode.rightNode;
                }
            }
            Node nodeNew = new Node();
            nodeNew.data = data;
            if (this.midRoot == null)
            {
                this.midRoot = nodeNew;
            }
            else
            {
                if (data < beforeNode.data)
                {
                    beforeNode.leftNode=nodeNew;
                }
                else
                {
                    beforeNode.rightNode=nodeNew;
                }
            }
        }
        /// <summary>
        /// Section 4 BTS-Traversal and their type
        /// </summary>
        /// <param name="paraent"></param>
        public void InOrderTraversal(Node paraent)
        {
            if (paraent!=null)
            {
                InOrderTraversal(paraent.leftNode);
                Console.WriteLine(paraent.data);
                InOrderTraversal(paraent.rightNode);
            }
        }
        public void PreOrderTraversal(Node paraent)
        {
            if (paraent!=null)
            {
                Console.WriteLine(paraent.data);
                PreOrderTraversal(paraent.leftNode);
                PreOrderTraversal(paraent.rightNode);
            }
        }
        public void PostOrderTraversal(Node paraent)
        {
            if (paraent!=null)
            {
                PostOrderTraversal(paraent.leftNode);
                PostOrderTraversal(paraent.rightNode);
                Console.WriteLine(paraent.data);
            }
        }
    }
}

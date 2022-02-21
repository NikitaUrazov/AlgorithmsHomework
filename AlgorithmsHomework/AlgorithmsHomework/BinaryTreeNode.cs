using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithmsHomework
{
    class BinaryTreeNode
    {
        public int Value { get; set; }
        public BinaryTreeNode Left { get; set; } = null;
        public BinaryTreeNode Right { get; set; } = null;

        public BinaryTreeNode(int value)
        {
            Value = value;
        }
    }
}

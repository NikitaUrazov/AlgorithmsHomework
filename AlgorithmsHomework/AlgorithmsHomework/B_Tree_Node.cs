using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithmsHomework
{
    class B_Tree_Node
    {
        public int Value { get; set; }
        public B_Tree_Node Left { get; set; } = null;
        public B_Tree_Node Right { get; set; } = null;

        public B_Tree_Node(int value)
        {
            Value = value;
        }
    }
}

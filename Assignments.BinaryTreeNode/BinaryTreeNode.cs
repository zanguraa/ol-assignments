﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignments.BinaryTreeNode
{
    public class BinaryTreeNode
    {
        public int Value;
        public BinaryTreeNode? Left;
        public BinaryTreeNode? Right;

        public BinaryTreeNode(int value)
        {
            Value = value;
            Left = null;
            Right = null;
        }
    }
}

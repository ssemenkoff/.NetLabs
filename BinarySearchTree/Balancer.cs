using System;
namespace BinarySearchTree
{
    public static class Balancer<T> {
        public static void Balance(ref Node<T> root)
        {
            if (root.BalanceFactor == 2)
            {
                if(root._right.BalanceFactor < 0) {
                    root._right = RotateRight(root._right);
                }
                root = RotateLeft(root);
            }
            if (root.BalanceFactor == -2)
            {
                if(root._left.BalanceFactor > 0) {
                    root._left = RotateLeft(root._left);
                }
                root = RotateRight(root);
            }
        }

        public static Node<T> RotateRight(Node<T> p)
        {
            var q = p._left;
            p._left = q._right;
            q._right = p;

            return q;
        }

        public static Node<T> RotateLeft(Node<T> q)
        {
            var p = q._right;
            q._right = p._left;
            p._left = q;
            return p;
        }
    }
}

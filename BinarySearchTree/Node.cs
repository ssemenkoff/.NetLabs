using System;
namespace BinarySearchTree
{
    public class Node<T>
    {
        private T _value;
        public Node<T> _left;
        public Node<T> _right;

        public Node(T value)
        {
            _value = value;
            _left = null;
            _right = null;
        }

        public int BalanceFactor
        {
            get {
                var left = _left == null ? 0 : _left.Height;
                var right = _right == null ? 0 : _right.Height;

                return right - left;
            }
        }

        public int Height
        {
            get
            {
                if (_left == null)
                {
                    if (_right == null)
                    {
                        return 1;
                    }
                    return _right.Height + 1;
                }
                if (_right == null)
                {
                    return _left.Height + 1;
                }
                return (_left.Height > _right.Height) ? (_left.Height + 1) : (_right.Height + 1);
            }
        }

        public T Value
        {
            get => _value; set { _value = value; }
        }
    }


}

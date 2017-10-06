using System;
using System.Collections.Generic;

namespace BinarySearchTree
{
    public class AVL<T>
    {
		public Node<T> Root;
        private IComparer<T> _comparer;
     
        public AVL(IComparer<T> comparer)
        {
            _comparer = comparer;
        }

        public override string ToString()
        {
            return Root.ToString();
        }

        public void Add(T value) {
            if(Root == null) {
                Root = new Node<T>(value);
            } else {
                Add(ref Root, value);
            }
        }

        public void Remove(T value) {
            if(Root == null) {
                return;
            } else {
                Remove(ref Root, value);
            }
        }

        private void Remove(ref Node<T> node, T value) {
            if (_comparer.Compare(node.Value, value) == 0)
            {
                var min = Min(ref node);

                var rightOfMin = min._right;

                min._left = node._left;
                min._right = node._right;

                node = min;
                min = rightOfMin;
            }
        }

        private Node<T> Min (ref Node<T> node) {
            if(node._left == null) {
                return node;
            } else {
                return Min(ref node._left);
            }
        }

        private void Add(ref Node<T> node, T value) {
            if(node == null) {
                node = new Node<T>(value);
                return;
            }

            if (_comparer.Compare(value, node.Value) > 0) {
                Add(ref node._left, value);
            } else {
                Add(ref node._right, value);
            }

            Balancer<T>.Balance(ref node);
        }

        public IEnumerable<T> preOrder()
		{
			if (Root == null)
				yield break;

			yield return Root.Value;

			if (Root._left != null)
				foreach (T i in preOrder(Root._left))
					yield return i;

			if (Root._right != null)
				foreach (T i in preOrder(Root._right))
					yield return i;
		}

		private IEnumerable<T> preOrder(Node<T> node)
		{
			if (Root == null)
				yield break;

            yield return node.Value;

			if (Root._left != null)
				foreach (T i in preOrder(node._left))
					yield return i;

			if (Root._right != null)
				foreach (T i in preOrder(node._right))
					yield return i;
		}

		public IEnumerable<T> postOrder()
		{
			if (Root == null)
				yield break;
            
			if (Root._left != null)
				foreach (T i in postOrder(Root._left))
					yield return i;

			if (Root._right != null)
				foreach (T i in postOrder(Root._right))
					yield return i;
            
			yield return Root.Value;
		}

		private IEnumerable<T> postOrder(Node<T> node)
		{
			if (Root == null)
				yield break;

			if (Root._left != null)
				foreach (T i in postOrder(node._left))
					yield return i;

			if (Root._right != null)
				foreach (T i in postOrder(node._right))
					yield return i;

			yield return node.Value;
		}

		public IEnumerable<T> inOrder()
		{
			if (Root == null)
				yield break;

			if (Root._left != null)
				foreach (T i in inOrder(Root._left))
					yield return i;

			yield return Root.Value;

			if (Root._right != null)
				foreach (T i in inOrder(Root._right))
					yield return i;
		}

		private IEnumerable<T> inOrder(Node<T> node)
		{
			if (Root == null)
				yield break;

			if (Root._left != null)
				foreach (T i in inOrder(node._left))
					yield return i;
            
			yield return node.Value;

			if (Root._right != null)
				foreach (T i in inOrder(node._right))
					yield return i;
		}
    }
}

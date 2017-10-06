using System;
using System.Collections.Generic;

namespace BinarySearchTree
{

    class MainClass
    {
        public static void Main(string[] args)
        {
            var _binarySearchTreeString = new AVL<string>(new CustomComparer()); ;
            var _binarySearchTreeInt = new AVL<int>(Comparer<int>.Default);

            foreach (var s in DataSource.StringData) {
                _binarySearchTreeString.Add(s);
            }

			foreach (var i in DataSource.IntegerData)
			{
			    _binarySearchTreeInt.Add(i);
			}

            _binarySearchTreeInt.Remove(3);

            var a = _binarySearchTreeInt;

            System.Console.WriteLine(_binarySearchTreeString);
            System.Console.WriteLine(_binarySearchTreeInt);
        }
    }
}

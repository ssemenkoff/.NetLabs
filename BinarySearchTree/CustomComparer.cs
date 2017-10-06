using System;
using System.Collections.Generic;

namespace BinarySearchTree
{
    public class CustomComparer: IComparer<string>
    {
        public CustomComparer()
        {
        }

		public int Compare(string a, string b)
		{
			if (a[0] > b[0]) return -1;
			if (a[0] == b[0]) return 0;
			return 1;
		}
    }
}

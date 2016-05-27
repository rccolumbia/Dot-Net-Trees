using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Arbor
{
	//BinaryArbor1 is a preliminary Binary Tree class with minimal functionality.
	//It is intended later to transition from BinaryArbor1 to a binary tree class that inherits from a generic tree class.
	public class BinaryArbor1<T>:IBinaryArbor<T>
	{
		public BinaryArbor1()
		{
		}

		public BinaryArbor1(T value, IBinaryArbor<T> left, IBinaryArbor<T> right)
		{
			Value = value;
			Left = left;
			Right = right;
		}

		public T Value {get; set;}

		public IBinaryArbor<T> Left {get;set;}

		public IBinaryArbor<T> Right {get;set;}

		public IEnumerable<IArbor<T>> Children
		{
			get
			{
				List<IArbor<T>> elements = new List<IArbor<T>> ();
				elements.Add((IArbor<T>)Left);
				elements.Add((IArbor<T>)Right);
				ReadOnlyCollection<IArbor<T>> returnCollection = new ReadOnlyCollection<IArbor<T>>(elements);
				return returnCollection;
			}
		}
	}
}


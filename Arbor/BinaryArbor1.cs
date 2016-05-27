using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Arbor
{
	/// <summary>
	/// BinaryArbor1 is a preliminary Binary Tree class with minimal functionality. It is intended later to transition from BinaryArbor1 to a binary tree class that inherits from a generic tree class.
	/// </summary>
	public class BinaryArbor1<T>:IBinaryArbor<T>
	{
		public BinaryArbor1()
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Arbor.BinaryArbor1`1"/> class.
		/// </summary>
		/// <param name="value">The value for this node</param>
		/// <param name="left">The left child of this node (nullable)</param>
		/// <param name="right">The right child of this node (nullable)</param>
		public BinaryArbor1(T value, IBinaryArbor<T> left, IBinaryArbor<T> right)
		{
			Value = value;
			Left = left;
			Right = right;
		}

		/// <summary>
		/// Gets or sets the value for this node.
		/// </summary>
		/// <value>The value.</value>
		public T Value {get; set;}

		/// <summary>
		/// Gets or sets the left child of this node.
		/// </summary>
		/// <value>The left child of this node (nullable)</value>
		public IBinaryArbor<T> Left {get;set;}

		/// <summary>
		/// Gets or sets the right child of this node.
		/// </summary>
		/// <value>The right child of this node (nullable)</value>
		public IBinaryArbor<T> Right {get;set;}

		/// <summary>
		/// Gets a collection of references to the children of this node.
		/// </summary>
		/// <value>a collection of references to the children of this node</value>
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


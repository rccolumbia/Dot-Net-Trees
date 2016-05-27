using System;

namespace Arbor
{
	/// <summary>
	/// IBinaryArbor<T> is an interface for a generic binary tree of type T.
	/// </summary>
	public interface IBinaryArbor<T> : IArbor<T>
	{
		/// <summary>
		/// Gets or sets the left child of this node.
		/// </summary>
		/// <value>The left child of this node (nullable)</value>
		IBinaryArbor<T> Left {get;set;}

		/// <summary>
		/// Gets or sets the right child of this node.
		/// </summary>
		/// <value>The right child of this node (nullable)</value>
		IBinaryArbor<T> Right {get;set;}
	}
}


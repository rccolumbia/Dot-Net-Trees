using System;
using System.Collections.Generic;

namespace Arbor
{
	/// <summary>
	/// IArbor<T> is an interface for a generic tree of type T.
	/// </summary>
	public interface IArbor<T>
	{
		/// <summary>
		/// Gets or sets the value for this node.
		/// </summary>
		/// <value>The value.</value>
		T Value {get; set;}

		/// <summary>
		/// Gets a collection of references to the children of this node.
		/// </summary>
		/// <value>a collection of references to the children of this node</value>
		IEnumerable<IArbor<T>> Children {get;}	
	}
}

